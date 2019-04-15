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
                .Skip(pageIndex * itemsPerPage).Take(itemsPerPage + 1)      // Prova a prendere un elemento in più di quelli richiesti per controllare se ci sono pagine successive.
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
            // Salva la valutazione sul database.
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

            // Recupera la nuova media dei voti del ristorante.
            var averageScore = DataContext.GetData<Dal.Rating>().Where(r => r.RestaurantId == restaurantId).Average(r => r.Score);
            var result = new NewRating(restaurantId, Math.Round(averageScore, 2));
            return result;
        }
    }
}
