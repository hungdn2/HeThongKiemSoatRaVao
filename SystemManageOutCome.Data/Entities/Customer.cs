using System;
using System.Collections.Generic;
using System.Text;

namespace SystemManageOutCome.Data.Entities
{
    public class Customer
    {
         public int   ID { set; get; }
         public string FullName { set; get; }
        public bool Sex { set; get; }
        public bool  Country { set; get; }
        public int  Company { set; get; }
        public int  Member { set; get; }
        public string  CMT { set; get; }
        public DateTime  DateIn { set; get; }
        public DateTime DateOut { set; get; }
        public Byte  Image1 { set; get; }
        public Byte Image2 { set; get; }
        public Byte Image3 { set; get; }
        public string  Description { set; get; }

    }
}
