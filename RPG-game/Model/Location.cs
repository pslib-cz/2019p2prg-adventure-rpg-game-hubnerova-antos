﻿using System;
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
    }
}
