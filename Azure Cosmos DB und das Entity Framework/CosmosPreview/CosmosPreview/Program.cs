using CosmosPreview.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CosmosPreview
{
    class Program
    {

        private static SchroedingerContext _schroedingerCtx;

        private static CatService _catService;
        private static BoxService _boxService;

        static async Task Main(string[] args)
        {
            // Ein neuer Context wird erstellt.
            _schroedingerCtx = new SchroedingerContext();

            Helper.PrintBlock("Bitte warten, der Datenbank-Context wird erstellt.");

            // Vor jedem Start wird sichergestellt, das der Context auf der Datenbank vorhanden ist.
            await _schroedingerCtx.Database.EnsureDeletedAsync();
            await _schroedingerCtx.Database.EnsureCreatedAsync();

            Helper.PrintBlock("Der Datenbank-Context wurde erfolgreich erstellt.");

            // Initialisierung der Services zur Interaktion mit dem Context.
            // Der CatService wird nicht verwendet, kann aber Katzen anhand des Namens liefern.
            _catService = new CatService(_schroedingerCtx);
            _boxService = new BoxService(_schroedingerCtx);

            // Wir fragen nach der Farbe.
            var boxColor = GetBoxColor();

            // Wir fragen nach dem Namen.
            var catName = GetCatName();

            // Wir erzeugen direkt im Methodenkörper ein geschachteltes Box-Objekt und fügen es dem Context hinzu.
            await _boxService.AddEntityAsync(
                new Box
                {
                    BoxId = 1,
                    Color = boxColor,
                    Cat = new Cat
                    {
                        CatId = 1,
                        Name = catName,
                        IsAlive = new Random().Next(100) < 50 ? true : false
                    }
                });

            var count = await _boxService.SaveChangesAsync();

            OpenBox(boxColor);

            Console.ReadLine();

        }

        /// <summary>
        /// Beschafft die Entität anhand der Farbe und stellt den Inhalt da.
        /// </summary>
        /// <param name="color"></param>
        public static async void OpenBox(string color)
        {
            var box = await _boxService.GetBoxByColor(color);
            Console.WriteLine("Die Box mit der Farbe {0} wird geöffnet. In der Box befindet sich eine Katze mit dem Namen {1}.", box.Color, box.Cat.Name);
            Console.WriteLine(box.Cat.IsAlive ? "Die Katze lebt!" : "Leider ist die Katze tot!");

        }

        /// <summary>
        /// Rekursive Methode zum Abfragen der gewünschten Farbe der Box
        /// </summary>
        /// <returns></returns>
        public static string GetBoxColor()
        {
            Console.WriteLine("Welche Farbe hat deine Box:");
            var color = Console.ReadLine();
            if (color == "")
                GetBoxColor();
            return color;
        }

        /// <summary>
        /// Rekursive Methode zum Abfragen des gewünschten Namens der Katze
        /// </summary>
        /// <returns></returns>
        public static string GetCatName()
        {
            Console.WriteLine("Gib der Katze einen Namen:");
            var name = Console.ReadLine();
            if (name == "")
                GetCatName();
            return name;
        }

    }
}
