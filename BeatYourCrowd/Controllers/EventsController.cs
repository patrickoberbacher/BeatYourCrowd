using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BeatYourCrowd.Models;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Models;
using SpotifyAPI.Web.Enums;

namespace BeatYourCrowd.Controllers
{
    public class EventsController : Controller
    {

        private SpotifyWebAPI _spotify = new SpotifyWebAPI()
        {
            UseAuth = false, //This will disable Authentication.
        };


        // GET: Events
        public ActionResult Search(string search)
        {
            ViewBag.Message = "BeatYourCrowd!";

            SearchItem item = _spotify.SearchItems(search, SearchType.Artist | SearchType.Album | SearchType.Track, 5);

            return View(item);
        }
    }
}