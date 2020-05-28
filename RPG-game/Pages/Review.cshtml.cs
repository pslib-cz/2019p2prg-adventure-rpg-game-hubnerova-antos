using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RPG_game.Model;
using RPG_game.Services;

namespace RPG_game.Pages
{
    public class ReviewModel : PageModel
    {
        public Location Location { get; set; }
        public RpgLogic _rpglogic;
        public SessionStorage _sessionstorage;
        public Stats Stats;

        public ReviewModel(RpgLogic rpglogic, SessionStorage sessionstorage)
        {
            _rpglogic = rpglogic;
            _sessionstorage = sessionstorage;
        }

        public void OnGet()
        {
            _sessionstorage.SetLocationId(1);
            Location = _rpglogic.Play();
            Stats = _rpglogic.GetStats();
        }
    }
}