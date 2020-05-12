using System;
using RPG_game.Model;

namespace RPG_game.Services
{
    public class RpgLogic
    {
        readonly SessionStorage _session;
        readonly GameStory _gamestory;

        public RpgLogic(SessionStorage session, GameStory gamestory)
        {
            _session = session;
            _gamestory = gamestory;
        }

        public Location Play()
        {
            int? id = _session.GetRoomId();
            if (id == null)
            {
                return _gamestory.Locations[0];
            }
            else
            {
                return _gamestory.Locations[id.Value];
            }
        }
    }
}
