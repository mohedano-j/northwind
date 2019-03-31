﻿//------------------------------------------------------------------------------
// <auto-generated>This code was generated by LLBLGen Pro v5.5.</auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Northwind
{
	/// <summary>Class which represents the entity 'Shipper'.</summary>
	public partial class Shipper : CommonEntityBase
	{
		/// <summary>Method called from the constructor</summary>
		partial void OnCreated();

		/// <summary>Initializes a new instance of the <see cref="Shipper"/> class.</summary>
		public Shipper() : base()
		{
			this.Orders = new List<Order>();
			OnCreated();
		}

		/// <summary>Gets or sets the CompanyName field. </summary>
		public System.String CompanyName { get; set;}
		/// <summary>Gets or sets the Phone field. </summary>
		public System.String Phone { get; set;}
		/// <summary>Gets or sets the ShipperId field. </summary>
		public System.Int32 ShipperId { get; set;}
		/// <summary>Represents the navigator which is mapped onto the association 'Order.Shipper - Shipper.Orders (m:1)'</summary>
		public virtual List<Order> Orders { get; set;}
	}
}