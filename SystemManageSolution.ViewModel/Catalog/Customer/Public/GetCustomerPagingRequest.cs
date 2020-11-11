using System;
using System.Collections.Generic;
using System.Text;
using SystemManageSolution.ViewModel.Common;

namespace SystemManageSolution.ViewModel.Catalog.Customer.Public
{
    public class GetCustomerPagingRequest : PagingRequestBase
    {
        public int CategoryId { get; set; }
    }
}
