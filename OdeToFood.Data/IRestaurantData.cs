using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetById(int id);
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        private readonly List<Restaurant> _restaurants;
        public InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>()
            {
                new Restaurant() {Id = 1, Name = "Scotts Pizza", Location = "Mary", Cuisine = Restaurant.CuisineType.Italian},
                new Restaurant() {Id = 2, Name = "La Costa", Location = "california", Cuisine = Restaurant.CuisineType.Mexican},
                new Restaurant() {Id = 3, Name = "Cinnamon Club", Location = "London", Cuisine = Restaurant.CuisineType.Italian},
            };

        }


        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from r in _restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                orderby r.Name
                select r;

        }

        public Restaurant GetById(int id)
        {
            return _restaurants.SingleOrDefault(r => r.Id == id);
        }
    }
}
