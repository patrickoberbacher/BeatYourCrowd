using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Models;
using SpotifyAPI.Web.Enums;


namespace BeatYourCrowd.Controllers
{
    public class Login1Controller : Controller
    {
        static AutorizationCodeAuth auth;

        // GET: Login1
        // =======================================================> Lucas: "return..." nur vorläufige Lösung, muss nochmals überarbeitet werden
        public ActionResult Index()
        {
            var clientId = "b26e2a06e5934f9da0b79c72a086ad78";
            var responseType = "code";
            var redirect = @"http://localhost:8888/login/callback";
            var scope = "user-read-private%20user-read-email";
            var state = "34fFs29kd09";
            var url = "https://accounts.spotify.com/authorize/?client_id={0}&response_type={1}&redirect_uri={2}&scope={3}&state={4}";

            var parsedUrl = String.Format(url, clientId, responseType, redirect, scope, state);


            //Create the auth object
            auth = new AutorizationCodeAuth()
            {
                //Your client Id
                ClientId = "b26e2a06e5934f9da0b79c72a086ad78",
                //Set this to localhost if you want to use the built-in HTTP Server
                RedirectUri = "http://localhost:8888/login/callback",
                //How many permissions we need?
                //Scope = Scope.USER_READ_PRIVATE,
            };
            //This will be called, if the user cancled/accept the auth-request
            auth.OnResponseReceivedEvent += auth_OnResponseReceivedEvent;
            //a local HTTP Server will be started (Needed for the response)
            auth.StartHttpServer();
            //This will open the spotify auth-page. The user can decline/accept the request
            auth.DoAuth();

            
            return Redirect(parsedUrl);
        }


        private static void auth_OnResponseReceivedEvent(AutorizationCodeAuthResponse response)
        {
            //Stop the HTTP Server, done.
            auth.StopHttpServer();

            //NEVER DO THIS! You would need to provide the ClientSecret.
            //You would need to do it e.g via a PHP-Script.
            Token token = auth.ExchangeAuthCode(response.Code, "05c1c7ab5fb44d74a8a37c1560cfb7bb");
            
            var spotify = new SpotifyWebAPI()
            {
                TokenType = token.TokenType,
                AccessToken = token.AccessToken
            };

            //With the token object, you can now make API calls
        }

    }
}