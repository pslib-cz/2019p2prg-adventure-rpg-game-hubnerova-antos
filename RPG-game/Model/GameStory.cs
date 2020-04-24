using System;
using System.Collections.Generic;

namespace RPG_game.Model
{
    public class GameStory
    {
        Dictionary<int, Location> locations = new Dictionary<int, Location>();
        public GameStory()
        {
            //Startup, konfigurace postavy
            //locations.Add(0, new Location() { Name = "Název hry", };
            locations.Add(1, new Location() { Name = "Konfigurace tvé postavy", Description = "Tvým prvním úkolem bude vybrat si základní vlastnosti tvého hrdiny / ky. 😈" , Paths = {new Path() {PathId = 0, PathDescription = "Pokračovat", NextLocationId = 2}});
            locations.Add(2, new Location() { Name = "Pokoj", Description = "Jsi ve svém pokoji, máš telefon.. a ten píše: Jdi ven!", Paths = {new Path() {PathId = 0, PathDescription = "Vydat se ven", NextLocationId = 10}}
            locations.Add(10, new Location() { Name = "Náměstí", Description = "Přišel jsi na náměstí, můžeš pokračovat několika různými směry. Který si vybereš?", Paths =  }
            locations.Add(20, new Location() { Name = "Kavárna Moonbucks", Description = "Ocitl ses v kavárně, utíkej si vybrat něco ze zdější obsáhlé nabídky nápojů. Za pultem se na tebe usmívá mladý barista 🧑‍💼 (nebo baristka 🧑‍💼?)"}, Paths = {new Path() {PathId = 0, PathDescription = "Zpět na náměstí", NextLocationId = 10})
            locations.Add(30, new Location() { Name = "Kadeřnictví u Zohana", Description = "Zohan a Břetislava Matějková"}, Paths = {new Path() {PathId = 0, PathDescription = "Zpět na náměstí", NextLocationId = 10})
            locations.Add(40, new Location() { Name = "Park Cestovatelů", Description = "Jsi v parku s Havlem Škrlíkem" }, Paths = {new Path() {PathId = 0, PathDescription = "Zpět na náměstí", NextLocationId = 10})
            locations.Add(50, new Location() { Name = "Kino Cinnamon", Description = "Nacházíš se v kině, s výběrem filmu ti pomůže Pepa Hřebec, zkus s ním promluvit 🤓" }, Paths = {new Path() {PathId = 0, PathDescription = "Zpět na náměstí", NextLocationId = 10})
        }
    }

    public class Location
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsLocked { get; set; }
        public List<Path> Paths { get; set; }

    }


    public class Path
    {
        public int PathId { get; set; }
        public string PathDescription { get; set; }
        public int NextLocationId { get; set; }
    }
}
