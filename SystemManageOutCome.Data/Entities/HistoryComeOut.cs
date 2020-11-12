using System;
using System.Collections.Generic;
using System.Text;

namespace SystemManageOutCome.Data.Entities
{
    public class HistoryComeOut
    {
        public long Id { get; set; }
        public int IdCustomer { get; set; }
        public DateTime TimeCome { get; set; }
        public DateTime TimeOut { get; set; }


    }
}
