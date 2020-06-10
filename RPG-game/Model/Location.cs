using System;
using System.Collections.Generic;

namespace RPG_game.Model
{
    public class Location
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Path> Paths { get; set; }
        public LocationPath PathToLock { get; set; }
        public LocationPath PathToUnlock { get; set; }
        public List<LocationPath> PathsToUnlock { get; set; }
        public bool LevelUp { get; set; }
        public List<RedirectPath> RedirectPaths { get; set; }
        public Person Person { get; set; }
        public bool DateAllowed { get; set; }
        public bool DateCountUp { get; set; }
        public bool SuccessfulDateCountUp { get; set; }
        public int Cost { get; set; }
        public bool Coffee { get; set; }
        public bool Hairstyle {get;set;}
        public bool Cinema { get; set; }
        public bool Museum { get; set; }
        public bool Picnic { get; set; }
        public bool DateRejected { get; set; }
    }

}
