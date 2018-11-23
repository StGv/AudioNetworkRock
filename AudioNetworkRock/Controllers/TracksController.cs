using AudioNetworkRock.Models;
using AudioNetworkRock.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AudioNetworkRock.Controllers
{
    [RoutePrefix("api/tracks")]
    public class TracksController : ApiController
    {
        TracksRepo _tracks;
        ComposersRepo _composers;

        public TracksController()
        {
            _tracks = new TracksRepo();
            _composers = new ComposersRepo();
        }

        [Route("genre/{genre}")]
        [HttpGet]
        public IHttpActionResult Get([FromUri]string genre)
        {
            var joinTracksAndComposers = 
                from track in _tracks.Tracks
                join composer in _composers.Composers on track.ComoiserId equals composer.ID
                where track.genre.Equals(Genre.Rock.toString())
                orderby track.Title 
                select new { Id = track.ID, track.Title, genre = track.genre, Composer = string.Join(" ", composer.FirstName, composer.LastName)};

            return Ok (joinTracksAndComposers);
        }
    }
}
