using System;
using System.Collections.Generic;
using System.Text;
using SystemManageOutCome.Application.Dtos;

namespace SystemManageOutCome.Application.Client.Catalog.CustomerService.Dtos.Public
{
   public class GetCustomerPagingRequest : PagingRequestBase
    {
        public int CategoryId { get; set; }
    }
}
