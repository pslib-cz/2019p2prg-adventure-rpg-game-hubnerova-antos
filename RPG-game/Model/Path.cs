using System;
namespace RPG_game.Model
{
    public class Path
    {
        public int PathId { get; set; }
        public string PathDescription { get; set; }
        public bool IsLocked { get; set; }
        public int NextLocationId { get; set; }
    }
}
