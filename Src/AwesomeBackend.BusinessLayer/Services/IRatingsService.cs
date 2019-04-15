using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AwesomeBackend.BusinessLayer.Models;

namespace AwesomeBackend.BusinessLayer.Services
{
    public interface IRatingsService
    {
        Task<ListResult<Rating>> GetAsync(Guid restaurantId, int pageIndex, int itemsPerPage);

        Task<NewRating> RateAsync(Guid restaurantId, double score, string comment);
    }
}