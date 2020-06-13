﻿using System;
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
        public int Spent { get; set; }
        public int MetPeople { get; set; }
        public int CoffeeCount { get; set; }
        public int MuseumCount { get; set; }
        public int HairstyleCount { get; set; }
        public int CinemaCount { get; set; }
        public int PicnicCount { get; set; }
        public int ClubCount { get; set; }
        public int MaxPeople { get; set; }

        public Dictionary<String, Person> Acquaintances = new Dictionary<String, Person>();

        public Stats()
        {
            MaxPeople = 13;
            //Acquaintances.Add(new Person() { Name = "Dina Veselá", Age = 30, LocationId = 200});
        }
        //public int RelationshipLevel { get; set; }
        //public int IntelligenceLevel { get; set; }
        //public int CreativityLevel { get; set; }
        //public int HumorLevel { get; set; }
        //public int AttractionLevel { get; set; }
    }
}
