using System;
using System.Collections.Generic;
using System.Text;
using SystemManageOutCome.Application.Dtos;

namespace SystemManageOutCome.Application.Client.Catalog.Dtos.Manage
{
    public class GetCustomerPaingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
        public List<int> CategoryId { get; set; }

    }
}
