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
        public Dictionary<String, Person> Acquaintances { get; set; }
        public int? Level;
        public int? DateCount;

        public PagesModel(RpgLogic rpglogic, SessionStorage session)
        {
            _rpglogic = rpglogic;
            _session = session;
        }

        public void OnGet(int to)
        {
            _session.SetLocationId(to);
            Location = _rpglogic.Play();
            Acquaintances = _rpglogic.GetStats();
            Level = _rpglogic.GetLevel();
            DateCount = _rpglogic.GetDateCount();
        }
    }
}