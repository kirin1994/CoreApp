﻿using CoreApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Services
{
    public interface IRestaurantData {
        IEnumerable<Restaurant> GetAll();
        Restaurant Get(int id);
        Restaurant Add(Restaurant newRestaurant);
    }
    public class InMemoryRestaurantData : IRestaurantData {

        public InMemoryRestaurantData() {
            _restaurants = new List<Restaurant> {
                new Restaurant {Id = 1, Name="The House of Kobe" },
                new Restaurant {Id = 2, Name="LJ's abd the Kat" },
                new Restaurant {Id = 3, Name ="King" }
            };
        }
        public IEnumerable<Restaurant> GetAll() {
            return _restaurants;
        }
        public Restaurant Get(int id) {
            return _restaurants.FirstOrDefault(r => r.Id == id);
        }
        public Restaurant Add(Restaurant newRestaurant) {
            newRestaurant.Id = _restaurants.Max(r => r.Id) + 1;
            _restaurants.Add(newRestaurant);

            return newRestaurant;
        }
        List<Restaurant> _restaurants;
    }
}
