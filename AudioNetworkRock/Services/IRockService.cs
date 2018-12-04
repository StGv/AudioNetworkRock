using AudioNetworkRock.Models;
using System.Collections.Generic;

namespace AudioNetworkRock.Services
{
    public interface IRockService
    {
        IEnumerable<TrackWithComposerName> GetTracksWithComposerNames(Genre genre);
    }
}