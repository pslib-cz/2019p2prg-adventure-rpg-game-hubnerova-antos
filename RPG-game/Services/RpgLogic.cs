using System;
using System.Collections.Generic;
using RPG_game.Model;

namespace RPG_game.Services
{
    public class RpgLogic
    {
        readonly SessionStorage _session;

        public RpgLogic(SessionStorage session)
        {
            _session = session;
        }

        public Location Play()
        {
            int? id = _session.GetLocationId();
            Location location;
            if (id == null || id == 0)
            {
                location = _session.GameStory.Locations[1];
            }
            else
            {
                location = _session.GameStory.Locations[id.Value];
            }
            if (location.LevelUp == true) this.LevelUp();
            if (location.DateCountUp == true) this.DateCountUp();
            if (location.PathToLock != null) this.LockPath(location.PathToLock.LocationId, location.PathToLock.PathId);
            if (location.PathToUnlock != null) this.UnlockPath(location.PathToUnlock.LocationId, location.PathToUnlock.PathId);
            if (location.Person != null) this.AddPerson(location.Person);
            if (location.RedirectPaths != null)
            {
                foreach (RedirectPath item in location.RedirectPaths) this.RedirectPath(item.LocationId, item.PathId, item.NewNextLocationId);
            }
            return location;
        }

        public void UnlockPath(int LocationId, int PathId)
        {
            _session.GameStory.Locations[LocationId].Paths[PathId].IsLocked = false;
            _session.SaveGameStory();
        }

        public void LockPath(int LocationId, int PathId)
        {
            _session.GameStory.Locations[LocationId].Paths[PathId].IsLocked = true;
            _session.SaveGameStory();
        }

        public void RedirectPath(int LocationId, int PathId, int NewNextLocationId)
        {
            _session.GameStory.Locations[LocationId].Paths[PathId].NextLocationId = NewNextLocationId;
            _session.SaveGameStory();
        }

        public void RedirectPaths (Dictionary<int, LocationPath> RedirectPaths, int NewNextLocationId)
        {
            foreach (KeyValuePair<int, LocationPath> item in RedirectPaths)
            {
                _session.GameStory.Locations[item.Value.LocationId].Paths[item.Value.PathId].NextLocationId = NewNextLocationId;
            }
            _session.SaveGameStory();

        }

        public Dictionary<String, Person> GetStats()
        {
            return _session.Stats.Acquaintances;
        }

        public void AddPerson(Person person)
        {
            _session.Stats.Acquaintances.TryAdd(person.Name, person);
            _session.SaveStats();
        }

        //LevelCount
        public void SetLevel(int level)
        {
            _session.Stats.Level = level;
            _session.SaveStats();
        }

        public int GetLevel()
        {
            return _session.Stats.Level;
        }

        public void LevelUp()
        {
            _session.Stats.Level++;
            _session.SaveStats();
        }

        //DateCount
        public void SetDateCount(int count)
        {
            _session.Stats.DateCount = count;
            _session.SaveStats();
        }

        public int GetDateCount()
        {
            return _session.Stats.DateCount;
        }

        public void DateCountUp()
        {
            _session.Stats.DateCount++;
            _session.SaveStats();
        }
    }
}

