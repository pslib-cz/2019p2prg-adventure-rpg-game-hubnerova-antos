using System;
using System.Collections.Generic;
using RPG_game.Model;

namespace RPG_game.Services
{
    public class RpgLogic
    {
        readonly SessionStorage _sessionstorage;
        public GameStory _gamestory;

        public RpgLogic(SessionStorage session)
        {
            _sessionstorage = session;
            _gamestory = _sessionstorage.GameStory;
        }

        public Location Play()
        {
            int? id = _sessionstorage.GetLocationId();
            Location location;
            /*if (id == null || id == 0)
            {
                location = _session.GameStory.Locations[1];
            }
            else
            {
                location = _session.GameStory.Locations[id.Value];
            }*/
            location = _sessionstorage.GameStory.Locations[id.Value];
            if (location.LevelUp == true) this.LevelUp();
            if (location.DateCountUp == true) this.DateCountUp();
            if (location.PathToLock != null) this.LockPath(location.PathToLock.LocationId, location.PathToLock.PathId);
            if (location.PathToUnlock != null) this.UnlockPath(location.PathToUnlock.LocationId, location.PathToUnlock.PathId);
            if (location.Person != null) this.AddPerson(location.Person);
            if (location.DateAllowed == true)
            {
                this.RedirectPath(700, 0, _sessionstorage.GameStory.GetRandom(RandomEnum.DateSuccess));
            }
            if (location.RedirectPaths != null)
            {
                foreach (RedirectPath item in location.RedirectPaths) this.RedirectPath(item.LocationId, item.PathId, item.NewNextLocationId);
            }
            return location;
        }

        private void UnlockPath(int LocationId, int PathId)
        {
            _sessionstorage.GameStory.Locations[LocationId].Paths[PathId].IsLocked = false;
            _sessionstorage.SaveGameStory();
        }

        private void LockPath(int LocationId, int PathId)
        {
            _sessionstorage.GameStory.Locations[LocationId].Paths[PathId].IsLocked = true;
            _sessionstorage.SaveGameStory();
        }

        private void RedirectPath(int LocationId, int PathId, int NewNextLocationId)
        {
            _sessionstorage.GameStory.Locations[LocationId].Paths[PathId].NextLocationId = NewNextLocationId;
            _sessionstorage.SaveGameStory();
        }

        private void RedirectPaths (Dictionary<int, LocationPath> RedirectPaths, int NewNextLocationId)
        {
            foreach (KeyValuePair<int, LocationPath> item in RedirectPaths)
            {
                _sessionstorage.GameStory.Locations[item.Value.LocationId].Paths[item.Value.PathId].NextLocationId = NewNextLocationId;
            }
            _sessionstorage.SaveGameStory();

        }

        public Dictionary<String, Person> GetStats()
        {
            return _sessionstorage.Stats.Acquaintances;
        }

        private void AddPerson(Person person)
        {
            _sessionstorage.Stats.Acquaintances.TryAdd(person.Name, person);
            _sessionstorage.SaveStats();
        }

        //LevelCount
        private void SetLevel(int level)
        {
            _sessionstorage.Stats.Level = level;
            _sessionstorage.SaveStats();
        }

        public int GetLevel()
        {
            return _sessionstorage.Stats.Level;
        }

        private void LevelUp()
        {
            _sessionstorage.Stats.Level++;
            _sessionstorage.SaveStats();
        }

        //DateCount
        private void SetDateCount(int count)
        {
            _sessionstorage.Stats.DateCount = count;
            _sessionstorage.SaveStats();
        }

        public int GetDateCount()
        {
            return _sessionstorage.Stats.DateCount;
        }

        private void DateCountUp()
        {
            _sessionstorage.Stats.DateCount++;
            _sessionstorage.SaveStats();
        }
    }
}

