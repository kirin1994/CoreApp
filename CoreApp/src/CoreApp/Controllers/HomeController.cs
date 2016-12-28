using CoreApp.Entities;
using CoreApp.Services;
using CoreApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Controllers
{
    public class HomeController :Controller
    {
        private IGreeter _greeter;
        private IRestaurantData _restaurantData;
        public HomeController(IRestaurantData restaurantData, IGreeter greeter) {
            _restaurantData = restaurantData;
            _greeter = greeter;
        }
        public IActionResult Index() {
            var model = new HomePageViewModel();
            model.Restaurants = _restaurantData.GetAll();
            model.CurrentMessage = _greeter.GetGreeting();

            return View(model);
        }
        public IActionResult Details(int id) {
            var model = _restaurantData.Get(id);
            if(model == null) {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Create() {
            return View();
        }
        [HttpPost]
        public IActionResult Create(RestaurantEditView model) {
            var newRestaurant = new Restaurant();
            newRestaurant.Cuisine = model.Cuisine;
            newRestaurant.Name = model.Name;

            _restaurantData.Add(newRestaurant);

            return RedirectToAction("Details",new { id = newRestaurant.Id });

        }
    }
}
