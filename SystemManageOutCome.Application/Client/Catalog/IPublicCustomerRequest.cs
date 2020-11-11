using System;
using System.Collections.Generic;
using System.Text;
using SystemManageSolution.ViewModel.Catalog.Customer;
using SystemManageSolution.ViewModel.Catalog.Customer.Public;
using SystemManageSolution.ViewModel.Common;

namespace SystemManageOutCome.Application.Client.Catalog
{
    public interface IPublicCustomerRequest
    {
        PageViewModel<CustomerViewModel> GetAllByCustomerID(GetCustomerPagingRequest request);
    }
}
