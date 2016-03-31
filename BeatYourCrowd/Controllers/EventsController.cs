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

            //Search eins = new Search();
            //eins.value = "Hello BYC!";

            //Search zwei = new Search();
            //zwei.value = search;

            //List<Search> textList = new List<Search>();
            //textList.Add(eins);
            //textList.Add(zwei);

            ////return Redirect("/Player/Search");
            //return View(textList);

            SearchItem item = _spotify.SearchItems(search, SearchType.Artist | SearchType.Album | SearchType.Track, 10);

            return View(item);
        }
    }
}