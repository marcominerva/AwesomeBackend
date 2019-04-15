using AwesomeBackend.Authentication.Extensions;
using AwesomeBackend.BusinessLayer.Models;
using AwesomeBackend.BusinessLayer.Services.Common;
using AwesomeBackend.DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal = AwesomeBackend.DataAccessLayer.Models;

namespace AwesomeBackend.BusinessLayer.Services
{
    public class RestaurantsService : BaseService, IRestaurantsService
    {
        public RestaurantsService(IApplicationDbContext dataContext, IHttpContextAccessor httpContextAccessor, IServiceProvider serviceProvider)
            : base(dataContext, httpContextAccessor, serviceProvider)
        {
        }

        public async Task<Restaurant> GetAsync(Guid id)
        {
            var dbRestaurant = await DataContext.GetData<Dal.Restaurant>().Include(r => r.Ratings).FirstOrDefaultAsync(v => v.Id == id);
            if (dbRestaurant != null)
            {
                var restaurant = CreateRestaurantDto(dbRestaurant);
                return restaurant;
            }

            return null;
        }

        public async Task<ListResult<Restaurant>> GetAsync(int pageIndex, int itemsPerPage)
        {
            var query = DataContext.GetData<Dal.Restaurant>();
            var totalCount = await query.LongCountAsync();

            var data = await query.Include(r => r.Ratings)
                .OrderBy(s => s.Name)
                .Skip(pageIndex * itemsPerPage).Take(itemsPerPage + 1)      // Prova a prendere un elemento in più di quelli richiesti per controllare se ci sono pagine successive.
                .Select(dbRestaurant => CreateRestaurantDto(dbRestaurant))
                .ToListAsync();

            return new ListResult<Restaurant>(data.Take(itemsPerPage), totalCount, data.Count > itemsPerPage);
        }

        private Restaurant CreateRestaurantDto(Dal.Restaurant dbRestaurant)
            => new Restaurant
                {
                    Id = dbRestaurant.Id,
                    Name = dbRestaurant.Name,
                    Address = new Address
                    {
                        Location = dbRestaurant.Address.Location,
                        PostalCode = dbRestaurant.Address.PostalCode,
                        Province = dbRestaurant.Address.Province,
                        Street = dbRestaurant.Address.Street
                    },
                    Email = dbRestaurant.Email,
                    ImageUrl = dbRestaurant.ImageUrl,
                    PhoneNumber = dbRestaurant.PhoneNumber,
                    WebSite = dbRestaurant.WebSite,
                    RatingsCount = dbRestaurant.Ratings.Count,
                    RatingScore = Math.Round(dbRestaurant.Ratings.Select(r => r.Score).DefaultIfEmpty(0).Average(), 2)
                };
    }
}
