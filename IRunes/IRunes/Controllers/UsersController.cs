using IRunes.Services;
using IRunes.ViewModels.Users;
using SIS.HTTP;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace IRunes.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public HttpResponse Login()
        {
            return this.View();
        }
        [HttpPost]
        public HttpResponse Login(LoginInputModel input) 
        {
            var userId = this.usersService.GetUserId(input.Username, input.Password);
            if (userId != null) {
                this.SignIn(userId);
                return this.Redirect("/");
            }
            return this.Redirect("/Users/Login");

        }
        public HttpResponse Register() {
            return this.View();
        }
        [HttpPost]
        public HttpResponse Register(RegisterInputModel input)
        {
            if (string.IsNullOrEmpty(input.Email))
            {
                return this.Error("Invalid Email!");
            }
            if (input.Password.Length<4 || input.Password.Length>20)
            {

                return this.Error("Password must be btwn 4 and 20 symbols!");
            }
            if (input.Username.Length < 4 || input.Username.Length > 10)
            {
                return this.Error("Username must be btwn 4 and 20 symbols!");
            }
            if (input.Password != input.ConfirmPassword)
            {
                return this.Error("Passwords doesn't match!");
            }
            if (this.usersService.EmailExists(input.Email))
            {
                return this.Error("Email exists!");
            }
            if (this.usersService.UsernameExists(input.Username))
            {
                return this.Error("Username exists!");
            }

            this.usersService.Register(input.Username, input.Email, input.Password);
            return this.Redirect("/Users/Login");
        }
        public HttpResponse Logout()
        {
            this.SignOut();
            return this.Redirect("/");
        }

    }
}
