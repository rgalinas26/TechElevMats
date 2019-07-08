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
            BaseVM vm = new BaseVM(GetCurrentUser());
            return View(vm);
        }

        #region Login

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // TODO: Implement Login action, get and post
        [HttpPost]
        public IActionResult Login(LoginVM loginViewModel)
        {
            // Ensure the fields were filled out
            if (!ModelState.IsValid)
            {
            return View(loginViewModel);
            }

            // Check that they provided correct credentials
            if (authProvider.SignIn(loginViewModel.Email, loginViewModel.Password))
            {
                return RedirectToAction("Search", "City");
            }

            TempData["message"] = "Invalid user name or password, please go away";
            return View(loginViewModel);

        }
        #endregion

        #region Logoff
        [HttpGet]
        public IActionResult LogOff()
        {
            // Clear user from session
            authProvider.LogOff();

            // Redirect the user where you want them to go after logoff
            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region Register Get and Post
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterVM registerViewModel)
        {
            // Check that the model is valid
            if (ModelState.IsValid)
            {
                // Register them as a new user (and set default role)
                authProvider.Register(registerViewModel.Email, registerViewModel.Password, "User");
                // When a user registers they need to be given a role. If you don't need anything special
                // just give them "User".

                // Redirect the user where you want them to go after registering
                return RedirectToAction("Search", "City");
            }
            return View(registerViewModel);
        }
        #endregion
    }
}