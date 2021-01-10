using AwesomeBackend.BusinessLayer.Services.Common;
using AwesomeBackend.Shared.Models.Responses;
using AwesomeBackend.DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using Entities = AwesomeBackend.DataAccessLayer.Entities;

namespace AwesomeBackend.BusinessLayer.Services
{
    public class RestaurantsService : BaseService, IRestaurantsService
    {
        public RestaurantsService(IApplicationDbContext dataContext, IHttpContextAccessor httpContextAccessor, ILogger<RestaurantsService> logger, IServiceProvider serviceProvider)
            : base(dataContext, httpContextAccessor, logger, serviceProvider)
        {
        }

        public async Task<Restaurant> GetAsync(Guid id)
        {
            var dbRestaurant = await DataContext.GetData<Entities.Restaurant>().Include(r => r.Ratings).FirstOrDefaultAsync(v => v.Id == id);
            if (dbRestaurant == null)
            {
                Logger.LogInformation("Unable to find restaurant with Id {RestaturantId}", id);
                return null;
            }

            var restaurant = CreateRestaurantDto(dbRestaurant);
            return restaurant;
        }

        public async Task<ListResult<Restaurant>> GetAsync(int pageIndex, int itemsPerPage)
        {
            Logger.LogDebug("Trying to retrieve {ItemsCount} restaurants...", itemsPerPage);

            var query = DataContext.GetData<Entities.Restaurant>();
            var totalCount = await query.LongCountAsync();

            Logger.LogDebug("Found {ItemsCounts} restaurants", totalCount);

            var data = await query.Include(r => r.Ratings)
                .OrderBy(r => r.Name)
                //.OrderByDescending(r => r.Ratings.Select(rating => rating.Score).DefaultIfEmpty(0).Average())
                .Skip(pageIndex * itemsPerPage).Take(itemsPerPage + 1)      // Try to retrieve an element more than the requested number to check whether there are more data.
                .Select(dbRestaurant => CreateRestaurantDto(dbRestaurant))
                .ToListAsync();

            return new ListResult<Restaurant>(data.Take(itemsPerPage), totalCount, data.Count > itemsPerPage);
        }

        private static Restaurant CreateRestaurantDto(Entities.Restaurant dbRestaurant)
        {
            return new Restaurant
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
}
