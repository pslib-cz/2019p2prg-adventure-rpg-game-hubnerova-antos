using System;
using Microsoft.AspNetCore.Http;

namespace RPG_game.Services
{
    public class SessionStorage
    {
        readonly ISession _session;
        const string KEY = "LOCATIONID";

        public SessionStorage(IHttpContextAccessor hce)
        {
            _session = hce.HttpContext.Session;
        }

        public void SetLocationId(int number)
        {
            _session.SetInt32(KEY, number);
        }

        internal int? GetRoomId()
        {
            throw new NotImplementedException();
        }

        public int? GetLocationId()
        {
            return _session.GetInt32(KEY);
        }
    }
}
