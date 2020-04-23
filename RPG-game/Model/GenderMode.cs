using System;
using System.ComponentModel.DataAnnotations;

namespace RPG_game.Model
{
    public enum GenderMode
    {
        [Display(Name = "Obojí")]
        Both = 0,
        [Display(Name = "Muži")]
        Men = 1,
        [Display(Name = "Ženy")]
        Women = 2,
    }
}
