using Microsoft.AspNetCore.Http;
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
            Locations.Add(1, new Location() { Name = "Konfigurace tvé postavy", Description = "Tvým prvním úkolem bude vybrat si základní vlastnosti tvého hrdiny / ky. 😈", Paths = new List<Path>() { new Path() { PathId = 0, PathDescription = "Pokračovat", NextLocationId = 2  } }});
            Locations.Add(2, new Location() { Name = "Vítej", Description = "", Paths = new List<Path>() { new Path() { PathId = 0, PathDescription = "Jdeme na to!", NextLocationId = 3 } } });
            Locations.Add(3, new Location() { Name = "Pokoj", Description = "Jsi ve svém pokoji, tvůj telefon píše: \"Jdi ven!\"", Paths = new List<Path>() { new Path() { PathId = 0, PathDescription = "Vydat se ven", NextLocationId = 10 } } });
            Locations.Add(4, new Location() { Name = "Pokoj", Description = "Jsi ve svém pokoji.", Paths = new List<Path>() { new Path() { PathId = 0, PathDescription = "Vydat se ven", NextLocationId = 10 } } });
            Locations.Add(5, new Location() { Name = "Nové upozornění", Description = "Telefon: \"Úkol splněn. Tvůj level se zvýšil.\"", Paths = new List<Path>() { new Path() { PathId = 0, PathDescription = "Pokračovat", NextLocationId = 10 } } });
            Locations.Add(6, new Location() { Name = "Nové upozornění", Description = "Telefon: \"Tento úkol se ti bohužel nepovedl, zkus se na toto místo vrátit později.\"", Paths = new List<Path>() { new Path() { PathId = 0, PathDescription = "Pokračovat", NextLocationId = 10 } } });

            //Náměstí (10-19)
            Locations.Add(10, new Location() { Name = "Náměstí", Description = "Přišel jsi na náměstí, můžeš pokračovat několika různými směry. Který si vybereš?", Paths = new List<Path>() { new Path() { PathId = 0, PathDescription = "Zpět do pokoje", NextLocationId = 4 }, new Path() { PathId = 1, PathDescription = "Do kavárny", NextLocationId = 20 }, new Path() { PathId = 2, PathDescription = "Do kadeřnictví", NextLocationId = 100 }, new Path() { PathId = 3, PathDescription = "Do parku", NextLocationId = 200 }, new Path() { PathId = 4, PathDescription = "Do kina", NextLocationId = 300 }, new Path() { PathId = 5, PathDescription = "Do muzea", NextLocationId = 400 }, new Path() { PathId = 6, PathDescription = "Do obchodu", NextLocationId = 500 }, new Path() { PathId = 7, PathDescription = "Do klubu", NextLocationId = 600 } } });
            //Locations.Add(11, new Location() { Name = "Náměstí", Description = "Jsi ve svém pokoji, máš telefon.. a ten píše: Jdi ven!", Paths = new List<Path>() { new Path() { PathId = 0, PathDescription = "Vydat se ven", NextLocationId = 10 } } });

            //Kavárna (20-29)
            Locations.Add(20, new Location() { Name = "Kavárna Moonbucks", Description = "Ocitl ses v kavárně, utíkej si vybrat něco ze zdější obsáhlé nabídky nápojů. Za pultem se na tebe usmívá mladý barista 🧑‍💼 (nebo baristka 🧑‍💼?)", Paths = new List<Path>() { new Path() { PathId = 0, PathDescription = "Zpět na náměstí", NextLocationId = 10 }, new Path() { PathId = 1, PathDescription = "Jít k pultu", NextLocationId = 21 } } });
            // + mobilní aplikace - "získej něčí číslo"
            Locations.Add(21, new Location() { Name = "Nové upozornění", Description = "Telefon: \"Nový úkol - Osměl se a řekni si někomu o číslo.\" ", Paths = new List<Path> { new Path() { PathId = 0, PathDescription = "Jít k baristovi", NextLocationId = 22 }, { new Path { PathId = 1, PathDescription = "Jít k baristce", NextLocationId = 27 } } } });
            Locations.Add(22, new Location() { Name = "Kavárna Moonbucks", Description = "Barista: \"Dobrý den, co si dáte?\"", Paths = new List<Path>() { new Path() { PathId = 0, PathDescription = "Objednat si nápoj", NextLocationId = 23} } });
            Locations.Add(23, new Location() { Name = "Kavárna Moonbucks", Description = "Našel jsi místo na sezení. Čekáš a pozoruješ baristu za pultem. Barista po chvilce volá tvé jméno a ty si jdeš vyzvednout nápoj.", Paths = new List<Path>() { new Path() { PathId = 0, PathDescription = "Poděkovat a odejít", NextLocationId = 6 }, new Path() { PathId = 1, PathDescription = "Požádat baristu o číslo", NextLocationId = 24 }, new Path() { PathId = 2, PathDescription = "Zeptat se na jméno", NextLocationId = 26 } } }) ;
            Locations.Add(24, new Location() { Name = "Kavárna Moonbucks", Description = "Barista: \"Promiňte, nedávám své číslo jen tak na potkání.\"", Paths = new List<Path>() { new Path() { PathId = 0, PathDescription = "Poděkovat a odejít", NextLocationId = 5 }, new Path() { PathId = 2, PathDescription = "Zeptat se na jméno", NextLocationId = 25 } } });
            Locations.Add(25, new Location() { Name = "Kavárna Moonbucks", Description = "Barista si s úsměvem ukáže na jmenovku. \"Jsem Maniel. K vaším službám.\"", Paths = new List<Path>() { new Path() { PathId = 0, PathDescription = "Rozloučit se a odejít", NextLocationId = 5 } } });
            Locations.Add(26, new Location() { Name = "Kavárna Moonbucks", Description = "Barista si s úsměvem ukáže na jmenovku. \"Jsem Maniel. K vaším službám.\"", Paths = new List<Path>() { new Path() { PathId = 0, PathDescription = "Rozloučit se a odejít", NextLocationId = 10 } } });

            Locations.Add(27, new Location() { Name = "Kavárna Moonbucks", Description = "Baristka: \"Dobrý den, co si dáte?\"", Paths = new List<Path>() { new Path() { PathId = 0, PathDescription = "Objednat si nápoj", NextLocationId = 28 } } });
            Locations.Add(28, new Location() { Name = "Kavárna Moonbucks", Description = "Našel jsi místo na sezení. Čekáš a pozoruješ baristku za pultem. Baristka po chvilce volá tvé jméno a ty si jdeš vyzvednout nápoj.", Paths = new List<Path>() { new Path() { PathId = 0, PathDescription = "Poděkovat a odejít", NextLocationId = 10 }, new Path() { PathId = 1, PathDescription = "Požádat baristku o číslo", NextLocationId = 29 }, new Path() { PathId = 2, PathDescription = "Zeptat se na jméno", NextLocationId = 31 } } });
            Locations.Add(29, new Location() { Name = "Kavárna Moonbucks", Description = "Barista: \"Promiňte, nedávám své číslo jen tak na potkání.\"", Paths = new List<Path>() { new Path() { PathId = 0, PathDescription = "Poděkovat a odejít", NextLocationId = 5 }, new Path() { PathId = 2, PathDescription = "Zeptat se na jméno", NextLocationId = 30 } } });
            Locations.Add(30, new Location() { Name = "Kavárna Moonbucks", Description = "Baristka se na tebe zadívá a po chvilce klidně odpoví.\"Maniela. Užijte si kávu. Nashledanou.\"", Paths = new List<Path>() { new Path() { PathId = 0, PathDescription = "Rozloučit se a odejít", NextLocationId = 5 } } });
            Locations.Add(31, new Location() { Name = "Kavárna Moonbucks", Description = "Baristka se na tebe zadívá a po chvilce klidně odpoví.\"Maniela. Užijte si kávu. Nashledanou.\"", Paths = new List<Path>() { new Path() { PathId = 0, PathDescription = "Rozloučit se a odejít", NextLocationId = 10 } } });

            //Kadeřnictví (100-199)
            Locations.Add(100, new Location() { Name = "Kadeřnictví u Zohana", Description = "Nacházíš se v kadeřnictví, na zdi proti tobě je několik fotografií zajímavých účesů, které se teď nosí.", Paths = new List<Path>() { new Path() {PathId = 0, PathDescription = "Zpět na náměstí", NextLocationId = 10 }, new Path() { PathId = 1, PathDescription = "Posadit se do křesla", NextLocationId = 101 } } });
            // + mobilní aplikace - "nech si udělat nový účes"
            Locations.Add(101, new Location() { Name = "Nové upozornění", Description = "Telefon: \"Nový úkol - Nechej si udělat nějaký moderní účes, díky kterému budeš přitažlivější pro své okolí.\" ", Paths = new List<Path> { new Path() { PathId = 0, PathDescription = "Nechat se ostříhat od kadeřníka", NextLocationId = 102 }, new Path { PathId = 1, PathDescription = "Nechat se ostříhat od kadeřnice", NextLocationId = 104 } } } );
            Locations.Add(102, new Location() { Name = "Kadeřnictví u Zohana", Description = "Sedl sis a kadeřník Zohan povídá: \"Dobrý den, jmenuji se Zohan, co uděláme s Vašimi vlasy?\" ", Paths = new List<Path> { new Path() { PathId = 0, PathDescription = "Popsat jaký účes si předtavuješ", NextLocationId = 103 }, new Path { PathId = 1, PathDescription = "Nechat volbu účesu na kadeřníkovi", NextLocationId = 103 } } });
            Locations.Add(103, new Location() { Name = "WOW... účes se opravdu povedl", Description = "Tvůj nový účes je vážně skvělý, sluší ti to. 😉", Paths = new List<Path> { new Path() { PathId = 0, PathDescription = "Poděkovat, zaplatit a odejít", NextLocationId = 5 } } });
            Locations.Add(104, new Location() { Name = "Kadeřnictví u Zohana", Description = "Sedl sis a kadeřnice ti s nejistým tónem v hlase povídá: \"Dobrý den, jmenuji se Břetislava, jaký účes si představujete?\" ", Paths = new List<Path> { new Path() { PathId = 0, PathDescription = "Popsat jaký účes si předtavuješ", NextLocationId = 105 }, new Path { PathId = 1, PathDescription = "Nechat volbu účesu na kadeřnici", NextLocationId = 106 } } });
            Locations.Add(105, new Location() { Name = "Kadeřnictví u Zohana", Description = "Sice to není úplně to, co sis představoval, ale vyloženě ošklivý ten účet také není.", Paths = new List<Path> { new Path() { PathId = 0, PathDescription = "Zaplatit a popřát hodně stěstí", NextLocationId = 5 } } });
            Locations.Add(106, new Location() { Name = "HRŮZA", Description = "Vypadáš jako oškubané kuře, tvé vlasy jsou ale natolik krátké, že jediná možnost je jen kšiltovka nebo klobouk. 😢", Paths = new List<Path> { new Path() { PathId = 0, PathDescription = "Rozhořčeně se rozloučit a odejít", NextLocationId = 6 } } });
            //Locations.Add()

            //Park (200-299)
            Locations.Add(200, new Location() { Name = "Park Cestovatelů", Description = "Jsi v parku, kde tě mezi rodinami s dětmi hned na první pohled zaujal blázen Havel Škrlík.", Paths = new List<Path>() { new Path() {PathId = 0, PathDescription = "Zpět na náměstí", NextLocationId = 10 }, new Path() { PathId = 1, PathDescription = "Jít k rybníku", NextLocationId = 210, IsLocked = true }, new Path() { PathId = 2, PathDescription = "Volně se procházet parkem", NextLocationId = 201 } } });
            // + mobilní aplikace - "zlepši náladu"
            Locations.Add(201, new Location() { Name = "Nové upozornění", Description = "Telefon: \"Nový úkol - Zlepši někomu náladu, aby všichni viděli, jak máš dobré srdce.\"", Paths = new List<Path> { new Path() { PathId = 0, PathDescription = "Jít za holčičkou, které se odkutálel míč", NextLocationId = 202 }, new Path { PathId = 1, PathDescription = "Přijít blíže k Havlovi", NextLocationId = 203 }, new Path { PathId = 2, PathDescription = "Udělat zábavné vystoupení pro děti", NextLocationId = 206 } } });
            Locations.Add(202, new Location() { Name = "Park Cestovatelů", Description = "Pomáháš malé holčičce chytit míč, už ho skoro máš, ale omylem na něj šlápneš a on praskne. Holčička pláče, její rodiče tě zabíjí pohledem a ty se snažíš zneviditelnit.", Paths = new List<Path> { new Path() { PathId = 0, PathDescription = "Vzít nohy na ramena a utéct z Parku", NextLocationId = 6 } } });
            Locations.Add(203, new Location() { Name = "Park Cestovatelů", Description = "Jakmile se příblížíš k Havlovi, vidíš že není tak šílený, jak to zpovzdálí vypadlo. Jen stále něco hledá a točí se okolo lavičky jako šílenec.", Paths = new List<Path> { new Path() { PathId = 0, PathDescription = "Zeptat se, co hledá", NextLocationId = 204 } } });
            Locations.Add(204, new Location() { Name = "Park Cestovatelů", Description = "Havel odpovídá na tvoji otázku: \"Tož ty omladino, já jsem tu ztratil moje okuláry.\", ty mu je samozřejmé pomáháš hledat a po chvíli je v trávě skutečně objevíš. \"Já je tu marně hledal 20 let a ty je najdeš hned. Jak se ti mohu odvděčit?\" povídá Havel", Paths = new List<Path> { new Path() { PathId = 0, PathDescription = "Svěřit se tomuto chápavému důchodci se svými problémy", NextLocationId = 205 } } });
            Locations.Add(205, new Location() { Name = "Park Cestovatelů", Description = "Důchodce Škrlík vyslech všechny tvé problémy a povídá: \"To já byl zamlada neodolatelný díky jednomu místu, kde se randilo jak po másle, řeknu ti, kde to je. 🤪\" a řekně ti kde přesně tento rybík najdeš.", PathToLock = new PathToLock() { LocationId = 200, PathId = 2 }, PathToUnlock =  new PathToUnlock() { LocationId = 200, PathId = 1 }, Paths = new List<Path> { new Path() { PathId = 0, PathDescription = "Poděkovat mu za cennou informaci a odejít", NextLocationId = 5 } } });
            Locations.Add(206, new Location() { Name = "Park Cestovatelů", Description = "Jelikož tvé herecké schopnosti nejsou zrovna na Hollywood, tak u dětí spíše místo smíchu převládají slzy. 🙂", Paths = new List<Path> { new Path() { PathId = 0, PathDescription = "Zahanbeně odejít", NextLocationId = 6 } } });
            Locations.Add(210, new Location() { Name = "Rybník", Description = "Balící místo", Paths = new List<Path> { new Path() { PathId = 0, PathDescription = "Do parku", NextLocationId = 200 } } });

            //Kino (300-399)
            Locations.Add(300, new Location() { Name = "Kino Cinnamon", Description = "Nacházíš se v kině, je tu poměrně dost lidí, ale vidíš kousek ode dvěří vidíš kluka a holku.", Paths = new List<Path>() { new Path() {PathId = 0, PathDescription = "Zpět na náměstí", NextLocationId = 10 }, new Path() { PathId = 1, PathDescription = "Jít za nimi" , NextLocationId = 301 } } });
            // + mobilní aplikace - "najdi někoho nového"
            Locations.Add(301, new Location() { Name = "Nové upozornění", Description = "Telefon: \"Nový úkol - Najdi někoho sympatického a seznam se s ním.\"", Paths = new List<Path> { new Path() { PathId = 0, PathDescription = "Jít k dívce", NextLocationId = 302 }, new Path { PathId = 1, PathDescription = "Jít k chlapci", NextLocationId = 304 }, new Path { PathId = 2, PathDescription = "Jít si koupit lístek", NextLocationId = 305 } } });
            Locations.Add(302, new Location() { Name = "Kino Cinnamon", Description = "Přicházíš k dívce, která se na tebe zadívá a říká: \"Ahoj, jmenuji se Jana Perioda, nechceš si koupit popcorn a zajít na StarWars? 😍\"", Paths = new List<Path> { new Path() { PathId = 0, PathDescription = "Ano", NextLocationId = 303 }, new Path { PathId = 1, PathDescription = "Ne", NextLocationId = 6 } } });
            Locations.Add(303, new Location() { Name = "Kino Cinnamon", Description = "S Janou Periodou si rozumíte, po kině jste si ještě společně zašli na drink.", PathToLock = new PathToLock() { LocationId = 300, PathId = 1 }, Paths = new List<Path> { new Path() { PathId = 0, PathDescription = "Doprovodit Janu domů, popřát dobrou noc a odejít", NextLocationId = 5 } } });
            Locations.Add(304, new Location() { Name = "Kino Cinnamon", Description = "Oslovuješ chlapce a ptáš se: \"Jak se jmenuješ?\", on odpovídá \"Do toho ti nic není!\" a kousne tě do ruky. 😬", Paths = new List<Path> { new Path() { PathId = 0, PathDescription = "Radši odejít pryč", NextLocationId = 6 } } });
            Locations.Add(305, new Location() { Name = "Kino Cinnamon", Description = "Kupuješ si lístek na film V síti, kde po menším pádu ze schodů potkáváš velmi sympatickou Lenku, se kterou se během večera zpřátelíš.", PathToLock = new PathToLock() { LocationId = 300, PathId = 1 }, Paths = new List<Path> { new Path() { PathId = 0, PathDescription = "Doprovodit Lenku domů, popřát dobrou noc a odejít", NextLocationId = 5 } } });

            //Muzeum (400-499)
            Locations.Add(400, new Location() { Name = "Muzeum", Description = "Muzeum...", Paths = new List<Path>() { new Path() { PathId = 0, PathDescription = "Zpět na náměstí", NextLocationId = 10 } } });

            //Supermarket (500-599)
            Locations.Add(500, new Location() { Name = "Supermarket Oliplus", Description = "Obchod", Paths = new List<Path>() { new Path() { PathId = 0, PathDescription = "Zpět na náměstí", NextLocationId = 10 } } });

            //Taneční klub (600-699)
            Locations.Add(600, new Location() { Name = "Taneční klub Milimetr", Description = "...", Paths = new List<Path>() { new Path() { PathId = 0, PathDescription = "Zpět na náměstí", NextLocationId = 10 } } });
        }
    }

    public class Location
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Path> Paths { get; set; }
        public PathToLock PathToLock { get; set; }
        public PathToUnlock PathToUnlock { get; set; }
    }

    public class Path
    {
        public int PathId { get; set; }
        public string PathDescription { get; set; }
        public bool IsLocked { get; set; }
        public int NextLocationId { get; set; }

    }

    public class PathToLock
    {
        public int LocationId { get; set; }
        public int PathId { get; set; }
    }

    public class PathToUnlock
    {
        public int LocationId { get; set; }
        public int PathId { get; set; }
    }
}
