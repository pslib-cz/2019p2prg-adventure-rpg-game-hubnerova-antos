using System;
namespace RPG_game.Model
{
    public class Stats
    {
        public GenderMode PreferedGender { get; set; }
        public string Name { get; }
        public int DateCount { get; set; }
        public int RelationshipLevel { get; set; }
        public int IntelligenceLevel { get; set; }
        public int CreativityLevel { get; set; }
        public int HumorLevel { get; set; }
        public int AttractionLevel { get; set; }
    }
}
