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
            //_sessionstorage.Update();
            int? id = _sessionstorage.GetLocationId();
            Location location = _sessionstorage.GameStory.Locations[id.Value];
            if (location.LevelUp == true) this.LevelUp();
            if (location.DateCountUp == true) this.DateCountUp();
            if (location.SuccessfulDateCountUp == true) this.SuccessfulDateCountUp();
            if (location.PathToLock != null) this.LockPath(location.PathToLock.LocationId, location.PathToLock.PathId);
            if (location.PathToUnlock != null) this.UnlockPath(location.PathToUnlock.LocationId, location.PathToUnlock.PathId);
            if (location.PathsToUnlock != null) foreach (LocationPath item2 in location.PathsToUnlock) this.UnlockPath(item2.LocationId, item2.PathId);
            if (location.Person != null)
            {
                this.AddPerson(location.Person);
                this.AddToLocationsIds(601, 0, location.Person.LocationId);
            }
            MetPeople();
            if (location.RedirectPaths != null) foreach (RedirectPath item2 in location.RedirectPaths) this.RedirectPath(item2.LocationId, item2.PathId, item2.NewNextLocationId, item2.NewNextPage);
            if (location.Cost != 0) this.Spend(location.Cost);
            if (location.Cinema == true) this.CinemaCountUp();
            if (location.Coffee == true) this.CoffeeCountUp();
            if (location.Hairstyle == true) this.HairstyleCountUp();
            if (location.Museum == true) this.MuseumCountUp();
            if (location.Picnic == true) this.PicnicCountUp();
            if (location.Club == true) this.ClubCountUp();
            if (location.DateWithPerson == true) _sessionstorage.SetLastDatePerson(location.Name);
            if (location.DateRejected == true) this.DisablePerson (_sessionstorage.GetLastDatePerson());
            if (_sessionstorage.Stats.SuccessfulDateCount == 5)
            {
                this.RedirectPath(704, 0, 0, "Review");
                this.RedirectPath(705, 0, 0, "Review");
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

        //Met People
        public void MetPeople()
        {
            _sessionstorage.Stats.MetPeople = _sessionstorage.Stats.Acquaintances.Count;
            _sessionstorage.SaveStats();
        }

        public void DisablePerson(string name)
        {
            _sessionstorage.Stats.Acquaintances[name].Disabled = true;
            _sessionstorage.SaveStats();
        }

        //Review
        public void Spend(int cost)
        {
            _sessionstorage.Stats.Spent += cost;
            _sessionstorage.SaveStats();
        }

        
        public void CinemaCountUp()
        {
            _sessionstorage.Stats.CinemaCount++;
            _sessionstorage.SaveStats();
        }

        public void CoffeeCountUp()
        {
            _sessionstorage.Stats.CoffeeCount++;
            _sessionstorage.SaveStats();
        }

        public void HairstyleCountUp()
        {
            _sessionstorage.Stats.HairstyleCount++;
            _sessionstorage.SaveStats();
        }

        public void MuseumCountUp()
        {
            _sessionstorage.Stats.MuseumCount++;
            _sessionstorage.SaveStats();
        }

        public void PicnicCountUp()
        {
            _sessionstorage.Stats.PicnicCount++;
            _sessionstorage.SaveStats();
        }

        public void ClubCountUp()
        {
            _sessionstorage.Stats.ClubCount++;
            _sessionstorage.SaveStats();
        }

        public void AddToLocationsIds(int LocationId, int PathId, int NewNextLocationId)
        {
            /*foreach (var item in _sessionstorage.GameStory.Locations)
            {
                foreach (var item2 in item.Value.Paths)
                {
                    if (item2.NextLocationIds == _sessionstorage.GameStory.RandomLocations[randomEnum])
                    {
                        item2.NextLocationIds.Add(number);
                    }
                }
            }*/
            _sessionstorage.GameStory.Locations[LocationId].Paths[PathId].NextLocationIds.Add(NewNextLocationId);
            _sessionstorage.SaveGameStory();
        }

    }
}

