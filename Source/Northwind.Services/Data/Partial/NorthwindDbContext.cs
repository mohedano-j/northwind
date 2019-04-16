using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Northwind.Services.Data
{
    public partial class NorthwindDbContext
    {
        protected static void Configure(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                  .SetBasePath(Directory.GetCurrentDirectory())
                  .AddJsonFile("appsettings.json")
                  .Build();

            var connectionString = configuration.GetConnectionString("NorthwindConnection");

            optionsBuilder
                .UseSqlServer(connectionString, providerOptions => providerOptions.CommandTimeout(60))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        /// <summary>Saves all changes made in this context to the database.</summary>
		/// <returns>The number of state entries written to the database.</returns>
		/// <remarks>This method will automatically call <see cref="M:Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTracker.DetectChanges" /> to discover any
		/// changes to entity instances before saving to the underlying database. This can be disabled via <see cref="P:Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTracker.AutoDetectChangesEnabled" /></remarks>
		public override int SaveChanges()
        {
            var namesOfChangedReadOnlyEntities = this.ChangeTracker.Entries().Where(e => e.Metadata.IsReadOnly() && e.State != EntityState.Unchanged).Select(e => e.Metadata.Name).Distinct().ToList();
            if (namesOfChangedReadOnlyEntities.Any())
            {
                throw new InvalidOperationException($"Attempted to save the following read-only entitie(s): {string.Join(",", namesOfChangedReadOnlyEntities)}");
            }
            return base.SaveChanges();
        }
    }

    internal static partial class NorthwindModelBuilderExtensions
    {
        private static readonly string READONLY_ANNOTATION = "custom:readonly";

        /// <summary>Extension method which is used by the context class to determine whether an entity is readonly</summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="builder">The entity type builder object to augment.</param>
        /// <returns>the passed in entity type builder</returns>
        internal static EntityTypeBuilder<TEntity> IsReadOnly<TEntity>(this EntityTypeBuilder<TEntity> builder)
            where TEntity : class
        {
            builder.HasAnnotation(READONLY_ANNOTATION, true);
            return builder;
        }

        /// <summary>Determines whether the passed in entity type has the readonly annotation set.
        /// </summary>
        /// <param name="entity">The entity type to check.</param>
        /// <returns>true if the entity type is marked as read-only, false otherwise</returns>
        public static bool IsReadOnly(this IEntityType entity)
        {
            var annotation = entity.FindAnnotation(READONLY_ANNOTATION);
            return annotation != null && (bool)annotation.Value;
        }
    }
}
