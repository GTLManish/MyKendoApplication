using Kendo.Mvc.UI;
using MyKendoRepository.Model;
using MyKendoRepository.ForUnity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyKendoBusinessLogic.ForUnity
{
    public interface ICustomerBusinessLogic
    {
        DataSourceResult Read([DataSourceRequest]DataSourceRequest dsrequest);
        CustomerModel Create(CustomerModel _customer);
        CustomerModel Update(CustomerModel _customer);
        void Destroy(int? _customerId);
    }

    class CustomerBusinessLogic:ICustomerBusinessLogic
    {
        
        ICustomerRepository _customerRepository { get; set; }
        
        public CustomerBusinessLogic() { }
        public CustomerBusinessLogic(ICustomerRepository _customerRepository)
        {
            this._customerRepository = _customerRepository;
        }

        public DataSourceResult Read(DataSourceRequest dsrequest)
        {
            return _customerRepository.Read(dsrequest);
        }

        public CustomerModel Create(CustomerModel _customer)
        {
            return _customerRepository.Create(_customer);
        }

        public CustomerModel Update(CustomerModel _customer)
        {
            return _customerRepository.Update(_customer);
        }

        public void Destroy(int? _customerId)
        {
            _customerRepository.Destroy(_customerId);
        }
    }
    
}