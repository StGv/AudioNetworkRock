using AudioNetworkRock.Models;
using AudioNetworkRock.Repository;
using System.Collections.Generic;
using System.Linq;

namespace AudioNetworkRock.Services
{
    public class RockService : IRockService
    {
        private readonly IRepository<Track> _tracks;
        private readonly IRepository<Composer> _composers;

        public RockService(IRepository<Track> tracks, IRepository<Composer> composers)
        {
            _tracks = tracks;
            _composers = composers;
        }

        public IEnumerable<TrackWithComposerName> GetTracksWithComposernames(Genre genre)
        {
            var joinTracksAndComposers =
                from track in _tracks.GetAll()
                join composer in _composers.GetAll() on track.ComposerId equals composer.ID into composerGroup
                from c in composerGroup.DefaultIfEmpty()
                where track.Genre.Equals(genre.toString())
                orderby track.Title ascending
                select new TrackWithComposerName
                {
                    Id = track.ID,
                    Title = track.Title,
                    Genre = track.Genre,
                    ComposerName = 
                        c == null
                        ? string.Empty
                        : string.Join(" ", c.FirstName, c.LastName)
                };

            return joinTracksAndComposers.ToList();
        }

    }
}