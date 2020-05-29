using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
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
            int? lastId = _sessionstorage.GetLastLocationId();
            Location location = _sessionstorage.GameStory.Locations[lastId.Value];
            foreach (Path item in _sessionstorage.GameStory.Locations[lastId.Value].Paths)
            {
                if (item.NextLocationId == id.Value || id.Value == 700 || id.Value == 701)
                {
                    _sessionstorage.SetLastLocationId(id.Value);
                    location = _sessionstorage.GameStory.Locations[id.Value];
                    if (location.LevelUp == true) this.LevelUp();
                    if (location.DateCountUp == true) this.DateCountUp();
                    if (location.SuccessfulDateCountUp == true) this.SuccessfulDateCountUp();
                    if (location.PathToLock != null) this.LockPath(location.PathToLock.LocationId, location.PathToLock.PathId);
                    if (location.PathToUnlock != null) this.UnlockPath(location.PathToUnlock.LocationId, location.PathToUnlock.PathId);
                    if (location.Person != null) this.AddPerson(location.Person);
                    if (location.RedirectPaths != null) foreach (RedirectPath item2 in location.RedirectPaths) this.RedirectPath(item2.LocationId, item.PathId, item2.NewNextLocationId, item2.NewNextPage);
                    if (location.Cost != 0) this.Spend(location.Cost);
                    if (_sessionstorage.Stats.SuccessfulDateCount == 5)
                    {
                        this.RedirectPath(704, 0, 0, "Review");
                        this.RedirectPath(705, 0, 0, "Review");
                    }
                }
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

        private void RedirectPath(int LocationId, int PathId, int NewNextLocationId, string NewNextPage)
        {
            _sessionstorage.GameStory.Locations[LocationId].Paths[PathId].NextLocationId = NewNextLocationId;
            if (NewNextPage != null)
            {
                _sessionstorage.GameStory.Locations[LocationId].Paths[PathId].NextPage = NewNextPage;
            }
            _sessionstorage.SaveGameStory();
        }

        /*private void RedirectPaths (Dictionary<int, RedirectPath> RedirectPaths, int NewNextLocationId)
        {
            foreach (KeyValuePair<int, RedirectPath> item in RedirectPaths)
            {
                RedirectPath(item.Value.LocationId, item.Value.PathId, item.Value.NewNextLocationId, item.Value.NewNextPage);
            }
        }*/

        private void AddPerson(Person person)
        {
            _sessionstorage.Stats.Acquaintances.TryAdd(person.Name, person);
            _sessionstorage.SaveStats();
        }

        //LevelCount
        private void LevelUp()
        {
            _sessionstorage.Stats.Level++;
            _sessionstorage.SaveStats();
        }

        //DateCount
        private void DateCountUp()
        {
            _sessionstorage.Stats.DateCount++;
            _sessionstorage.SaveStats();
        }

        private void SuccessfulDateCountUp()
        {
            _sessionstorage.Stats.SuccessfulDateCount++;
            _sessionstorage.SaveStats();
        }

        //Stats (Get)
        public Stats GetStats()
        {
            return _sessionstorage.Stats;
        }

        //Spend
        public void Spend(int cost)
        {
            _sessionstorage.Stats.Spent += cost;
            _sessionstorage.SaveStats();
        }
    }
}

