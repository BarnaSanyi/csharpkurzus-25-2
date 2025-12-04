using RoadMaintenanceApp.Data;
using RoadMaintenanceApp.Models;
using RoadMaintenanceApp.Services;

class Program
{
    static void Main(string[] args)
    {
        using var context = new AppDbContext();
        var service = new RoadService(context);

        while (true)
        {
            Console.WriteLine("\n--- Út Karbantartó Rendszer ---");
            Console.WriteLine("1. Új út felvétele");
            Console.WriteLine("2. Út módosítása");
            Console.WriteLine("3. Út törlése");
            Console.WriteLine("4. Keresés és Listázás (JSON Exporttal)");
            Console.WriteLine("5. Kilépés");
            Console.Write("Válasszon: ");

            var choice = Console.ReadLine();

            try
            {
                switch (choice)
                {
                    case "1":
                        //Új utat ad hozzá
                        break;
                    case "2":
                        //Út módosítása
                        break;
                    case "3":
                        //Út törlése
                        break;
                    case "4":
                        //Keresés és listázás JSON exporttal
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Érvénytelen választás.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"HIBA TÖRTÉNT: {ex.Message}");
                Console.ResetColor();
            }
        }
    }
}