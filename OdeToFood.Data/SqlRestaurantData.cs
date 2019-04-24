using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;
using Remotion.Linq.Clauses;

namespace OdeToFood.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly OdeToFoodDbContext _db;

        public SqlRestaurantData(OdeToFoodDbContext db)
        {
            _db = db;
        }
        public Restaurant Add(Restaurant newRestaurant)
        {
            var state =_db.Add(newRestaurant);
            return newRestaurant;
        }

        public int Commit()
        {
            return _db.SaveChanges(); //no of rows...
        }

        public Restaurant Delete(int id)
        {
            var restaurant = GetById(id);
            if (restaurant!=null)
            {
                //_db.Remove(restaurant); //???
                _db.Restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public Restaurant GetById(int id)
        {
            var restaurant = _db.Restaurants.Find(id);
            return restaurant;
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            var query = from r in _db.Restaurants
                where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                orderby r.Name
                select r;
            return query;
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var entity = _db.Restaurants.Attach(updatedRestaurant);
            entity.State = EntityState.Modified;
            return updatedRestaurant;
        }
    }
}