using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SystemManageSolution.ViewModel.Catalog.Customer;
using SystemManageSolution.ViewModel.Catalog.Customer.Manage;
using SystemManageSolution.ViewModel.Common;

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
