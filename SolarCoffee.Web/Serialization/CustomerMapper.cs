using SolarCoffee.Data.Models;
using SolarCoffee.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarCoffee.Web.Serialization
{
    public class CustomerMapper
    {
        /// <summary>
        /// Serializes a CustomerModel into Customer model
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public static CustomerModel SerializeCustomer(Customer customer)
        {
            return new CustomerModel
            {
                Id = customer.Id,
                CreatedOn = customer.CreatedOn,
                UpdatedOn = customer.UpdatedOn,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                PrimaryAddress = MapCustomerAddress(customer.PrimaryAddress)
            };
        }

        /// <summary>
        /// Serializes a Customer to a CustomerModel
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public static Customer SerializeCustomer(CustomerModel customer)
        {
            return new Customer
            {
                Id = customer.Id,
                CreatedOn = customer.CreatedOn,
                UpdatedOn = customer.UpdatedOn,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                PrimaryAddress = MapCustomerAddress(customer.PrimaryAddress)
            };
        }

        /// <summary>
        /// Maps a CustomerAddress to CustomerAddressModel
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public static CustomerAddressModel MapCustomerAddress(CustomerAddress address)
        {
            return new CustomerAddressModel
            {
                AddressLine1 = address.AddressLine1,
                AddressLine2 = address.AddressLine2,
                City = address.City,
                State = address.State,
                Country = address.Country,
                PostalCode = address.PostalCode,
                CreatedOn = address.CreatedOn,
                UpdatedOn = address.UpdatedOn
            };
        }

        /// <summary>
        /// Maps a CustomerAddressModel to a CustomerAddress
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public static CustomerAddress MapCustomerAddress(CustomerAddressModel address)
        {
            return new CustomerAddress
            {
                Id = address.Id,
                AddressLine1 = address.AddressLine1,
                AddressLine2 = address.AddressLine2,
                City = address.City,
                State = address.State,
                Country = address.Country,
                PostalCode = address.PostalCode,
                CreatedOn = address.CreatedOn,
                UpdatedOn = address.UpdatedOn
            };
        }
    }
}
