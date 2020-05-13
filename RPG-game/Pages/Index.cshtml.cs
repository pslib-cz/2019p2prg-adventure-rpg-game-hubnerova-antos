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
    public class IndexModel : PageModel
    {
        public Location Location { get; set; }
        public RpgLogic _rpglogic;
        public SessionStorage _session;
        public int? level { get; set; }
        

        public IndexModel(RpgLogic rpglogic, SessionStorage session)
        {
            _rpglogic = rpglogic;
            _session = session;
        }

        public void OnGet()
        {
            Location = _rpglogic.Play();
            _session.SetLevel(0);
            level = _session.GetLevel();
        }
    }
}
