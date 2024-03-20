using Ludotheque.EvenementLocation.Services;
using Ludotheque.EvenementLocation.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ludotheque.EvenementLocation.Controllers
{
    [Route("evenement/[controller]")]
    [ApiController]
    public class EvenementController : ControllerBase
    {
        private IEvenementService EvenementService { get; set; }

        public EvenementController(IEvenementService evenementService)
        {
            EvenementService = evenementService;
        }

        // GET: evenement/<EvenementController>/5
        [HttpGet("{eventId}")]
        public async Task<List<Evenement?>> Get(string EventId)
        {
            return await EvenementService.GetEvenement(EventId);
        }

        // POST evenement/<EvenementController>
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
