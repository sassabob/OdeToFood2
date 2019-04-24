using System.Collections.Generic;
using System.Linq;
using OdeToFood.Core;

namespace OdeToFood.Data
{
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

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = _restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if (restaurant!=null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
                restaurant.Location = updatedRestaurant.Location;
            }

            return restaurant;
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            _restaurants.Add(newRestaurant);
            newRestaurant.Id = _restaurants.Max(r => r.Id)+1;
            return newRestaurant;
        }

        public Restaurant Delete(int id)
        {
            var restaurantToDelete = _restaurants.FirstOrDefault(r => r.Id == id);
            if (restaurantToDelete!=null)
            {
                _restaurants.Remove(restaurantToDelete);
                
            }
            return restaurantToDelete;
        }

        public int Commit()
        {
            return 0;
        }
    }
}