using System;
using System.Collections.Generic;
using System.Text;
using SystemManageOutCome.Application.Client.Catalog.CustomerService.Dtos;
using SystemManageOutCome.Application.Client.Catalog.CustomerService.Dtos.Public;
using SystemManageOutCome.Application.Dtos;

namespace SystemManageOutCome.Application.Client.Catalog
{
    public interface IPublicCustomerRequest
    {
        PageViewModel<CustomerViewModel> GetAllByCustomerID(GetCustomerPagingRequest request);
    }
}
