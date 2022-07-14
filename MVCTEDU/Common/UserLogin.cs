using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCTEDU.Common
{
    [Serializable]
    public class UserLogin
    {
        public string UserName { set; get; }

        public string GroupID { set; get; }
    }
}