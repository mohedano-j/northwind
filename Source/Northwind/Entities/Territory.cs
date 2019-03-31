﻿//------------------------------------------------------------------------------
// <auto-generated>This code was generated by LLBLGen Pro v5.5.</auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Northwind
{
	/// <summary>Class which represents the entity 'Territory'.</summary>
	public partial class Territory : CommonEntityBase
	{
		/// <summary>Method called from the constructor</summary>
		partial void OnCreated();

		/// <summary>Initializes a new instance of the <see cref="Territory"/> class.</summary>
		public Territory() : base()
		{
			this.EmployeeTerritories = new List<EmployeeTerritory>();
			OnCreated();
		}

		/// <summary>Gets or sets the RegionId field. </summary>
		public System.Int32 RegionId { get; set;}
		/// <summary>Gets or sets the TerritoryDescription field. </summary>
		public System.String TerritoryDescription { get; set;}
		/// <summary>Gets or sets the TerritoryId field. </summary>
		public System.String TerritoryId { get; set;}
		/// <summary>Represents the navigator which is mapped onto the association 'EmployeeTerritory.Territory - Territory.EmployeeTerritories (m:1)'</summary>
		public virtual List<EmployeeTerritory> EmployeeTerritories { get; set;}
		/// <summary>Represents the navigator which is mapped onto the association 'Territory.Region - Region.Territories (m:1)'</summary>
		public virtual Region Region { get; set;}
	}
}