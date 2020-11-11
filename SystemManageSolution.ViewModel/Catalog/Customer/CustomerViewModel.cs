using System;
using System.Collections.Generic;
using System.Text;

namespace SystemManageSolution.ViewModel.Catalog.Customer
{
    public class CustomerViewModel
    {

        public int ID { set; get; }
        public string FullName { set; get; }
        public bool Sex { set; get; }
        public bool Country { set; get; }
        public int Company { set; get; }
        public int Member { set; get; }
        public string CMT { set; get; }
        public DateTime DateIn { set; get; }
        public DateTime DateOut { set; get; }
        public byte Image1 { set; get; }
        public byte Image2 { set; get; }
        public byte Image3 { set; get; }
        public string Description { set; get; }
    }
}
