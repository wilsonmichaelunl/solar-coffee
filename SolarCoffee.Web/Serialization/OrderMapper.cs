﻿using SolarCoffee.Data.Models;
using SolarCoffee.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarCoffee.Web.Serialization
{
    /// <summary>
    /// Handles mapping Order data models to and from related View Models
    /// </summary>
    public static class OrderMapper
    {
        /// <summary>
        /// Maps an InvoiceModel view model to a SalesOrder data model
        /// </summary>
        /// <param name="invoice"></param>
        /// <returns></returns>
        public static SalesOrder SerializeInvoiceToOrder(InvoiceModel invoice)
        {
            var saleOrderItems = invoice.LineItems
                .Select(item => new SalesOrderItem
                {
                    Id = item.Id,
                    Quantity = item.Quantity,
                    Product = ProductMapper.SerializeProductModel(item.Product)
                }).ToList();

            return new SalesOrder
            {
                SalesOrderItems = saleOrderItems,
                CreatedOn = DateTime.UtcNow,
                UpdatedOn = DateTime.UtcNow
            };
        }

        /// <summary>
        /// Maps a collection of SaleOrders to OrderModels
        /// </summary>
        /// <param name="orders"></param>
        /// <returns></returns>
        public static List<OrderModel> SerializeOrdersToViewModels(IEnumerable<SalesOrder> orders)
        {
            return orders.Select(order => new OrderModel
            {
                Id = order.Id,
                CreatedOn = order.CreatedOn,
                UpdatedOn = order.UpdatedOn,
                SalesOrderItems = SerializeSalesOrderItems(order.SalesOrderItems),
                Customer = CustomerMapper.SerializeCustomer(order.Customer),
                IsPaid = order.IsPaid
            }).ToList();
        }

        /// <summary>
        /// Maps a collection of SalesOrderItems to SalesOrderItemModels
        /// </summary>
        /// <param name="orderItems"></param>
        /// <returns></returns>
        private static List<SalesOrderItemModel> SerializeSalesOrderItems(IEnumerable<SalesOrderItem> orderItems)
        {
            return orderItems.Select(item => new SalesOrderItemModel
            {
                Id = item.Id,
                Quantity = item.Quantity,
                Product = ProductMapper.SerializeProductModel(item.Product)
            }).ToList();
        }
    }
}
