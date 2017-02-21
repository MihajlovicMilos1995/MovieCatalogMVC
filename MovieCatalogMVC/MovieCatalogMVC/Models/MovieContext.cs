using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MovieCatalogMVC.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext() : base("MoviesDataBase")
        {
        }

        public DbSet<Movie> Movies { get; set; }
    }
}