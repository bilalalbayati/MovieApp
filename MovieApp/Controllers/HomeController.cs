using MovieApp.Models.ViewModel;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using MovieApp.Models;

namespace MovieApp.Controllers
{
    public class HomeController : Controller
    {
        MovieDBEntities db = new MovieDBEntities();
        public ActionResult Index()
        {
            //if (TempData["responseString"] != null)
            //{
            //    model = JsonConvert.DeserializeObject<SearchResponse>(TempData["responseString"].ToString());
            //}
            //var responseString = "{\r\n\"Search\":\r\n[{\"Title\":\"Harry Potter and the Deathly Hallows: Part 2\",\r\n\"Year\":\"2011\",\r\n\"imdbID\":\"tt1201607\",\r\n\"Type\":\"movie\",\r\n\"Poster\":\"https://m.media-amazon.com/images/M/MV5BMGVmMWNiMDktYjQ0Mi00MWIxLTk0N2UtN2ZlYTdkN2IzNDNlXkEyXkFqcGdeQXVyODE5NzE3OTE@._V1_SX300.jpg\"},\r\n{\"Title\":\"Harry Potter and the Sorcerer's Stone\",\"Year\":\"2001\",\"imdbID\":\"tt0241527\",\"Type\":\"movie\",\"Poster\":\"https://m.media-amazon.com/images/M/MV5BNmQ0ODBhMjUtNDRhOC00MGQzLTk5MTAtZDliODg5NmU5MjZhXkEyXkFqcGdeQXVyNDUyOTg3Njg@._V1_SX300.jpg\"},{\"Title\":\"Harry Potter and the Chamber of Secrets\",\"Year\":\"2002\",\"imdbID\":\"tt0295297\",\"Type\":\"movie\",\"Poster\":\"https://m.media-amazon.com/images/M/MV5BMjE0YjUzNDUtMjc5OS00MTU3LTgxMmUtODhkOThkMzdjNWI4XkEyXkFqcGdeQXVyMTA3MzQ4MTc0._V1_SX300.jpg\"},{\"Title\":\"Harry Potter and the Prisoner of Azkaban\",\"Year\":\"2004\",\"imdbID\":\"tt0304141\",\"Type\":\"movie\",\"Poster\":\"https://m.media-amazon.com/images/M/MV5BMTY4NTIwODg0N15BMl5BanBnXkFtZTcwOTc0MjEzMw@@._V1_SX300.jpg\"},{\"Title\":\"Harry Potter and the Goblet of Fire\",\"Year\":\"2005\",\"imdbID\":\"tt0330373\",\"Type\":\"movie\",\"Poster\":\"https://m.media-amazon.com/images/M/MV5BMTI1NDMyMjExOF5BMl5BanBnXkFtZTcwOTc4MjQzMQ@@._V1_SX300.jpg\"},{\"Title\":\"Harry Potter and the Order of the Phoenix\",\"Year\":\"2007\",\"imdbID\":\"tt0373889\",\"Type\":\"movie\",\"Poster\":\"https://m.media-amazon.com/images/M/MV5BOTA3MmRmZDgtOWU1Ny00ZDc5LWFkN2YtNzNlY2UxZmY0N2IyXkEyXkFqcGdeQXVyNTIzOTk5ODM@._V1_SX300.jpg\"},{\"Title\":\"Harry Potter and the Deathly Hallows: Part 1\",\"Year\":\"2010\",\"imdbID\":\"tt0926084\",\"Type\":\"movie\",\"Poster\":\"https://m.media-amazon.com/images/M/MV5BMTQ2OTE1Mjk0N15BMl5BanBnXkFtZTcwODE3MDAwNA@@._V1_SX300.jpg\"},{\"Title\":\"Harry Potter and the Half-Blood Prince\",\"Year\":\"2009\",\"imdbID\":\"tt0417741\",\"Type\":\"movie\",\"Poster\":\"https://m.media-amazon.com/images/M/MV5BNzU3NDg4NTAyNV5BMl5BanBnXkFtZTcwOTg2ODg1Mg@@._V1_SX300.jpg\"},{\"Title\":\"When Harry Met Sally...\",\"Year\":\"1989\",\"imdbID\":\"tt0098635\",\"Type\":\"movie\",\"Poster\":\"https://m.media-amazon.com/images/M/MV5BMjE0ODEwNjM2NF5BMl5BanBnXkFtZTcwMjU2Mzg3NA@@._V1_SX300.jpg\"},{\"Title\":\"Dirty Harry\",\"Year\":\"1971\",\"imdbID\":\"tt0066999\",\"Type\":\"movie\",\"Poster\":\"https://m.media-amazon.com/images/M/MV5BMzdhMTM2YTItOWU2YS00MTM0LTgyNDYtMDM1OWM3NzkzNTM2XkEyXkFqcGdeQXVyNjc1NTYyMjg@._V1_SX300.jpg\"}],\"totalResults\":\"844\",\"Response\":\"True\"}";
            //model = JsonConvert.DeserializeObject<SearchResponse>(responseString);
            return View();
        }
        [HttpPost]
        public string CallIMDBApi(string searchText)
        {
            string url = "http://www.omdbapi.com/?s=" + searchText + "&apikey=65dc8100";
            string responseString = string.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Stream responseStream = response.GetResponseStream();
            StreamReader sr = new StreamReader(responseStream);
            responseString = sr.ReadToEnd();
            //responseString = "{\r\n\"Search\":\r\n[{\"Title\":\"Harry Potter and the Deathly Hallows: Part 2\",\r\n\"Year\":\"2011\",\r\n\"imdbID\":\"tt1201607\",\r\n\"Type\":\"movie\",\r\n\"Poster\":\"https://m.media-amazon.com/images/M/MV5BMGVmMWNiMDktYjQ0Mi00MWIxLTk0N2UtN2ZlYTdkN2IzNDNlXkEyXkFqcGdeQXVyODE5NzE3OTE@._V1_SX300.jpg\"},\r\n{\"Title\":\"Harry Potter and the Sorcerer's Stone\",\"Year\":\"2001\",\"imdbID\":\"tt0241527\",\"Type\":\"movie\",\"Poster\":\"https://m.media-amazon.com/images/M/MV5BNmQ0ODBhMjUtNDRhOC00MGQzLTk5MTAtZDliODg5NmU5MjZhXkEyXkFqcGdeQXVyNDUyOTg3Njg@._V1_SX300.jpg\"},{\"Title\":\"Harry Potter and the Chamber of Secrets\",\"Year\":\"2002\",\"imdbID\":\"tt0295297\",\"Type\":\"movie\",\"Poster\":\"https://m.media-amazon.com/images/M/MV5BMjE0YjUzNDUtMjc5OS00MTU3LTgxMmUtODhkOThkMzdjNWI4XkEyXkFqcGdeQXVyMTA3MzQ4MTc0._V1_SX300.jpg\"},{\"Title\":\"Harry Potter and the Prisoner of Azkaban\",\"Year\":\"2004\",\"imdbID\":\"tt0304141\",\"Type\":\"movie\",\"Poster\":\"https://m.media-amazon.com/images/M/MV5BMTY4NTIwODg0N15BMl5BanBnXkFtZTcwOTc0MjEzMw@@._V1_SX300.jpg\"},{\"Title\":\"Harry Potter and the Goblet of Fire\",\"Year\":\"2005\",\"imdbID\":\"tt0330373\",\"Type\":\"movie\",\"Poster\":\"https://m.media-amazon.com/images/M/MV5BMTI1NDMyMjExOF5BMl5BanBnXkFtZTcwOTc4MjQzMQ@@._V1_SX300.jpg\"},{\"Title\":\"Harry Potter and the Order of the Phoenix\",\"Year\":\"2007\",\"imdbID\":\"tt0373889\",\"Type\":\"movie\",\"Poster\":\"https://m.media-amazon.com/images/M/MV5BOTA3MmRmZDgtOWU1Ny00ZDc5LWFkN2YtNzNlY2UxZmY0N2IyXkEyXkFqcGdeQXVyNTIzOTk5ODM@._V1_SX300.jpg\"},{\"Title\":\"Harry Potter and the Deathly Hallows: Part 1\",\"Year\":\"2010\",\"imdbID\":\"tt0926084\",\"Type\":\"movie\",\"Poster\":\"https://m.media-amazon.com/images/M/MV5BMTQ2OTE1Mjk0N15BMl5BanBnXkFtZTcwODE3MDAwNA@@._V1_SX300.jpg\"},{\"Title\":\"Harry Potter and the Half-Blood Prince\",\"Year\":\"2009\",\"imdbID\":\"tt0417741\",\"Type\":\"movie\",\"Poster\":\"https://m.media-amazon.com/images/M/MV5BNzU3NDg4NTAyNV5BMl5BanBnXkFtZTcwOTg2ODg1Mg@@._V1_SX300.jpg\"},{\"Title\":\"When Harry Met Sally...\",\"Year\":\"1989\",\"imdbID\":\"tt0098635\",\"Type\":\"movie\",\"Poster\":\"https://m.media-amazon.com/images/M/MV5BMjE0ODEwNjM2NF5BMl5BanBnXkFtZTcwMjU2Mzg3NA@@._V1_SX300.jpg\"},{\"Title\":\"Dirty Harry\",\"Year\":\"1971\",\"imdbID\":\"tt0066999\",\"Type\":\"movie\",\"Poster\":\"https://m.media-amazon.com/images/M/MV5BMzdhMTM2YTItOWU2YS00MTM0LTgyNDYtMDM1OWM3NzkzNTM2XkEyXkFqcGdeQXVyNjc1NTYyMjg@._V1_SX300.jpg\"}],\"totalResults\":\"844\",\"Response\":\"True\"}";
            //var model = JsonConvert.DeserializeObject<SearchResponse>(responseString);
            //return Index(model);

            return responseString;
        }

        public ActionResult Details(string imdbID)
        {
            string url = "http://www.omdbapi.com/?i=" + imdbID + "&apikey=65dc8100";
            string responseString = string.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Stream responseStream = response.GetResponseStream();
            StreamReader sr = new StreamReader(responseStream);
            responseString = sr.ReadToEnd();
            //responseString = "{\r\n\"Title\":\"Harry Potter and the Deathly Hallows: Part 2\",\r\n\"Year\":\"2011\",\"Rated\":\"PG-13\",\"Released\":\"15 Jul 2011\",\"Runtime\":\"130 min\",\r\n\"Genre\":\"Adventure, Family, Fantasy\",\"Director\":\"David Yates\",\r\n\"Writer\":\"Steve Kloves, J.K. Rowling\",\r\n\"Actors\":\"Daniel Radcliffe, Emma Watson, Rupert Grint\",\r\n\"Plot\":\"Harry, Ron, and Hermione search for Voldemort's remaining Horcruxes in their effort to destroy the Dark Lord as \r\nthe final battle rages on at Hogwarts.\",\r\n\"Language\":\"English, Latin\",\"Country\":\"United Kingdom, United States\",\r\n\"Awards\":\"Nominated for 3 Oscars. 47 wins & 94 nominations total\",\"Poster\":\"https://m.media-amazon.com/images/M/MV5BMGVmMWNiMDktYjQ0Mi00MWIxLTk0N2UtN2ZlYTdkN2IzNDNlXkEyXkFqcGdeQXVyODE5NzE3OTE@._V1_SX300.jpg\",\"Ratings\":[{\"Source\":\"Internet Movie Database\",\"Value\":\"8.1/10\"},{\"Source\":\"Rotten Tomatoes\",\"Value\":\"96%\"},{\"Source\":\"Metacritic\",\"Value\":\"85/100\"}],\"Metascore\":\"85\",\"imdbRating\":\"8.1\",\"imdbVotes\":\"888,046\",\"imdbID\":\"tt1201607\",\"Type\":\"movie\",\"DVD\":\"11 Nov 2011\",\"BoxOffice\":\"$381,447,587\",\"Production\":\"N/A\",\"Website\":\"N/A\",\"Response\":\"True\"}";
            var model = JsonConvert.DeserializeObject<DetailResponse>(responseString);
            return View(model);
        }

        public ActionResult Favourite(FavouriteModel model)
        {
            if (model.Actors != null)
            {
                FavouriteMovie obj = new FavouriteMovie();
                obj.Poster = model.Poster;
                obj.Plot = model.Plot;
                obj.Title = model.Title;
                obj.Actors = model.Actors;
                obj.Genre = model.Genre;
                obj.Year = model.Year;
                obj.CreatedDate = DateTime.Now;
                obj.ImdbID = model.ImdbID;

                db.FavouriteMovies.Add(obj);
                db.SaveChanges();
            }
            return View();
        }

        public string GetFavouriteMovies()
        {
            var list = db.FavouriteMovies.ToList();
            return JsonConvert.SerializeObject(list);
        }
        public bool RemoveFromFavourites(int id)
        {
            bool success = false;
            try
            {
                var movie = db.FavouriteMovies.FirstOrDefault(x => x.ID == id);
                db.FavouriteMovies.Remove(movie);
                db.SaveChanges();
                success = true;
            }
            catch (Exception ex)
            {
                throw;
            }
            return success;
        }
        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}