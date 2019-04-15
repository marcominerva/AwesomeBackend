using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AwesomeBackend.BusinessLayer.Models;

namespace AwesomeBackend.BusinessLayer.Services
{
    public interface IRestaurantsService
    {
        Task<Restaurant> GetAsync(Guid id);

        Task<ListResult<Restaurant>> GetAsync(int pageIndex, int itemsPerPage);
    }
}