using System;
namespace RPG_game.Model
{
    public class GameStory
    {
        List<Location> locations = new List<Location>();
        public GameStory()
        {

            List<Location> locations = new List<Location>();
            //10-19 Hlavní ostrov
            locations.Add(new Location() { ID = 10, Name = "Hlavní ostrov", Description = "Nacházíš se na hlavním ostrově. Zde se nachází vesnice, farma, Železné doly, les a hřbitov." });
            locations.Add(new Location() { ID = 11, Name = "Vesnice", Description = "Nacházíš se ve vesnici. Z vesnice se můžeš dostat na jakékoli místo na hlavním ostrově." });
            locations.Add(new Location() { ID = 12, Name = "Farma", Description = "Nacházíš se na farmě. Odtud je možné dostat na ostrov, kde se nachází Stodola." });
            locations.Add(new Location() { ID = 13, Name = "Železné doly", Description = "Nacházíš se v Železných dolech. Odtud je možné se dostat na ostrov s doly." });
            locations.Add(new Location() { ID = 14, Name = "Les", Description = "Nacházíš se v lese. Odtud se lze dostat klikatou cestičkou na zalesněné Létající ostrovy." });
            locations.Add(new Location() { ID = 15, Name = "Hřbitov", Description = "Nacházíš se na hřbitově. Zde se nachází tajemný oltář, který je schopen tě přemístit na ostrov s Pavoučím doupětem." });
            //20-29 Stodola
            locations.Add(new Location() { ID = 20, Name = "Stodola", Description = "Nacházíš se ve stodole." });
            //30-39 Doly
            locations.Add(new Location() { ID = 30, Name = "Doly", Description = "Nacházíš se na ostrově s doly. Zde se nachází Zlaté doly a hluboký vrt." });
            locations.Add(new Location() { ID = 31, Name = "Zlaté doly", Description = "Nacházíš se ve Zlatých dolech." });
            locations.Add(new Location() { ID = 32, Name = "Hluboký vrt", Description = "Nacházíš se v hlubokém vrtu." });
            //40-49 Pavoučí doupě
            locations.Add(new Location() { ID = 40, Name = "Pavoučí doupě", Description = "Nacházíš se na ostrově s Pavoučím doupětem. Zde se nachází Dračí kostra, Tarantulí hora a Goliášův vrchol." });
            locations.Add(new Location() { ID = 41, Name = "Dračí kostra", Description = "Nacházíš se u Dračí kostry." });
            locations.Add(new Location() { ID = 42, Name = "Tarantulí hora", Description = "Nacházíš se na Tarantulí hoře." });
            locations.Add(new Location() { ID = 43, Name = "Goliášův vrchol", Description = "Nacházíš se na Goliářově vrcholu." });
            //50-59 Létající ostrovy
            locations.Add(new Location() { ID = 50, Name = "Létající ostrovy", Description = "Nacházíš se na létajících ostrovech. Zde se nachází Dubový ostrov, Smrkový ostrov a Létající džungle." });
            locations.Add(new Location() { ID = 51, Name = "Dubový ostrov", Description = "Nacházíš se na Dubovém ostrově." });
            locations.Add(new Location() { ID = 52, Name = "Smrkový ostrov", Description = "Nacházíš se na Smrkovém ostrově." });
            locations.Add(new Location() { ID = 53, Name = "Létající džungle", Description = "Nacházíš se v Létající džungli." });
        }
    }

    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsLocked { get; set; }
        public List<int> Paths { get; set; }

    }


    public class Path
    {
        public int PathId { get; set; }
        public string PathDescription { get; set; }
        public int NextLocationId { get; set; }
    }
}
