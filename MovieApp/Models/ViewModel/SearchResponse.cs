using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieApp.Models.ViewModel
{
    public class SearchResponse
    {
        public List<MovieAttributes> Search { get; set; } = new List<MovieAttributes>();
    }
    public class MovieAttributes
    {
        public string imdbID { get; set; }
        public string Year { get; set; }
        public string Type { get; set; }

        public string Poster { get; set; }
        public string Title { get; set; }

    }
}