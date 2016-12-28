using System;
using System.Collections.Generic;
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
        public string Name { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}
