using System;
using System.Collections.Generic;
using System.Text;

namespace SystemManageOutCome.Utilities.Exceptions
{
   public class SystemManageOutComeException :Exception
    {
        public SystemManageOutComeException()
        { }
        public SystemManageOutComeException(string message)
            : base(message)
        { }

        public SystemManageOutComeException(string message , Exception inner)
            : base(message, inner)
        { }
    }
}
