﻿//------------------------------------------------------------------------------
// <auto-generated>This code was generated by LLBLGen Pro v5.5.</auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Northwind
{
	/// <summary>Class which represents the entity 'OrderDetail'.</summary>
	public partial class OrderDetail : CommonEntityBase
	{
		/// <summary>Method called from the constructor</summary>
		partial void OnCreated();

		/// <summary>Initializes a new instance of the <see cref="OrderDetail"/> class.</summary>
		public OrderDetail() : base()
		{
			OnCreated();
		}

		/// <summary>Gets or sets the Discount field. </summary>
		public System.Single Discount { get; set;}
		/// <summary>Gets or sets the OrderId field. </summary>
		public System.Int32 OrderId { get; set;}
		/// <summary>Gets or sets the ProductId field. </summary>
		public System.Int32 ProductId { get; set;}
		/// <summary>Gets or sets the Quantity field. </summary>
		public System.Int16 Quantity { get; set;}
		/// <summary>Gets or sets the UnitPrice field. </summary>
		public System.Decimal UnitPrice { get; set;}
		/// <summary>Represents the navigator which is mapped onto the association 'OrderDetail.Order - Order.OrderDetails (m:1)'</summary>
		public virtual Order Order { get; set;}
		/// <summary>Represents the navigator which is mapped onto the association 'OrderDetail.Product - Product.OrderDetails (m:1)'</summary>
		public virtual Product Product { get; set;}
	}
}
