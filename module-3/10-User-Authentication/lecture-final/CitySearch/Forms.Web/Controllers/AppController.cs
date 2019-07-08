using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forms.Web.Models;
using Forms.Web.Providers.Auth;
using Microsoft.AspNetCore.Mvc;

namespace Forms.Web.Controllers
{
    public class AppController : Controller
    {
        protected readonly IAuthProvider authProvider;
        public AppController(IAuthProvider authProvider)
        {
            this.authProvider = authProvider;
        }

        protected User GetCurrentUser()
        {
            return authProvider.GetCurrentUser();
        }

        //public T NewVM<T>() where T : BaseVM, new()
        //{
        //    T vm = new T();
        //    vm.CurrentUser = GetCurrentUser();
        //    return vm;
        //}
    }
}