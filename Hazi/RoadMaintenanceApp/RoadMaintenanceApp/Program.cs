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
                        AddNewRoad(service);
                        break;
                    case "2":
                        ModifyRoad(service);
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

        static void AddNewRoad(RoadService service)
        {
            Console.Write("ID: ");
            string id = Console.ReadLine()!;

            var condition = ReadCondition();

            Console.Write("Hossz (km): ");
            int length = int.Parse(Console.ReadLine()!);

            Console.Write("Forgalom (0-10): ");
            int traffic = int.Parse(Console.ReadLine()!);

            service.AddStreet(id, condition, length, traffic);
            Console.WriteLine("Sikeres felvétel!");
        }

        static void ModifyRoad(RoadService service)
        {
            Console.Write("Módosítandó út ID: ");
            string id = Console.ReadLine()!;

            Console.WriteLine("Adja meg az új állapot adatokat:");
            var condition = ReadCondition();

            Console.Write("Új Hossz (km): ");
            int length = int.Parse(Console.ReadLine()!);

            Console.Write("Új Forgalom: ");
            int traffic = int.Parse(Console.ReadLine()!);

            service.UpdateStreet(id, condition, length, traffic);
            Console.WriteLine("Sikeres módosítás!");
        }

        static RoadCondition ReadCondition()
        {
            Console.Write("Jó állapot %: ");
            int good = int.Parse(Console.ReadLine()!);

            Console.Write("Közepes állapot %: ");
            int mid = int.Parse(Console.ReadLine()!);

            Console.Write("Rossz állapot %: ");
            int bad = int.Parse(Console.ReadLine()!);

            return new RoadCondition(good, mid, bad);
        }
    }
}