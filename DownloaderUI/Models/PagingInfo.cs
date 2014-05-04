using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class PagingInfo
    {
        public int TotalMovies { get; set; }
        public int MoviesPerPage { get; set; }
        public int CurrentPage { get; set; }

        public int TotalPages
        {
            get
            {
                return (int)Math.Ceiling((decimal)TotalMovies / MoviesPerPage);
            }
        }

    }
}