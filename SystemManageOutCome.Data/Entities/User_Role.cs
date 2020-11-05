using System;
using System.Collections.Generic;
using System.Text;

namespace SystemManageOutCome.Data.Entities
{
   public class User_Role
    {
    
        public Role IdRole { set; get; }
        public Employee IdEm { set; get; }
        public string user { set; get; }
        public string passWord { set; get; }
    }
}
