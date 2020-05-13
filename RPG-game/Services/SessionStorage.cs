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
        const string DATEKEY = "DATEID";

        public SessionStorage(IHttpContextAccessor hce)
        {
            _session = hce.HttpContext.Session;
        }

        //LocationId
        public void SetLocationId(int number)
        {
            _session.SetInt32(KEY, number);
        }

        public int? GetLocationId()
        {
            return _session.GetInt32(KEY);
        }

        //LevelCount
        public void SetLevel(int level)
        {
            _session.SetInt32(LEVELKEY, level);
        }

        public int? GetLevel()
        {
            return _session.GetInt32(LEVELKEY);
        }

        public void LevelUp()
        {
            int? level = _session.GetInt32(LEVELKEY);
            _session.SetInt32(LEVELKEY, level.GetValueOrDefault()+1);
        }

        //DateCount
        public void SetDateCount(int count)
        {
            _session.SetInt32(DATEKEY, count);
        }

        public int? GetDateCount()
        {
            return _session.GetInt32(DATEKEY);
        }

        public void DateCountUp()
        {
            int? count = _session.GetInt32(DATEKEY);
            _session.SetInt32(LEVELKEY, count.GetValueOrDefault() + 1);
        }
    }
}
