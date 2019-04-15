using AwesomeBackend.BusinessLayer.Models;
using AwesomeBackend.BusinessLayer.Services;
using AwesomeBackend.Models.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AwesomeBackend.Controllers
{
    [Authorize]
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
        /// Recupera i ristoranti, con possibilità di ottenerli in maniera paginata
        /// </summary>
        /// <param name="pageIndex">L'indice dell pagina da ottenere</param>
        /// <param name="itemsPerPage">Il numero di elementi ottenere</param>
        /// <response code="200">L'elenco dei ristoranti</response>
        /// <response code="401">Utente non autorizzato</response>
        [HttpGet]
        [Route("")]
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
        /// Recupera uno specifico ristorante
        /// </summary>
        /// <param name="id">Id del ristorante da recuperare</param>
        /// <response code="200">Il ristorante cercato</response>
        /// <response code="401">Utente non autorizzato</response>
        /// <response code="404">Ristorante non trovato</response>
        [HttpGet]
        [Route("{id}")]
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
        /// Recupera i rating del ristorante specificato, con possibilità di ottenerli in maniera paginata
        /// </summary>
        /// <param name="restaurantId">L'Id del ristorante</param>
        /// <param name="pageIndex">L'indice dell pagina da ottenere</param>
        /// <param name="itemsPerPage">Il numero di elementi ottenere</param>
        /// <response code="200">L'elenco delle valutazioni del ristorante</response>
        /// <response code="401">Utente non autorizzato</response>
        [HttpGet]
        [Route("{id:guid}/ratings")]
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
        /// Invia una nuova valutazione del ristorante specificato
        /// </summary>
        /// <param name="restaurantId">L'Id del ristorante di cui si vuole effettuare la valutazione</param>
        /// <param name="rating">L'oggetto che contiene le informazioni sul rating</param>
        /// <response code="200">Il rating è stato salvato correttamente</response>
        /// <response code="400">Impossibile salvare a causa di un errore dei dati di input</response>
        /// <response code="401">Utente non autorizzato</response>
        [HttpPost]
        [Route("{id:guid}/ratings")]
        [ProducesResponseType(typeof(NewRating), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<NewRating>> Rate([FromRoute(Name = "id")] Guid restaurantId, RatingRequest rating)
        {
            var result = await ratingsService.RateAsync(restaurantId, rating.Score, rating.Comment);
            return result;
        }
    }
}
