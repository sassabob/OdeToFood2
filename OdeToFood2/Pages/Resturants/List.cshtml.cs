using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood2.Pages.Resturants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration _configuration;
        private readonly IRestaurantData _restarurantData;
        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        public ListModel(IConfiguration configuration, IRestaurantData restarurantData)
        {
            _configuration = configuration;
            _restarurantData = restarurantData;
        }
        public void OnGet()
        {
            
            Message = _configuration["Message"];
            Restaurants = _restarurantData.GetRestaurantsByName(SearchTerm); 
        }
    }
}