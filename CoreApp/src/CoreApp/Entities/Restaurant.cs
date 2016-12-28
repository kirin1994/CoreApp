using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Entities
{
    public enum CuisineType {
        None,
        italian,
        French,
        Japanese,
        American
    }
    public class Restaurant {
        public int Id { get; set; }
        [Required,MaxLength(80)]
        [Display(Name="Restaurant Name")]
        public string Name { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}
