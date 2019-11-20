﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Movies.Pages
{
    public class IndexModel : PageModel
    {

        public List<Movie> Movies;

        //similar to fact, tells the compiler that we want to bind the data
        [BindProperty]
        public string search { get; set; }

        [BindProperty]
        public List<string> mpaa { get; set; } = new List<string>();

        [BindProperty]
        public float? minIMDB { get; set; }

        [BindProperty]
        public float? maxIMDB { get; set; }

        public void OnGet()
        {
            Movies = MovieDatabase.All;
        }

        //expect some parameters concerned come in
        public void OnPost()
        {
            Movies = MovieDatabase.All;

            if(search != null)
            {
                Movies = MovieDatabase.Search(Movies, search);
            }

            if(mpaa.Count != 0)
            {
                Movies = MovieDatabase.FilterByMPAA(Movies, mpaa);
            }
            if(minIMDB != null)
            {
                Movies = MovieDatabase.FilterByMinIMDB(Movies, minIMDB);
            }

            /*
            if (search != null && rating.Count != 0)
            {
                Movies = movieDatabase.SearchAndFilter(search, rating);
            }
            else if (rating.Count != 0)
            {

                Movies = movieDatabase.Filter(rating);
            }
            else if (search != null)
            {
                Movies = movieDatabase.Search(search);
            }
            else
            {
                Movies = movieDatabase.All;
            }
            */
        }
    }
}
