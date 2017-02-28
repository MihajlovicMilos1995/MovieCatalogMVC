using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieCatalogMVC.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [ValidateDateRange]
        public DateTime ReleaseDate { get; set; }
    }
}