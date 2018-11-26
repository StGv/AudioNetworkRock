using AudioNetworkRock.Models;
using AudioNetworkRock.Services;
using System;
using System.Linq;
using System.Web.Http;

namespace AudioNetworkRock.Controllers
{
    [RoutePrefix("api/tracks")]
    public class TracksController : ApiController
    {
        IRockService _rockService;
        public TracksController(IRockService service)
        {
            _rockService = service;
        }

        [Route("genre/{genre}")]
        [HttpGet]
        public IHttpActionResult Get([FromUri]string genre)
        {
            try
            {
                var joinTracksAndComposers = _rockService
                    .GetTracksWithComposernames(GenreConverter.ConvertFrom(genre));

                if (joinTracksAndComposers.Count() > 0)
                    return Ok(joinTracksAndComposers);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                return InternalServerError();
            }

            return NotFound();
        }

    }
}
