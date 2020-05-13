using System;
using Microsoft.AspNetCore.Http;
using RPG_game.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPG_game.Services
{
    public class SessionStorage
    {
        readonly ISession _session;
        const string KEY = "LOCATIONID";
        const string LEVELKEY = "LEVELID";

        public SessionStorage(IHttpContextAccessor hce)
        {
            _session = hce.HttpContext.Session;
        }

        public void SetLocationId(int number)
        {
            _session.SetInt32(KEY, number);
        }

        public int? GetLocationId()
        {
            return _session.GetInt32(KEY);
        }

        public void SetLevel(int level)
        {
            _session.SetInt32(LEVELKEY, level);
        }

        public int? GetLevel()
        {
            return _session.GetInt32(LEVELKEY);
        }

        public void LevelUP()
        {
            int? level = _session.GetInt32(LEVELKEY);
            _session.SetInt32(LEVELKEY, level.GetValueOrDefault()+1);
        }
    }
}
