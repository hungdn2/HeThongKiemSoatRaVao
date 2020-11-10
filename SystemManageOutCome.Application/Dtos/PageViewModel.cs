using System;
using System.Collections.Generic;
using System.Text;

namespace SystemManageOutCome.Application.Dtos
{
    public class PageViewModel<T>
    {
        public List<T> Items { set; get; }
        public int TotalRecord { set; get; }
        
    }
}
