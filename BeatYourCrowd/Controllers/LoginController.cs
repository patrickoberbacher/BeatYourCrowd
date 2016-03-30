using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeatYourCrowd.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            var clientId = "b26e2a06e5934f9da0b79c72a086ad78";
            var responseType = "code";
            var redirect = @"http://localhost:8888/login/callback";
            var scope = "user-read-private%20user-read-email";
            var state = "34fFs29kd09";
            var url = "https://accounts.spotify.com/authorize/?client_id={0}&response_type={1}&redirect_uri={2}&scope={3}&state={4}";

            var parsedUrl = String.Format(url, clientId, responseType, redirect, scope, state);

            return Redirect(parsedUrl);
        }

        public ActionResult Callback(string code)
        {
            System.Web.HttpContext.Current.Session.Add("code", code);
            return Redirect("/Player/Index");
        }

        public ActionResult Logout()
        {
            System.Web.HttpContext.Current.Session.Remove("code");
            return Redirect("/Home/Index");
        }
    }
}