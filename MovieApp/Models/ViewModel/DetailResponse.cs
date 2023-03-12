﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieApp.Models.ViewModel
{
    public class DetailResponse
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string Plot { get; set; }
        public string Genre { get; set; }
        public string Poster { get; set; }
        public string Actors { get; set; }

    }
}