using System;
using System.Collections.Generic;

namespace RPG_game.Model
{
    public class RedirectPath : LocationPath
    {
        public int NewNextLocationId { get; set; }

        public Dictionary<int, LocationPath > RedirectPaths{ get; set; }

    }
}
