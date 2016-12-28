using CoreApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.ViewModels
{
    public class RestaurantEditView
    {
        public string Name { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}
