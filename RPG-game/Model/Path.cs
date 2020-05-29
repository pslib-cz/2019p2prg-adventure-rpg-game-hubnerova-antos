using System;
using System.Collections.Generic;

namespace RPG_game.Model
{
    public class Path
    {
        private static readonly Random _random = new Random();
        private readonly List<int> _locationIds = new List<int>();
        public int PathId { get; set; }
        public string PathDescription { get; set; }
        public bool IsLocked { get; set; }

        public int[] NextLocationIds { 
            set {
                _locationIds.AddRange(value);
            } 
        }
        public int NextLocationId { 
            get {
                return GetRandom(_locationIds);
            }
            set {
                _locationIds.Clear();
                _locationIds.Add(value);
            } 
        }

        public string NextPage { get; set; }
        public bool Random { get; set; }
        public Path ()
        {
            NextPage = "Pages";
        }

        private static int GetRandom(List<int> numbers)
        {
            if (numbers.Count == 0) return 0;
            int start = _random.Next(0, numbers.Count);
            return numbers[start];
        }
    }
}
