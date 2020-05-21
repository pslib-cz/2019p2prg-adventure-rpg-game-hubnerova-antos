using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RPG_game.Model;
using RPG_game.Services;

namespace RPG_game.Pages
{
    public class PagesModel : PageModel
    {
        public Location Location { get; set; }
        public RpgLogic _rpglogic;
        public SessionStorage _session;
        public StatsLogic _stats;
        public Dictionary<String, Person> Acquaintances { get; set; }
        public int? Level;
        public int? DateCount;

        public PagesModel(RpgLogic rpglogic, SessionStorage session, StatsLogic stats)
        {
            _rpglogic = rpglogic;
            _session = session;
            _stats = stats;
        }

        public void OnGet(int to)
        {
            _session.SetLocationId(to);
            Location = _rpglogic.Play();
            Acquaintances = _stats.GetStats();
            Level = _stats.GetLevel();
            DateCount = _stats.GetDateCount();
            if (this.Location.LevelUp == true) _stats.LevelUp();
            if (this.Location.PathToLock != null) _rpglogic.LockPath(this.Location.PathToLock.LocationId, this.Location.PathToLock.PathId);
            if (this.Location.PathToUnlock != null) _rpglogic.UnlockPath(this.Location.PathToUnlock.LocationId, this.Location.PathToUnlock.PathId);
            if (this.Location.Person != null) _stats.AddPerson(this.Location.Person);
            if (this.Location.RedirectPaths != null)
            {
                foreach (RedirectPath item in this.Location.RedirectPaths) _rpglogic.RedirectPath(item.LocationId, item.PathId, item.NewNextLocationId);
            }
        }
    }
}