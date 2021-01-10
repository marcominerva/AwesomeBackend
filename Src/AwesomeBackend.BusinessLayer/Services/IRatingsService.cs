using AwesomeBackend.Shared.Models.Responses;
using System;
using System.Threading.Tasks;

namespace AwesomeBackend.BusinessLayer.Services
{
    public interface IRatingsService
    {
        Task<ListResult<Rating>> GetAsync(Guid restaurantId, int pageIndex, int itemsPerPage);

        Task<NewRating> RateAsync(Guid restaurantId, double score, string comment);
    }
}