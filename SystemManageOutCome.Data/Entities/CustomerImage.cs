using System;
using System.Collections.Generic;
using System.Text;

namespace SystemManageOutCome.Data.Entities
{
    public class CustomerImage
    {
        public int ID { get; set; }
        public int Customerid { get; set; }
        public string ImagePath { get; set; }
        public string IsDefault { get; set; }
        public DateTime DateCreate { get; set; }
        public int SortOrder { get; set; }
        public int FileSize { get; set; }
    }
}
