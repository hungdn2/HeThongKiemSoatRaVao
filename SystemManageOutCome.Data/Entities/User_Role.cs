using System;
using System.Collections.Generic;
using System.Text;

namespace SystemManageOutCome.Data.Entities
{
   public class User_Role
    {
        public int Id { get; set; }
        public int IdRole { set; get; }
        public int IdEm { set; get; }
        public string user { set; get; }
        public string passWord { set; get; }
    }
}
