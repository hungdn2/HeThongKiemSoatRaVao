using System;
using System.Collections.Generic;
using System.Text;
using SystemManageSolution.ViewModel.Common;

namespace SystemManageSolution.ViewModel.Catalog.Customer.Manage
{
    public class GetCustomerPaingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
        public List<int> CategoryId { get; set; }

    }
}
