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
            int? id = _session.GetLocationId();
            if (id == null || id == 0)
            {
                return _gamestory.Locations[1];
            }
            else
            {
                return _gamestory.Locations[id.Value];
            }
        }

        public void UnlockPath(int LocationId, int PathId)
        {
            _gamestory.Locations[LocationId].Paths[PathId].IsLocked = false;
        }

        public void LockPath(int LocationId, int PathId)
        {
            _gamestory.Locations[LocationId].Paths[PathId].IsLocked = true;
        }

        public void RedirectPath(int LocationId, int PathId, int NewNextLocationId)
        {
            _gamestory.Locations[LocationId].Paths[PathId].NextLocationId = NewNextLocationId;
        }
    }
}
