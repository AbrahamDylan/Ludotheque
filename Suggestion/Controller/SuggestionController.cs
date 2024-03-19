using Ludotheque.Suggestion.Services;
using Ludotheque.Suggestion.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ludotheque.Suggestion.Controllers
{
    [Route("suggestion/[controller]")]
    [ApiController]
    public class SuggestionController : ControllerBase
    {
        private ISuggestionService SuggestionService { get; set; }

        public SuggestionController(ISuggestionService suggestionService)
        {
            SuggestionService = suggestionService;
        }

        // GET: question/<ProductsController>
        [HttpGet("{eventId}")]
        public async Task<List<Question>> Get(string EventId)
        {
            return await SuggestionService.GetEvenement(EventId);
        }

        // GET: response/<ProductsController>
        [HttpGet("{eventId}")]
        public async Task<List<Question>> Get(string EventId)
        {
            return await SuggestionService.GetEvenement(EventId);
        }

        // POST reponse/<ProductsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Evenement evenement)
        {
            try
            {
                var result = await EvenementService.AddEvenement(evenement);
                return Created(Url.RouteUrl("GetEvenement", new { id = result.idEvenement }), result);
            }
            catch (EvenementLocationException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Message);
            }
        }

    }
}
