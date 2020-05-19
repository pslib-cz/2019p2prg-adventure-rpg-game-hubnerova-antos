using System;
using System.Collections.Generic;
using RPG_game.Model;

namespace RPG_game.Services
{
    public class StatsLogic
    {
        readonly Stats _stats;

        public StatsLogic(Stats stats)
        {
            _stats = stats;
        }

        public Dictionary<String, Person> GetStats()
        {
            return _stats.Acquaintances;
        }

        public void AddPerson (Person person)
        {
            _stats.Acquaintances.TryAdd(person.Name, person);
        }

        //LevelCount
        public void SetLevel(int level)
        {
            _stats.Level = level;
        }

        public int GetLevel()
        {
            return _stats.Level;
        }

        public void LevelUp()
        {
            _stats.Level++;
        }

        //DateCount
        public void SetDateCount(int count)
        {
            _stats.DateCount = count;
        }

        public int GetDateCount()
        {
            return _stats.DateCount;
        }

        public void DateCountUp()
        {
            _stats.DateCount++;
        }
    }
}
