using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forms.Web.Models
{
    public class BaseVM
    {
        public User CurrentUser { get; set; }

        public BaseVM(User currentUser)
        {
            this.CurrentUser = currentUser;
        }
    }
}
