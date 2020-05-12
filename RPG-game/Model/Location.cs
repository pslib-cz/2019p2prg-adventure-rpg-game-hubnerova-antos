using System;
using System.Collections.Generic;

namespace RPG_game.Model
{
    public class Location
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsLocked { get; set; }
        public List<Path> Paths { get; set; }
    }
}
