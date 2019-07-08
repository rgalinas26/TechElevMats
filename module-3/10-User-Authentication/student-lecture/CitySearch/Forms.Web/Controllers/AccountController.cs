using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forms.Web.Models;
using Forms.Web.Providers.Auth;
using Microsoft.AspNetCore.Mvc;

namespace Forms.Web.Controllers
{
    // TODO: Modify Account/Index action to require authorization (any). Create the VM and pass it in
    // TODO: Edit the Account/Index view to show the logged in user and role.
    public class AccountController : AppController
    {
        public AccountController(IAuthProvider authProvider) : base(authProvider)
        {
        }

        // TODO: Add AuthorizationFilter, so that only logged in users can get to Account/Index
        [HttpGet]
        public IActionResult Index()
        {
            //BaseVM vm = new BaseVM(GetCurrentUser());
            //return View(vm);
            return View();
        }

        #region Login

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // TODO: Implement Login action, get and post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginVM loginViewModel)
        {
            // Ensure the fields were filled out
                // Check that they provided correct credentials

            return View(loginViewModel);
        }
        #endregion

        #region Logoff
        [HttpGet]
        public IActionResult LogOff()
        {
            // Clear user from session

            // Redirect the user where you want them to go after logoff

            return NotFound();
        }
        #endregion

        #region Register Get and Post
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterVM registerViewModel)
        {
            // CHeck that the model is valid
                // Register them as a new user (and set default role)
                // When a user registeres they need to be given a role. If you don't need anything special
                // just give them "User".

                // Redirect the user where you want them to go after registering

            return View(registerViewModel);
        }
        #endregion
    }
}