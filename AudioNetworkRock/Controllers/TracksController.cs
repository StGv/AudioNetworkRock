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
        IRepository<Track> _tracks;
        IRepository<Composer> _composers;

        public TracksController(IRepository<Track> tracks, IRepository<Composer> composers)
        {
            _tracks = tracks;
            _composers = composers;
        }

        [Route("genre/{genre}")]
        [HttpGet]
        public IHttpActionResult Get([FromUri]string genre)
        {
            var joinTracksAndComposers = 
                from track in _tracks.GetAll()
                join composer in _composers.GetAll() on track.ComoiserId equals composer.ID
                //where track.Genre.Equals(Genre.Rock.toString())
                orderby track.Title 
                select new {
                    Id = track.ID,
                    track.Title,
                    genre = track.Genre,
                    Composer = string.Join(" ", composer.FirstName, composer.LastName)
                };

            return Ok (new { Test = true, test2=2, test3="something"});
        }

    }
}
