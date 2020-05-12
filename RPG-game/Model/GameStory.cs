using System;
using System.Collections.Generic;

namespace RPG_game.Model
{
    public class GameStory
    {
        public Dictionary<int, Location> Locations = new Dictionary<int, Location>();
        public GameStory()
        {
            //Startup, konfigurace postavy (1-9)
            Locations.Add(1, new Location() { Name = "Konfigurace tvé postavy", Description = "Tvým prvním úkolem bude vybrat si základní vlastnosti tvého hrdiny / ky. 😈", Paths = new List<Path>() { new Path() { PathId = 0, PathDescription = "Pokračovat", NextLocationId = 2  } }, IsLocked = false });
            Locations.Add(2, new Location() { Name = "Pokoj", Description = "Jsi ve svém pokoji, máš telefon.. a ten píše: Jdi ven!", Paths = new List<Path>() { new Path() { PathId = 0, PathDescription = "Vydat se ven", NextLocationId = 10 } } });
            //Náměstí (10-19)
            Locations.Add(10, new Location() { Name = "Náměstí", Description = "Přišel jsi na náměstí, můžeš pokračovat několika různými směry. Který si vybereš?", Paths = new List<Path>() { new Path() { PathId = 0, PathDescription = "Zpět do pokoje", NextLocationId = 2 }, new Path() { PathId = 1, PathDescription = "Do kavárny", NextLocationId = 20 }, new Path() { PathId = 2, PathDescription = "Do kadeřnictví", NextLocationId = 30 }, new Path() { PathId = 3, PathDescription = "Do parku", NextLocationId = 40 }, new Path() { PathId = 4, PathDescription = "Do kina", NextLocationId = 50 }, new Path() { PathId = 5, PathDescription = "Do muzea", NextLocationId = 60 }, new Path() { PathId = 6, PathDescription = "Do obchodu", NextLocationId = 70 }, new Path() { PathId = 7, PathDescription = "Do klubu", NextLocationId = 80 } } });
            //Kavárna (20-29)
            Locations.Add(20, new Location() { Name = "Kavárna Moonbucks", Description = "Ocitl ses v kavárně, utíkej si vybrat něco ze zdější obsáhlé nabídky nápojů. Za pultem se na tebe usmívá mladý barista 🧑‍💼 (nebo baristka 🧑‍💼?)", Paths = new List<Path>() { new Path() { PathId = 0, PathDescription = "Zpět na náměstí", NextLocationId = 10 } } });
            //Kaděřnictví (30-39)
            Locations.Add(30, new Location() { Name = "Kadeřnictví u Zohana", Description = "Zohan a Břetislava Matějková", Paths = new List<Path>() { new Path() {PathId = 0, PathDescription = "Zpět na náměstí", NextLocationId = 10 } } });
            //Park (40-49)
            Locations.Add(40, new Location() { Name = "Park Cestovatelů", Description = "Jsi v parku s Havlem Škrlíkem", Paths = new List<Path>() { new Path() {PathId = 0, PathDescription = "Zpět na náměstí", NextLocationId = 10 } } });
            //Kino (50-59)
            Locations.Add(50, new Location() { Name = "Kino Cinnamon", Description = "Nacházíš se v kině, s výběrem filmu ti pomůže Pepa Hřebec, zkus s ním promluvit 🤓", Paths = new List<Path>() { new Path() {PathId = 0, PathDescription = "Zpět na náměstí", NextLocationId = 10 } } });
            //Muzeum (60-69)
            Locations.Add(60, new Location() { Name = "Muzeum", Description = "Muzeum...", Paths = new List<Path>() { new Path() { PathId = 0, PathDescription = "Zpět na náměstí", NextLocationId = 10 } } });
            //Supermarket (70-79)
            Locations.Add(70, new Location() { Name = "Supermarket Oliplus", Description = "Obchod", Paths = new List<Path>() { new Path() { PathId = 0, PathDescription = "Zpět na náměstí", NextLocationId = 10 } } });
            //Taneční klub (80-89)
            Locations.Add(80, new Location() { Name = "Taneční klub Milimetr", Description = "...", Paths = new List<Path>() { new Path() { PathId = 0, PathDescription = "Zpět na náměstí", NextLocationId = 10 } } });
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
