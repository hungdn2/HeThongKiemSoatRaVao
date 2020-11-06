using System;
using System.Collections.Generic;
using System.Text;

namespace SystemManageOutCome.Data.Entities
{
    public  class Employee
    {
        public int ID { set; get; }
        public int IdEm { set; get; }
        public string Name { set; get; }
        public DateTime born { set; get; }
        public string Position { set; get; }
        public int Role_ID { set; get; }
        public int DepartmentID { set; get; }
        public DateTime CreatedDate { set; get; }
        public DateTime CreateBy { set; get; }
        public DateTime UpdatedDate { set; get; }
        public DateTime UpdatedBy { set; get; }
    }
}
