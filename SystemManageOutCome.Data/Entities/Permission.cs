using System;
using System.Collections.Generic;
using System.Text;

namespace SystemManageOutCome.Data.Entities
{
    public class Permission
    {
        public int   ID { set; get; } 
        public Role  RoleID { set; get; }
        public int  FunctionID { set; get; }
        public int  ActionID { set; get; }

    }
}
