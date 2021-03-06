﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SystemManageOutCome.Data.Entities
{
    public class Customers
    {

        public int ID { set; get; }
        public string FullName { set; get; }
        public bool? Sex { set; get; }
        public bool? Country { set; get; }
        public int? Company { set; get; }
        public int? Member { set; get; }
        public string CMT { set; get; }
        public DateTime DateIn { set; get; }
        public DateTime DateOut { set; get; }
        public string Description { set; get; }
        public string CreateBy { get; set; } 
        public string UpdateBy { get; set; }
        public int IsOut { get; set; } // 1 là chưa ra, 2 là đã ra 

    }


}
