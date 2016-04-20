using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyKendoRepository.Model;
using System.Data.Entity;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System.Web.Mvc;

namespace MyKendoRepository.ForUnity
{
    public interface ICustomerRepository
    {
        DataSourceResult Read([DataSourceRequest]DataSourceRequest dsrequest);
        CustomerModel Create(CustomerModel _customer);
        CustomerModel Update(CustomerModel _customer);
        void Destroy(int? _customerId);
    }

    
    class CustomerRepository : ICustomerRepository
    {
        KendoDbEntities _db = new KendoDbEntities();
        public DataSourceResult Read(DataSourceRequest dsrequest)
        {
            var result = _db.Customers.Select(s => new CustomerModel
            {
                Id = s.Id,
                Name = s.Name,
                Email = s.Email,
                Phone = s.Phone,
                City = s.City,
                Pincode = s.Pincode,
                IsActive = s.IsActive
            }).Where(q => q.IsActive == true).ToList().ToDataSourceResult(dsrequest);
            
            return result;
        }

        public CustomerModel Create(CustomerModel _customer)
        {
            if(_customer != null)
            {
                Customer newCustomer = new Customer();
                newCustomer.Name = _customer.Name;
                //newCustomer.Address = _customer.Address;
                newCustomer.Email = _customer.Email;
                newCustomer.Phone = _customer.Phone;
                newCustomer.Pincode = _customer.Pincode;
                newCustomer.City = _customer.City;
                newCustomer.IsActive = true;
                _db.Customers.Add(newCustomer);                    
                _db.SaveChanges();
                int insertedId = newCustomer.Id;
                _customer.Id = insertedId;
            }
            return _customer;
        }

        public CustomerModel Update(CustomerModel _customer)
        {
            if(_customer != null)
            {
                var existingCustomer = _db.Customers.Where(c => c.Id == _customer.Id).FirstOrDefault();
                existingCustomer.Name = _customer.Name;
                //existingCustomer.Address = _customer.Address;
                existingCustomer.Email = _customer.Email;
                existingCustomer.Phone = _customer.Phone;
                existingCustomer.Pincode = _customer.Pincode;
                existingCustomer.City = _customer.City;
                //_db.Entry(_customer).State = System.Data.EntityState.Modified;
                _db.SaveChanges();
            }

            return _customer;
        }

        public void Destroy(int? _customerId)
        {
            if (_customerId > 0)
            {
                // Soft Delete
                var deletedCustomer = _db.Customers.Where(c => c.Id == _customerId).FirstOrDefault();
                deletedCustomer.IsActive = false;
                _db.SaveChanges();
            }
        }
    }
    
}