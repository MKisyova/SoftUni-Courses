using Suls.Services;
using Suls.ViewModels.Users;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Suls.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }
        public HttpResponse Login()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(string username, string password)
        {
            var userId = userService.GetUserId(username, password);

            if (userId == null)
            {
                return this.Error("Invalid username or password");
            }

            this.SignIn(userId);
            return this.Redirect("/");
        }

        public HttpResponse Register()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterInputModel user)
        {
            if (string.IsNullOrEmpty(user.Username) || user.Username.Length < 5 || user.Username.Length > 20)
            {
                return this.Error("Username should be between 5 and 20 caracters.");
            }

            if (!this.userService.IsUserNameAvailable(user.Username))
            {
                return this.Error("Username already taken.");
            }

            if (string.IsNullOrEmpty(user.Email) || !new EmailAddressAttribute().IsValid(user.Email)) 
            {
                return this.Error("Invalid email address.");
            }

            if (!this.userService.IsEmailAvailable(user.Email))
            {
                return this.Error("Email already taken.");
            }

            if (string.IsNullOrEmpty(user.Password) || user.Password.Length < 6 || user.Password.Length > 20)
            {
                return this.Error("Password should be between 6 and 20 caracters.");
            }

            if (user.Password != user.ConfirmPassword)
            {
                return this.Error("Passwords should match.");
            }

            this.userService.CreateUser(user.Username, user.Email, user.Password);
            return this.Redirect("/Users/Login");
        }

        public HttpResponse Logout()
        {
            this.SignOut();
            return this.Redirect("/");
        }
    }
}
