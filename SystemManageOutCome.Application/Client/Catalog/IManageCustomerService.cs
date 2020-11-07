using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SystemManageOutCome.Application.Client.Catalog.CustomerService.Dtos;
using SystemManageOutCome.Application.Client.Catalog.Dtos.Manage;
using SystemManageOutCome.Application.Client.Customer;
using SystemManageOutCome.Application.Dtos;

namespace SystemManageOutCome.Application.Client.Catalog
{
    public interface IManageCustomerService
    {
        Task<int> Create(CustomerCreateRequest request);
        Task<int> Update(UpdateCustomerRequest request);
        Task<int> Delete(int CustomerID);
        Task<List<CustomerViewModel>> GetAll();

        Task<PageViewModel<CustomerViewModel>> GetAllPaing(GetCustomerPaingRequest request);
    }
}
