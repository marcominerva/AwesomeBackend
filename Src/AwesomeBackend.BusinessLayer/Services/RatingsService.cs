using AwesomeBackend.BusinessLayer.Services.Common;
using AwesomeBackend.Common.Models.Responses;
using AwesomeBackend.DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Dal = AwesomeBackend.DataAccessLayer.Models;

namespace AwesomeBackend.BusinessLayer.Services
{
    public class RatingsService : BaseService, IRatingsService
    {
        public RatingsService(IApplicationDbContext dataContext, IHttpContextAccessor httpContextAccessor, IServiceProvider serviceProvider)
            : base(dataContext, httpContextAccessor, serviceProvider)
        {
        }

        public async Task<ListResult<Rating>> GetAsync(Guid restaurantId, int pageIndex, int itemsPerPage)
        {
            var query = DataContext.GetData<Dal.Rating>().Where(r => r.RestaurantId == restaurantId);
            var totalCount = await query.LongCountAsync();

            var data = await query.Include(r => r.User)
                .OrderByDescending(s => s.Date)
                .Skip(pageIndex * itemsPerPage).Take(itemsPerPage + 1)      // Try to retrieve an element more than the requested number to check whether there are more data.
                .Select(dbRating => new Rating
                {
                    Id = dbRating.Id,
                    RatingScore = dbRating.Score,
                    Comment = dbRating.Comment,
                    Date = dbRating.Date,
                    User = $"{dbRating.User.FirstName} {dbRating.User.LastName}".Trim()
                }).ToListAsync();

            return new ListResult<Rating>(data.Take(itemsPerPage), totalCount, data.Count > itemsPerPage);
        }

        public async Task<NewRating> RateAsync(Guid restaurantId, double score, string comment)
        {
            // Saves the new rating to the database.
            var dbRating = new Dal.Rating
            {
                RestaurantId = restaurantId,
                Score = score,
                Comment = comment,
                Date = DateTime.UtcNow,
                UserId = UserId.Value
            };

            DataContext.Insert(dbRating);
            await DataContext.SaveAsync();

            // Retrieves the new average rating for the restaurant.
            var averageScore = await DataContext.GetData<Dal.Rating>().Where(r => r.RestaurantId == restaurantId).AverageAsync(r => r.Score);
            var result = new NewRating(restaurantId, Math.Round(averageScore, 2));
            return result;
        }
    }
}
