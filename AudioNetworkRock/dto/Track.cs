using AudioNetworkRock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AudioNetworkRock.dto
{
    public class Track
    {
        public int ID;
        public string Title;
        public int ComoiserId;
        public Genre genre;
    }
}