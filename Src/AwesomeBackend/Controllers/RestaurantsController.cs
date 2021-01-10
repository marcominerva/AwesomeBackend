using AwesomeBackend.BusinessLayer.Services;
using AwesomeBackend.Shared.Models.Requests;
using AwesomeBackend.Shared.Models.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AwesomeBackend.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    public class RestaurantsController : ControllerBase
    {
        private readonly IRestaurantsService restaurantsService;
        private readonly IRatingsService ratingsService;

        public RestaurantsController(IRestaurantsService restaurantsService, IRatingsService ratingsService)
        {
            this.restaurantsService = restaurantsService;
            this.ratingsService = ratingsService;
        }

        /// <summary>
        /// Get the paginated restaurants list
        /// </summary>
        /// <param name="pageIndex">The index of the page to get</param>
        /// <param name="itemsPerPage">The number of elements to get</param>
        /// <response code="200">The restaurants list</response>
        /// <response code="401">Unauthorized user</response>
        [HttpGet("")]
        [ProducesResponseType(typeof(ListResult<Restaurant>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<ListResult<Restaurant>>> GetRestaurantsList([FromQuery(Name = "page")] int pageIndex = 0,
                                                                                   [FromQuery(Name = "size")] int itemsPerPage = 20)
        {
            var restaurants = await restaurantsService.GetAsync(pageIndex, itemsPerPage);
            return restaurants;
        }

        /// <summary>
        /// Get a specific restaurant
        /// </summary>
        /// <param name="id">Id of the restaurant to retrieve</param>
        /// <response code="200">The desired restaurant</response>
        /// <response code="401">Unauthorized user</response>
        /// <response code="404">Restaurant not found</response>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(Restaurant), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Restaurant>> GetRestaurant(Guid id)
        {
            var restaurants = await restaurantsService.GetAsync(id);
            if (restaurants != null)
            {
                return restaurants;
            }

            return NotFound();
        }

        /// <summary>
        /// Get the paginated ratings of the given restaurant
        /// </summary>
        /// <param name="restaurantId">Id of the restaurant</param>
        /// <param name="pageIndex">The index of the page to get</param>
        /// <param name="itemsPerPage">The number of elements to get</param>
        /// <response code="200">The ratings list of the restaurant</response>
        /// <response code="401">Unauthorized user</response>
        [HttpGet("{id:guid}/ratings")]
        [ProducesResponseType(typeof(ListResult<Rating>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<ListResult<Rating>>> GetRatingsList([FromRoute(Name = "id")] Guid restaurantId,
                                                                           [FromQuery(Name = "page")] int pageIndex = 0,
                                                                           [FromQuery(Name = "size")] int itemsPerPage = 20)
        {
            var ratings = await ratingsService.GetAsync(restaurantId, pageIndex, itemsPerPage);
            return ratings;
        }

        /// <summary>
        /// Send a new rating for a restaurant
        /// </summary>
        /// <param name="restaurantId">Id of the restaurant to rate</param>
        /// <param name="rating">The rating to submit</param>
        /// <response code="200">Rating submitted successfully</response>
        /// <response code="400">Unable to submit the rating because of an error of input data</response>
        /// <response code="401">Unauthorized user</response>
        [HttpPost("{id:guid}/ratings")]
        [ProducesResponseType(typeof(NewRating), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<NewRating>> Rate([FromRoute(Name = "id")] Guid restaurantId, RatingRequest rating)
        {
            var result = await ratingsService.RateAsync(restaurantId, rating.Score, rating.Comment);
            return result;
        }

        /// <summary>
        /// Send a new rating for a restaurant
        /// </summary>
        /// <param name="restaurantId">Id of the restaurant to rate</param>
        /// <param name="rating">The rating to submit</param>
        /// <response code="200">Rating submitted successfully</response>
        /// <response code="400">Unable to submit the rating because of an error of input data</response>
        /// <response code="401">Unauthorized user</response>
        [HttpPost("{id:guid}/ratings")]
        [ProducesResponseType(typeof(NewRating), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        [ApiVersion("2.0")]
        public async Task<ActionResult<NewRating>> RateV2([FromRoute(Name = "id")] Guid restaurantId, Shared.Models.Requests.V2.RatingRequest rating)
        {
            var result = await ratingsService.RateAsync(restaurantId, rating.Score, rating.Comment);
            return result;
        }
    }
}
