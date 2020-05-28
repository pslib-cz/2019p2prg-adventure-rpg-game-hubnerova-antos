using System;
using System.Collections.Generic;

namespace RPG_game.Model
{
    public class Stats
    {
        //public GenderMode PreferedGender { get; set; }
        //public string Name { get; }
        public int DateCount { get; set; }
        public int SuccessfulDateCount { get; set; }
        public int Level { get; set; }
        public Dictionary<String, Person> Acquaintances = new Dictionary<String, Person>();

        public Stats()
        {
            //Acquaintances.Add(new Person() { Name = "Dina Veselá", Age = 30, LocationId = 200});
        }
        //public int RelationshipLevel { get; set; }
        //public int IntelligenceLevel { get; set; }
        //public int CreativityLevel { get; set; }
        //public int HumorLevel { get; set; }
        //public int AttractionLevel { get; set; }
    }
}
