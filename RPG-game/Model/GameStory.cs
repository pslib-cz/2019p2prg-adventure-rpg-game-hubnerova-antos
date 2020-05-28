﻿using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RPG_game.Model
{
    public class GameStory
    {
        public Dictionary<int, Location> Locations = new Dictionary<int, Location>();
        public Dictionary<RandomEnum, int[]> RandomLocations = new Dictionary<RandomEnum, int[]>();
        readonly Random _random;

        public int GetRandom(RandomEnum random)
        {
            int[] array = RandomLocations[random];
            int start = _random.Next(0, array.Length);
            return array[start];
        }

        public GameStory(Random random)
        {
            _random = random;
            RandomLocations.Add(RandomEnum.Hairstyle, new[] { 103, 105, 106});
            RandomLocations.Add(RandomEnum.Date, new[] { 700, 701 });
            RandomLocations.Add(RandomEnum.DateSuccess, new[] { 704, 705, 706 });
            RandomLocations.Add(RandomEnum.KostikOptions, new[] { 408, 409, 410 });
            RandomLocations.Add(RandomEnum.DinaOptions, new[] { 411, 412, 413 });
            RandomLocations.Add(RandomEnum.MuseumAloneOptions, new[] { 414, 415 });

            //Startup, konfigurace postavy (1-9)
            //Locations.Add(1, new Location() { Name = "Konfigurace tvé postavy", Description = "Tvým prvním úkolem bude vybrat si základní vlastnosti tvého hrdiny / ky. 😈", Paths = new List<Path>() { new Path() { PathId = 0, PathDescription = "Pokračovat", NextLocationId = 2 } } });
            Locations.Add(1, new Location() { Name = "Vítej", Description = "Děkujeme, že sis vybral zrovna naší hru. Tvým úkolem bude plnit mise, které ti postupně bude udělovat aplikace na tvém telefonu. Samozřejmě máš možnost ji naprosto ignorovat, každopádně je tu pro tebe, aby ti pomohla naučit se seznamovat a tím splnit cíl téhle hry. Nesnaž se volat o pomoc, mobil je bohužel pouze na úkoly :). Přejeme pěknou zábavu.", Paths = new List<Path>() { new Path() { PathId = 0, PathDescription = "Jdeme na to!", NextLocationId = 3 } } });
            Locations.Add(3, new Location() { Name = "Pokoj", Description = "Jsi ve svém pokoji, tvůj telefon píše: \"Jdi ven!\"", Paths = new List<Path>() { new Path() { PathId = 0, PathDescription = "Vydat se ven", NextLocationId = 10 } } });
            Locations.Add(4, new Location() { Name = "Pokoj", Description = "Jsi ve svém pokoji.", Paths = new List<Path>() { new Path() { PathId = 0, PathDescription = "Vydat se ven", NextLocationId = 10 } } });
            Locations.Add(5, new Location() { Name = "Nové upozornění", Description = "Telefon: \"Úkol splněn. Tvůj level se zvýšil.\"", LevelUp = true, Paths = new List<Path>() { new Path() { PathId = 0, PathDescription = "Pokračovat", NextLocationId = 10 } } }); ;
            Locations.Add(6, new Location() { Name = "Nové upozornění", Description = "Telefon: \"Tento úkol se ti bohužel nepovedl, zkus se na toto místo vrátit později.\"", Paths = new List<Path>() { new Path() { PathId = 0, PathDescription = "Pokračovat", NextLocationId = 10 } } });

            //Náměstí (10-19)
            Locations.Add(10, new Location() { Name = "Náměstí", Description = "Přišel jsi na náměstí, můžeš pokračovat několika různými směry. Který si vybereš?", Paths = new List<Path>() { new Path() { PathId = 0, PathDescription = "Zpět do pokoje", NextLocationId = 4 }, new Path() { PathId = 1, PathDescription = "Do kavárny", NextLocationId = 20 }, new Path() { PathId = 2, PathDescription = "Do kadeřnictví", NextLocationId = 100 }, new Path() { PathId = 3, PathDescription = "Do parku", NextLocationId = 200 }, new Path() { PathId = 4, PathDescription = "Do kina", NextLocationId = 300 }, new Path() { PathId = 5, PathDescription = "Do muzea", NextLocationId = 400 }, new Path() { PathId = 6, PathDescription = "Do obchodu", NextLocationId = 500 }, new Path() { PathId = 7, PathDescription = "Do klubu", IsLocked = true, NextLocationId = 600 } } });
            //Locations.Add(11, new Location() { Name = "Náměstí", Description = "Jsi ve svém pokoji, máš telefon.. a ten píše: Jdi ven!", Paths = new List<Path>() { new Path() { PathId = 0, PathDescription = "Vydat se ven", NextLocationId = 10 } } });

            //Kavárna (20-29)
            Locations.Add(20, new Location() { Name = "Kavárna Moonbucks", Description = "Ocitl ses v kavárně, utíkej si vybrat něco ze zdejší obsáhlé nabídky nápojů. Za pultem se na tebe usmívá mladý barista 🧑‍💼 (nebo baristka 🧑‍💼?)", Paths = new List<Path>() { new Path() { PathId = 0, PathDescription = "Zpět na náměstí", NextLocationId = 10 }, new Path() { PathId = 1, PathDescription = "Jít k pultu", NextLocationId = 21 } } });
            // + mobilní aplikace - "získej něčí číslo"
            Locations.Add(21, new Location() { Name = "Nové upozornění", Description = "Telefon: \"Nový úkol - Osměl se a řekni si někomu o číslo.\" ", Paths = new List<Path> { new Path() { PathId = 0, PathDescription = "Jít k baristovi", NextLocationId = 22 }, { new Path { PathId = 1, PathDescription = "Jít k baristce", NextLocationId = 27 } } } });
            Locations.Add(22, new Location() { Name = "Kavárna Moonbucks", Description = "Barista: \"Dobrý den, co si dáte?\"", RedirectPaths = new List<RedirectPath> { new RedirectPath() { LocationId = 40, PathId = 0, NewNextLocationId = 41 } }, Paths = new List<Path>() { new Path() { PathId = 0, PathDescription = "Objednat si nápoj", NextLocationId = 23 } } });
            Locations.Add(23, new Location() { Name = "Kavárna Moonbucks", Description = "Našel jsi místo na sezení. Čekáš a pozoruješ baristu za pultem. Barista po chvilce volá tvé jméno a ty si jdeš vyzvednout nápoj.", Paths = new List<Path>() { new Path() { PathId = 0, PathDescription = "Poděkovat a odejít", NextLocationId = 6 }, new Path() { PathId = 1, PathDescription = "Požádat baristu o číslo", NextLocationId = 24 }, new Path() { PathId = 2, PathDescription = "Zeptat se na jméno", NextLocationId = 26 } } });
            Locations.Add(24, new Location() { Name = "Kavárna Moonbucks", Description = "Barista: \"Promiňte, nedávám své číslo jen tak na potkání.\"", Paths = new List<Path>() { new Path() { PathId = 0, PathDescription = "Poděkovat a odejít", NextLocationId = 5 }, new Path() { PathId = 2, PathDescription = "Zeptat se na jméno", NextLocationId = 25 } } });
            Locations.Add(25, new Location() { Name = "Kavárna Moonbucks", Description = "Barista si s úsměvem ukáže na jmenovku. \"Jsem Maniel. K vaším službám.\"", Person = new Person() { Name = "Maniel", LocationId = GetRandom(RandomEnum.Date) }, RedirectPaths = new List<RedirectPath> { new RedirectPath() { LocationId = 10, PathId = 1, NewNextLocationId = 40 }, new RedirectPath { LocationId = 40, PathId = 0, NewNextLocationId = 41 } }, Paths = new List<Path>() { new Path() { PathId = 0, PathDescription = "Rozloučit se a odejít", NextLocationId = 5 } } });
            Locations.Add(26, new Location() { Name = "Kavárna Moonbucks", Description = "Barista si s úsměvem ukáže na jmenovku. \"Jsem Maniel. K vaším službám.\"", Person = new Person() { Name = "Maniel", LocationId = GetRandom(RandomEnum.Date) }, Paths = new List<Path>() { new Path() { PathId = 0, PathDescription = "Rozloučit se a odejít", NextLocationId = 6 } } });

            Locations.Add(27, new Location() { Name = "Kavárna Moonbucks", Description = "Baristka: \"Dobrý den, co si dáte?\"", RedirectPaths = new List<RedirectPath> { new RedirectPath() { LocationId = 40, PathId = 1, NewNextLocationId = 42 } }, Paths = new List<Path>() { new Path() { PathId = 0, PathDescription = "Objednat si nápoj", NextLocationId = 28 } } });
            Locations.Add(28, new Location() { Name = "Kavárna Moonbucks", Description = "Našel jsi místo na sezení. Čekáš a pozoruješ baristku za pultem. Baristka po chvilce volá tvé jméno a ty si jdeš vyzvednout nápoj.", Paths = new List<Path>() { new Path() { PathId = 0, PathDescription = "Poděkovat a odejít", NextLocationId = 10 }, new Path() { PathId = 1, PathDescription = "Požádat baristku o číslo", NextLocationId = 29 }, new Path() { PathId = 2, PathDescription = "Zeptat se na jméno", NextLocationId = 31 } } });
            Locations.Add(29, new Location() { Name = "Kavárna Moonbucks", Description = "Barista: \"Promiňte, nedávám své číslo jen tak na potkání.\"", Paths = new List<Path>() { new Path() { PathId = 0, PathDescription = "Poděkovat a odejít", NextLocationId = 5 }, new Path() { PathId = 2, PathDescription = "Zeptat se na jméno", NextLocationId = 30 } } });
            Locations.Add(30, new Location() { Name = "Kavárna Moonbucks", Description = "Baristka se na tebe zadívá a po chvilce klidně odpoví.\"Maniela. Užijte si kávu. Nashledanou.\"", Person = new Person() { Name = "Maniela", LocationId = GetRandom(RandomEnum.Date) }, RedirectPaths = new List<RedirectPath> { new RedirectPath() { LocationId = 10, PathId = 1, NewNextLocationId = 40 }, new RedirectPath() { LocationId = 40, PathId = 1, NewNextLocationId = 42 } }, Paths = new List<Path>() { new Path() { PathId = 0, PathDescription = "Rozloučit se a odejít", NextLocationId = 5 } } });
            Locations.Add(31, new Location() { Name = "Kavárna Moonbucks", Description = "Baristka se na tebe zadívá a po chvilce klidně odpoví.\"Maniela. Užijte si kávu. Nashledanou.\"", Person = new Person() { Name = "Maniela", LocationId = GetRandom(RandomEnum.Date) }, Paths = new List<Path>() { new Path() { PathId = 0, PathDescription = "Rozloučit se a odejít", NextLocationId = 10 } } });
            //Nová kavárna (bez úkolu)
            Locations.Add(40, new Location() { Name = "Kavárna Moonbucks", Description = "Tak jsi tu znovu. Co si dáš?", RedirectPaths = new List<RedirectPath>() { new RedirectPath() { LocationId = 23, PathId = 0, NewNextLocationId = 10 }, new RedirectPath() { LocationId = 24, PathId = 0, NewNextLocationId = 10 }, new RedirectPath() { LocationId = 25, PathId = 0, NewNextLocationId = 10 }, new RedirectPath() { LocationId = 26, PathId = 0, NewNextLocationId = 10 }, new RedirectPath() { LocationId = 28, PathId = 0, NewNextLocationId = 10 }, new RedirectPath() { LocationId = 29, PathId = 0, NewNextLocationId = 10 }, new RedirectPath() { LocationId = 30, PathId = 0, NewNextLocationId = 10 }, new RedirectPath() { LocationId = 31, PathId = 0, NewNextLocationId = 10 } }, Paths = new List<Path>() { new Path() { PathId = 0, PathDescription = "Jít k baristovi", NextLocationId = 22 }, new Path() { PathId = 1, PathDescription = "Jít k baristce", NextLocationId = 27 }, new Path() { PathId = 2, PathDescription = "Zpět na náměstí", NextLocationId = 10 } } });
            Locations.Add(41, new Location() { Name = "Kavárna Moonbucks", Description = "Maniel: \"Dobrý den, co si dneska dáte?\"", Paths = new List<Path>() { new Path() { PathId = 0, PathDescription = "Objednat si", NextLocationId = 43 } } });
            Locations.Add(42, new Location() { Name = "Kavárna Moonbucks", Description = "Maniela: \"Dobrý den, co si dneska dáte?\"", Paths = new List<Path>() { new Path() { PathId = 0, PathDescription = "Objednat si", NextLocationId = 43 } } });
            Locations.Add(43, new Location() { Name = "Kavárna Moonbucks", Description = "Po chvilce je zavoláno tvé jméno a ty si jdeš vyzvednout svůj nápoj k pultu.", Paths = new List<Path>() { new Path { PathId = 0, PathDescription = "Poděkovat a odejít", NextLocationId = 10 } } });



            //Kadeřnictví (100-199)
            Locations.Add(100, new Location() { Name = "Kadeřnictví u Zohana", Description = "Nacházíš se v kadeřnictví, na zdi proti tobě je několik fotografií zajímavých účesů, které se teď nosí.", Paths = new List<Path>() { new Path() { PathId = 0, PathDescription = "Zpět na náměstí", NextLocationId = 10 }, new Path() { PathId = 1, PathDescription = "Posadit se do křesla", NextLocationId = 101 } } });
            // + mobilní aplikace - "nech si udělat nový účes"
            Locations.Add(101, new Location() { Name = "Nové upozornění", Description = "Telefon: \"Nový úkol - Nechej si udělat nějaký moderní účes, díky kterému budeš přitažlivější pro své okolí.\" ", Paths = new List<Path> { new Path() { PathId = 0, PathDescription = "Nechat se ostříhat od kadeřníka", NextLocationId = 102 }, new Path { PathId = 1, PathDescription = "Nechat se ostříhat od kadeřnice", NextLocationId = 104 } } });
            Locations.Add(102, new Location() { Name = "Kadeřnictví u Zohana", Description = "Sedl sis a kadeřník povídá: \"Dobrý den, jmenuji se Zohan, co uděláme s Vašimi vlasy?\" ", Person = new Person() { Name = "Zohan", LocationId = GetRandom(RandomEnum.Date) }, Paths = new List<Path> { new Path() { PathId = 0, PathDescription = "Popsat jaký účes si představuješ", NextLocationId = GetRandom(RandomEnum.Hairstyle) }, new Path { PathId = 1, PathDescription = "Nechat volbu účesu na kadeřníkovi", NextLocationId = GetRandom(RandomEnum.Hairstyle) } } });
            Locations.Add(103, new Location() { Name = "WOW... účes se opravdu povedl", Description = "Tvůj nový účes je vážně skvělý, sluší ti to. 😉", RedirectPaths = new List<RedirectPath> { new RedirectPath() { LocationId = 10, PathId = 2, NewNextLocationId = 120 } }, Paths = new List<Path> { new Path() { PathId = 0, PathDescription = "Poděkovat, zaplatit a odejít", NextLocationId = 5 } } });
            Locations.Add(104, new Location() { Name = "Kadeřnictví u Zohana", Description = "Sedl sis a kadeřnice povídá: \"Dobrý den, jmenuji se Břetislava, jaký účes si představujete?\" ", Person = new Person() { Name = "Břetislava Matějková", LocationId = GetRandom(RandomEnum.Date) }, Paths = new List<Path> { new Path() { PathId = 0, PathDescription = "Popsat jaký účes si představuješ", NextLocationId = GetRandom(RandomEnum.Hairstyle) }, new Path { PathId = 1, PathDescription = "Nechat volbu účesu na kadeřnici", NextLocationId = GetRandom(RandomEnum.Hairstyle) } } });
            Locations.Add(105, new Location() { Name = "Kadeřnictví u Zohana", Description = "Sice to není úplně to, co sis představoval, ale vyloženě ošklivý ten účet také není.", RedirectPaths = new List<RedirectPath> { new RedirectPath() { LocationId = 10, PathId = 2, NewNextLocationId = 120 } }, Paths = new List<Path> { new Path() { PathId = 0, PathDescription = "Zaplatit a popřát hodně štěstí", NextLocationId = 5 } } });
            Locations.Add(106, new Location() { Name = "HRŮZA", Description = "Vypadáš jako oškubané kuře, tvé vlasy jsou ale natolik krátké, že jediná možnost je jen kšiltovka nebo klobouk. 😢", Paths = new List<Path> { new Path() { PathId = 0, PathDescription = "Rozhořčeně se rozloučit a odejít", NextLocationId = 6 } } });
            //Nové kadeřnictví (bez úkolu)
            Locations.Add(120, new Location() { Name = "Kadeřnictví u Zohana", Description = "Znovu jsi přišel do kadeřnictví. Co si necháš ostříhat tentokrát?", RedirectPaths = new List<RedirectPath>() { new RedirectPath { LocationId = 103, PathId = 0, NewNextLocationId = 10}, new RedirectPath { LocationId = 105, PathId = 0, NewNextLocationId = 10}, new RedirectPath { LocationId = 106, PathId = 0, NewNextLocationId = 10} }, Paths = new List<Path>() { new Path() { PathId = 0, PathDescription = "Jít k Zohanovi", NextLocationId = 102 }, new Path { PathId = 1, PathDescription = "Jít k Břetislavě", NextLocationId = 104}, new Path { PathId = 2, PathDescription = "Vrátit se na náměstí", NextLocationId = 10} } });;


            //Locations.Add()

            //Park (200-299)
            Locations.Add(200, new Location() { Name = "Park Cestovatelů", Description = "Jsi v parku, kde tě mezi rodinami s dětmi hned na první pohled zaujal blázen Havel Škrlík.", Paths = new List<Path>() { new Path() { PathId = 0, PathDescription = "Zpět na náměstí", NextLocationId = 10 }, new Path() { PathId = 1, PathDescription = "Jít k rybníku", NextLocationId = 699, IsLocked = true }, new Path() { PathId = 2, PathDescription = "Volně se procházet parkem", NextLocationId = 201 } } });
            // + mobilní aplikace - "zlepši náladu"
            Locations.Add(201, new Location() { Name = "Nové upozornění", Description = "Telefon: \"Nový úkol - Zlepši někomu náladu, aby všichni viděli, jak máš dobré srdce.\"", Paths = new List<Path> { new Path() { PathId = 0, PathDescription = "Jít za holčičkou, které se odkutálel míč", NextLocationId = 202 }, new Path { PathId = 1, PathDescription = "Přijít blíže k Havlovi", NextLocationId = 203 }, new Path { PathId = 2, PathDescription = "Udělat zábavné vystoupení pro děti", NextLocationId = 206 } } });
            Locations.Add(202, new Location() { Name = "Park Cestovatelů", Description = "Pomáháš malé holčičce chytit míč, už ho skoro máš, ale omylem na něj šlápneš a on praskne. Holčička pláče, její rodiče tě zabíjí pohledem a ty se snažíš zneviditelnit.", Paths = new List<Path> { new Path() { PathId = 0, PathDescription = "Vzít nohy na ramena a utéct z Parku", NextLocationId = 6 } } });
            Locations.Add(203, new Location() { Name = "Park Cestovatelů", Description = "Jakmile se příblížíš k Havlovi, vidíš že není tak šílený, jak to zpovzdálí vypadlo. Jen stále něco hledá a točí se okolo lavičky jako šílenec.", Person = new Person() { Name = "Havel Škrlík", LocationId = GetRandom(RandomEnum.Date) }, Paths = new List<Path> { new Path() { PathId = 0, PathDescription = "Zeptat se, co hledá", NextLocationId = 204 } } });
            Locations.Add(204, new Location() { Name = "Park Cestovatelů", Description = "Havel odpovídá na tvoji otázku: \"Tož ty omladino, já jsem tu ztratil moje okuláry.\", ty mu je samozřejmé pomáháš hledat a po chvíli je v trávě skutečně objevíš. \"Já je tu marně hledal 20 let a ty je najdeš hned. Jak se ti mohu odvděčit?\" povídá Havel", Paths = new List<Path> { new Path() { PathId = 0, PathDescription = "Svěřit se tomuto chápavému důchodci se svými problémy", NextLocationId = 205 } } });
            Locations.Add(205, new Location() { Name = "Park Cestovatelů", Description = "Důchodce Škrlík vyslech všechny tvé problémy a povídá: \"To já byl zamlada neodolatelný díky jednomu místu, kde se randilo jak po másle, řeknu ti, kde to je. 🤪\" a řekně ti kde přesně tento rybík najdeš.", PathToLock = new LocationPath() { LocationId = 200, PathId = 2 }, PathToUnlock = new LocationPath() { LocationId = 200, PathId = 1 }, Paths = new List<Path> { new Path() { PathId = 0, PathDescription = "Poděkovat mu za cennou informaci a odejít", NextLocationId = 5 } } });
            Locations.Add(206, new Location() { Name = "Park Cestovatelů", Description = "Jelikož tvé herecké schopnosti nejsou zrovna na Hollywood, tak u dětí spíše místo smíchu převládají slzy. 🙂", Paths = new List<Path> { new Path() { PathId = 0, PathDescription = "Zahanbeně odejít", NextLocationId = 6 } } });
         

            //Kino (300-399)
            Locations.Add(300, new Location() { Name = "Kino Cinnamon", Description = "Nacházíš se v kině, je tu poměrně dost lidí, ale vidíš kousek ode dveří vidíš kluka a holku.", Paths = new List<Path>() { new Path() { PathId = 0, PathDescription = "Zpět na náměstí", NextLocationId = 10 }, new Path() { PathId = 1, PathDescription = "Jít za nimi", NextLocationId = 301 } } });
            // + mobilní aplikace - "najdi někoho nového"
            Locations.Add(301, new Location() { Name = "Nové upozornění", Description = "Telefon: \"Nový úkol - Najdi někoho sympatického a seznam se s ním.\"", Paths = new List<Path> { new Path() { PathId = 0, PathDescription = "Jít k dívce", NextLocationId = 302 }, new Path { PathId = 1, PathDescription = "Jít k chlapci", NextLocationId = 304 }, new Path { PathId = 2, PathDescription = "Jít si koupit lístek", NextLocationId = 305 } } });
            Locations.Add(302, new Location() { Name = "Kino Cinnamon", Description = "Přicházíš k dívce, která se na tebe zadívá a říká: \"Ahoj, jmenuji se Jana Perioda, nechceš si koupit popcorn a zajít na StarWars? 😍\"", Person = new Person() { Name = "Jana Perioda", LocationId = GetRandom(RandomEnum.Date) }, Paths = new List<Path> { new Path() { PathId = 0, PathDescription = "Ano", NextLocationId = 303 }, new Path { PathId = 1, PathDescription = "Ne", NextLocationId = 6 } } });
            Locations.Add(303, new Location() { Name = "Kino Cinnamon", Description = "S Janou Periodou si rozumíte, po kině jste si ještě společně zašli na drink.", PathToLock = new LocationPath() { LocationId = 300, PathId = 1 }, Paths = new List<Path> { new Path() { PathId = 0, PathDescription = "Doprovodit Janu domů, popřát dobrou noc a odejít", NextLocationId = 5 } } });
            Locations.Add(304, new Location() { Name = "Kino Cinnamon", Description = "Oslovuješ chlapce a ptáš se: \"Jak se jmenuješ?\", on odpovídá \"Do toho ti nic není!\" a kousne tě do ruky. 😬", Paths = new List<Path> { new Path() { PathId = 0, PathDescription = "Radši odejít pryč", NextLocationId = 6 } } });
            Locations.Add(305, new Location() { Name = "Kino Cinnamon", Description = "Kupuješ si lístek na film V síti, kde po menším pádu ze schodů potkáváš velmi sympatickou Lenku, se kterou se během večera zpřátelíš.", Person = new Person() { Name = "Lenka", LocationId = GetRandom(RandomEnum.Date) }, PathToLock = new LocationPath() { LocationId = 300, PathId = 1 }, Paths = new List<Path> { new Path() { PathId = 0, PathDescription = "Doprovodit Lenku domů, popřát dobrou noc a odejít", NextLocationId = 5 } } });

            //druhé Kino
            //Locations.Add(300, new Location() { Name = "Kino Cinnamon", Description = "Nacházíš se v kině, je tu poměrně dost lidí, ale vidíš kousek ode dveří vidíš kluka a holku.", Paths = new List<Path>() { new Path() { PathId = 0, PathDescription = "Zpět na náměstí", NextLocationId = 10 }, new Path() { PathId = 1, PathDescription = "Jít za nimi", NextLocationId = 301 } } });


            //Muzeum (400-499)
            Locations.Add(400, new Location() { Name = "Muzeum", Description = "Vešel jsi do muzea. Doufejme, že se ti tu bude líbit. Protože tu stovku za vstup už ti nikdo nevrátí. U brány ti oznámili, že můžeš počkat na průvodkyni.", Paths = new List<Path>() { new Path() { PathId = 0, PathDescription = "Pokračovat", NextLocationId = 401 } } });
            // + mobilní aplikace - "rozšiř své vědomostní obzory."
            Locations.Add(401, new Location() { Name = "Nové upozornění", Description = "Telefon: \"Nový úkol - Nasbírej nové vědomosti. Všichni milují inteligenty.\"", Paths = new List<Path>() { new Path() { PathId = 0, PathDescription = "Počkat na průvodkyni", NextLocationId = 402 }, new Path() { PathId = 1, PathDescription = "Prohlédnout si muzeum na vlastní pěst", NextLocationId = 406, IsLocked = true }, new Path() { PathId = 2, PathDescription = "Odejít z muzea", NextLocationId = 10 } } });
            Locations.Add(402, new Location() { Name = "Muzeum", Description = "Po pár minutách za sebou uslyšíš blížící se kroky. Otočíš se za zvukem. \"To jste tu jenom vy? Máte štěstí, dneska mě máte jenom pro sebe.\" Dívka se afektovaně usměje. \"Dobrý den. Jmenuji se Dina Veselá a dnes budu vaší průvodkyní. Kdykoliv budete mít nějaké dotazy týkající se vystavených aparátů nebo čehokoliv jiného, neváhejte se zeptat. Nyní mě prosím následujte.\"", Person = new Person() { Name = "Dina Veselá", LocationId = GetRandom(RandomEnum.Date) }, Paths = new List<Path>() { new Path() { PathId = 0, PathDescription = "Následovat Dinu", NextLocationId = 403 } } });
            Locations.Add(403, new Location() { Name = "Muzeum", Description = "Čas se vleče a ty pomalu začínáš svých utracených peněz litovat. Dina se sice ze začátku zdála jako fajn partie, teď máš ale co dělat, abys nezíval po každém jejím slově. Vtom tvou pozornost upoutá vytáhlý kluk, který se krčí u jedné z vystavených koster. \" Jeho si nevšímejte. Tenhle kluk sem chodí častěji, než uklízečky. Ne, že ty by tu byly nějak často,\" řekne Dina, mračíc se přitom na chuchvalec prachu poblíž její nohy. \"Říkáme mu Kostík, protože nikdo vlastně neví, jak se doopravdy jmenuje.\" ", Person = new Person() { Name = "Kostík", LocationId = GetRandom(RandomEnum.Date) }, Paths = new List<Path>() { new Path() { PathId = 0, PathDescription = "Zeptat se na Kostíka", NextLocationId = 404 }, new Path { PathId = 1, PathDescription = "Zeptat se na exponáty", NextLocationId = 405 } } });
            Locations.Add(404, new Location() { Name = "Muzeum", Description = "Dina si odfkne. \"Nic moc o něm nevím. Jenom to, že nám brigádníkům rád krade návštěvníky. Vždycky skončí u něj. Nevím, co tak zajímavého jim vypráví, ale všichni vždy odcházejí nadmíru spokojeni. Vedení se ho párkrát dokonce pokusilo zaměstnat, ale marně. Tak dostal alespoň doživotní vstupné zdarma.\"", Paths = new List<Path>() { new Path { PathId = 0, PathDescription = "Pokračovat v prohlídce s Dinou", NextLocationId = 405 }, new Path { PathId = 1, PathDescription = "Jít za Kostíkem", NextLocationId = 406 } } });
            Locations.Add(405, new Location() { Name = "Muzeum", Description = "Prohlídka trvá ještě dalších 20 minut. \"Na konec vám chci poděkovat za pozornost a doufám, že vás zas brzy uvidíme v našem muzeu. \" Dina se otočí na patě a odkráčí zpátky, odkud přišla. Nakonec to nebylo tak špatné. Když ses přenesl přes Dinin předetailovaný přednes, zjistil jsi, že si opravdu něco málo nového pamatuješ. Sice ještě stále nevíš, k čemu ti u seznamování bude vědět, jak velký byl brontosaurus, ale kdo ví.", RedirectPaths = new List<RedirectPath>() { new RedirectPath { LocationId = 10, PathId = 5, NewNextLocationId = 407} }, Paths = new List<Path>() { new Path { PathId = 0, PathDescription = "Odejít z muzea", NextLocationId = 5 } } });
            Locations.Add(406, new Location() { Name = "Muzeum", Description = "Jemně se omluvíš Dině a pomalu zamíříš směrem, kde jsi ještě před chvilkou zahlédl postávat zrzavého návštěvníka. Teď už tu ale nestojí. Otáčíš se všemi směry, ale ne a ne ho najít...  ", Paths = new List<Path>() { new Path { PathId = 0, PathDescription = "Odejít z muzea", NextLocationId = 6 } } });

            //druhé Muzeum
            Locations.Add(407, new Location() { Name = "Muzeum", Description = "Znovu jsi přišel do muzea. Už když jsi vešel, všiml sis, že Kostík tu je znovu.", Paths = new List<Path>() { new Path { PathId = 0, PathDescription = "Jít za Kostíkem", NextLocationId = GetRandom(RandomEnum.KostikOptions) }, new Path { PathId = 1, PathDescription = "Zkusit najít Dinu", NextLocationId = GetRandom(RandomEnum.DinaOptions) }, new Path { PathId = 2, PathDescription = "Prohlédnout si muzeum sám", NextLocationId = 413},new Path { PathId = 3, PathDescription = "Jít pryč z muzea", NextLocationId = 10} } });
            Locations.Add(408, new Location() { Name = "Muzeum", Description = "Přišel jsi ke Kostíkovi. Ten ti povídal o starověkém Egyptě. Zjistil jsi, že už kdysi se dámy vyžívaly ve vlasových příčescích a dokonce se s nimi nechávaly i pohřbít.", Paths = new List<Path>() { new Path { PathId = 0, PathDescription = "Odejít z muzea", NextLocationId = 10 } } });
            Locations.Add(409, new Location() { Name = "Muzeum", Description = "Přišel jsi ke Kostíkovi. Začali jste si povídat o dinosaurech. O těch ví Kostík nejvíc.", Paths = new List<Path>() { new Path { PathId = 0, PathDescription = "Odejít z muzea.", NextLocationId = 10 } } });
            Locations.Add(410, new Location() { Name = "Muzeum", Description = "Kostík dnes neměl chuť si povídat. V tu chvíli, co jsi k němu vykročil, se Kostík otočil a vydal opačným směrem hlouběji do muzea.", Paths = new List<Path>() { new Path { PathId = 0, PathDescription = "Odejít z muzea", NextLocationId = 10 } } });
            Locations.Add(411, new Location() { Name = "Muzeum", Description = "Šel ses na Dinu zeptat a paní u pokladny ti oznámila, že tu dnes Dina není", Paths = new List<Path>() { new Path { PathId = 0, PathDescription = "Odejít z muzea", NextLocationId = 10 } } });
            Locations.Add(412, new Location() { Name = "Muzeum", Description = "Dinu jsi sice našel, ale neměla na tebe čas ani náladu. Snad někdy jindy.", Paths = new List<Path>() { new Path { PathId = 0, PathDescription = "Odejít z muzea", NextLocationId = 10 } } });
            Locations.Add(413, new Location() { Name = "Muzeum", Description = "Šel ses na Dinu zeptat a paní u pokladny ti poradila, kde ji hledat. Dina si tě pamatovala a ráda s tebou pokecala. Řekla ti, ať se zas někdy stavíš.", Paths = new List<Path>() { new Path { PathId = 0, PathDescription = "Odejít z muzea", NextLocationId = 10 } } });
            Locations.Add(414, new Location() { Name = "Muzeum", Description = "Procházíš se už asi 10 minut, ale nic tě ne a ne zaujmout.", Paths = new List<Path>() { new Path { PathId = 0, PathDescription = "Odejít z muzea", NextLocationId = 10 } } });
            Locations.Add(415, new Location() { Name = "Muzeum", Description = "Byl jsi tak zaujat všemi exponáty, že jsi ztratil pojem o čase. Je čas jít.", Paths = new List<Path>() { new Path { PathId = 0, PathDescription = "Odejít z muzea", NextLocationId = 10 } } });




            //Supermarket (500-599)
            Locations.Add(500, new Location() { Name = "Supermarket Oliplus", Description = "Ocitáš se v obchodě, je tu velký výběr všeho možného, od pečiva až po elektroniku. Co si koupíš?", Paths = new List<Path>() { new Path() { PathId = 0, PathDescription = "Koupit běžné potraviny", NextLocationId = 501 }, new Path() { PathId = 1, PathDescription = "Nakoupit na společný piknik", NextLocationId = 502 }, new Path() { PathId = 2, PathDescription = "Odejít", NextLocationId = 10 } } });
            Locations.Add(501, new Location() { Name = "Supermarket Oliplus", Description = "Už máš vše, co potřebuješ a přicházíš k pokladnám.", RedirectPaths = new List<RedirectPath> { new RedirectPath() { LocationId = 505, PathId = 0, NewNextLocationId = 10 }, new RedirectPath() { LocationId = 507, PathId = 0, NewNextLocationId = 10 } } , Paths = new List<Path>() { new Path() { PathId = 0, PathDescription = "Jít k pokladní", NextLocationId = 505 }, new Path() { PathId = 1, PathDescription = "Jít k pokladnímu", NextLocationId = 506 } } });
            Locations.Add(502, new Location() { Name = "Supermarket Oliplus", Description = "Máš nakoupené chipsy, ingredience na jednohubky a dobré francouzské víno.", RedirectPaths = new List<RedirectPath> { new RedirectPath() { LocationId = 505, PathId = 0, NewNextLocationId = 510 }, new RedirectPath() { LocationId = 507, PathId = 0, NewNextLocationId = 510 } }, Paths = new List<Path>() { new Path() { PathId = 0, PathDescription = "Jít k pokladní", NextLocationId = 505 }, new Path() { PathId = 1, PathDescription = "Jít k pokladnímu", NextLocationId = 506 } } });
            Locations.Add(505, new Location() { Name = "Supermarket Oliplus", Description = "Za pokladnou sedí sličná prodavačka, které má na jmenovce napsáno Róza Eaglová, se na tebe usměje a říká: \"679 korunek Vás poprosím. \"", Person = new Person() { Name = "Róza Eaglová", LocationId = this.GetRandom(RandomEnum.Date) }, Paths = new List<Path>() { new Path() { PathId = 0, PathDescription = "Povzdechnout si a zaplatit"} } });
            Locations.Add(506, new Location() { Name = "Supermarket Oliplus", Description = "Za pokladnou je prodavač, který má na jmenovce napsáno Emilie Lichá, což k vzhledem k jeho plnovousu nebude úplně pravdivé. Jakmile řekne jeho hlubokým můžským hlasem \"420 korun\", je ti jasné, že je to muž.", Paths = new List<Path>() { new Path() { PathId = 0, PathDescription = "Zeptat se na jeho jmenovku", NextLocationId = 507 } } });
            Locations.Add(507, new Location() { Name = "Supermarket Oliplus", Description = "Prodavač říká: \"Víte, nechci zde prozrazovat své pravé jméno každému na potkání.\"", Person = new Person() { Name = "Neznámý prodavač", LocationId = this.GetRandom(RandomEnum.Date)}, Paths = new List<Path>() { new Path() { PathId = 0, PathDescription = "Zaplatit" } } });
            Locations.Add(510, new Location() { Name = "Nové upozornění", Description = "Telefon: \"Nakoupil jsi skvělé věci na piknik, tak pozvi někoho na rande, abys je měl s kým sníst. Jenom návrh ;)\"", DateAllowed = true, Paths = new List<Path> { new Path() { PathId = 0, PathDescription = "Číst dále", NextLocationId = 703 } } });




            //Taneční klub (600-699)
            Locations.Add(600, new Location() { Name = "Taneční klub Milimetr", Description = "...", Paths = new List<Path>() { new Path() { PathId = 0, PathDescription = "Zpět na náměstí", NextLocationId = 10 } } });

            //Rande rybník(699-709)
            Locations.Add(699, new Location() { Name = "Rybník", Description = "Dorazil jsi k rybníku. Po chvíli rozhlížení musíš uznat, že měl Havel pravdu. Tohle místo je fakt přímo stvořené na balení.", Paths = new List<Path> { new Path() { PathId = 0, PathDescription = "Projít se", NextLocationId = 703 } } });
            Locations.Add(700, new Location() { Name = "SUPER!", Description = "Tvé pozvání bylo přijato.", RedirectPaths = new List<RedirectPath>() { new RedirectPath { LocationId = 200, PathId = 1, NewNextLocationId = 707 } }, Paths = new List<Path>() { new Path() { PathId = 0, PathDescription = "Jít na rande", NextLocationId = GetRandom(RandomEnum.DateSuccess) } } });
            Locations.Add(701, new Location() { Name = "SMŮLA", Description = "Tvé pozvání bylo odmítnuto.", Paths = new List<Path>() { new Path() { PathId = 0, PathDescription = "Zkusit to jindy", NextLocationId = 6 }, new Path { PathId = 1, PathDescription = "Zkusit pozvat někoho jiného", NextLocationId = 703 } } });
            //Locations.Add(702, new Location() { Name = "Nové upozornění", Description = "Telefon: \"Nový úkol - Jdi s někým na rande! Tohle místo má perfektní atmosféru.\"", DateAllowed = true, Paths = new List<Path> { new Path() { PathId = 0, PathDescription = "Číst dále", NextLocationId = 703 } } });
            Locations.Add(703, new Location() { Name = "Nové upozornění", Description = "Telefon: \"Na horní liště vlevo máš pod seznamem Známí uložené všechny, které jsi zatím stihl ve hře potkat. Kliknutím na jméno je můžeš pozvat na rande. Bude ale pouze na nich, jestli nabídku přijmou. Pokud netoužíš pozvat na rande nikoho ze seznamu, vyraž zpět do města poznat další lidi a pak se sem vrať.\"", DateAllowed = true, Paths = new List<Path> { new Path() { PathId = 0, PathDescription = "Jít se dále seznamovat", NextLocationId = 10 } } });
            Locations.Add(704, new Location() { Name = "YESS", Description = "Tak tohle se povedlo. Celou dobu jste si měli o čem povídat a tobě se úspěšně podařilo svou milou společnost okouzlit. Jen tak dál.", DateCountUp = true, SuccessfulDateCountUp = true, Paths = new List<Path>() { new Path() { PathId = 0, PathDescription = "Pokračovat", NextLocationId = 707 } } });
            Locations.Add(705, new Location() { Name = "NO", Description = "Tvé rande bylo fajn. Žádné extra trapasy se nekonaly, ale že by si z tebe tvoje společnost sedla na zadek, to se taky říct nedá. Příště se polepši.", DateCountUp = true, SuccessfulDateCountUp = true, Paths = new List<Path>() { new Path() { PathId = 0, PathDescription = "Pokračovat", NextLocationId = 707 } } });
            Locations.Add(706, new Location() { Name = "JEJDA", Description = "Tak jestli si myslíš, že tě po tomhle výkonu bude tvá společnost ještě někdy chtít vidět, tak jsi na hlavu. Ceníme ale tvé sebevědomí. Nevěš hlavu a zkus to příště s někým jiným.", DateCountUp = true, Paths = new List<Path>() { new Path() { PathId = 0, PathDescription = "Pokračovat", NextLocationId = 707 } } });
            Locations.Add(707, new Location() { Name = "Rybník", Description = "Jsi u rybníku. Odtud můžeš znovu někoho ze svého seznamu pozvat na rande.", DateAllowed = true, Paths = new List<Path> { new Path() { PathId = 0, PathDescription = "Zpět na náměstí a jít se dále seznamovat", NextLocationId = 10 } } });





        }
    }
}