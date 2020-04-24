using System;
using System.Collections.Generic;

namespace RPG_game.Model
{
    public class GameStory
    {
        Dictionary<int, Location> locations = new Dictionary<int, Location>();
        public GameStory()
        {
            //10-19 Hlavní ostrov
            locations.Add(10, new Location() { Name = "Hlavní ostrov", Description = "Nacházíš se na hlavním ostrově. Zde se nachází vesnice, farma, Železné doly, les a hřbitov." });
        }
    }

    public class Location
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsLocked { get; set; }
        public List<int> Paths { get; set; }

    }


    public class Path
    {
        public int PathId { get; set; }
        public string PathDescription { get; set; }
        public int NextLocationId { get; set; }
    }
}
