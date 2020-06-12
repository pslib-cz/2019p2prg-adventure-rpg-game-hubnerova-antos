﻿using System;
using Microsoft.AspNetCore.Http;
using RPG_game.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RPG_game.Helpers;

namespace RPG_game.Services
{
    public class SessionStorage
    {
        readonly ISession _session;
        const string KEY = "LOCATIONID";
        const string DATEPERSONKEY = "DATEPERSONID";
        const string GAMESTORYKEY = "GAMESTORYID";
        const string STATSKEY = "STATSID";

        public GameStory GameStory { get; set; }
        public Stats Stats { get; set; }

        public SessionStorage(IHttpContextAccessor hce)
        {
            _session = hce.HttpContext.Session;
            if (_session.Get<GameStory>(GAMESTORYKEY) == null && _session.Get<Stats>(STATSKEY) == null) this.NewGame();
            GameStory = _session.Get<GameStory>(GAMESTORYKEY);
            Stats = _session.Get<Stats>(STATSKEY);
        }

        public void NewGame()
        {
            _session.Set(GAMESTORYKEY, new GameStory(new Random()));
            _session.Set(STATSKEY, new Stats());
        }

        //LocationId
        public void SetLocationId(int number)
        {
            if (number != 0) _session.SetInt32(KEY, number);
        }

        public int? GetLocationId()
        {
            return _session.GetInt32(KEY);
        }

        //Last date with a person - person name
        public void SetLastDatePerson(string personName)
        {
            _session.SetString(DATEPERSONKEY, personName);
        }

        public string GetLastDatePerson()
        {
            return _session.GetString(DATEPERSONKEY);
        }

        //Saving
        public void SaveStats()
        {
            _session.Set(STATSKEY, this.Stats);
        }

        public void SaveGameStory()
        {
            _session.Set(GAMESTORYKEY, this.GameStory);
        }
    }
}
