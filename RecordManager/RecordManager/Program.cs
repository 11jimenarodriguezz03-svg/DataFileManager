using System;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;

internal class Program
{
    static void Main()
    {
        if (!LoginService.Login())
            return;

        Menu();
    }

    static void Menu()
    {
        int op = -1;

        while (op != 0)
        {
            Console.Clear();
            DrawHeader("RECORD MANAGER SYSTEM");

            Console.WriteLine("1. Show persons");
            Console.WriteLine("2. Add person");
            Console.WriteLine("3. Edit person");
            Console.WriteLine("4. Delete person");
            Console.WriteLine("5. Report by city");
            Console.WriteLine("6. Save changes");
            Console.WriteLine("0. Exit");
            Console.Write("\nSelect an option: ");

            int.TryParse(Console.ReadLine(), out op);

            if (op == 1) ShowPersons();
            else if (op == 2) AddPerson();
            else if (op == 3) EditPerson();
            else if (op == 4) DeletePerson();
            else if (op == 5) Report();
            else if (op == 6) Save();
        }
    }

    static void DrawHeader(string title)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("===============================================");
        Console.WriteLine($"                 {title}                 ");
        Console.WriteLine("===============================================");
        Console.ResetColor();
    }

    static void ShowPersons()
    {
        var list = FileHelper.LoadPersons();
        if (!list.Any()) { Console.WriteLine("No records found."); return; }

        var c = CultureInfo.GetCultureInfo("en-US");

        foreach (var p in list.OrderBy(x => x.Id))
        {
            Console.WriteLine($"{p.Id} | {p.FirstName} {p.LastName} | {p.City} | {p.Phone} | {p.Balance.ToString("C", c)}");
        }
    }

    static void AddPerson()
    {
        var list = FileHelper.LoadPersons();

        Console.Write("ID (numeric): ");
        int.TryParse(Console.ReadLine(), out int id);

        Console.Write("First name: ");
        string fn = Console.ReadLine() ?? "";

        Console.Write("Last name: ");
        string ln = Console.ReadLine() ?? "";

        Console.Write("Phone: ");
        string ph = Console.ReadLine() ?? "";

        Console.Write("City: ");
        string ct = Console.ReadLine() ?? "";

        Console.Write("Balance: ");
        decimal.TryParse(Console.ReadLine(), out decimal bal);

        list.Add(new Person(id, fn, ln, ph, ct, bal));
        FileHelper.SavePersons(list);
    }

    static void EditPerson()
    {
        var list = FileHelper.LoadPersons();

        Console.Write("ID: ");
        int.TryParse(Console.ReadLine(), out int id);

        var p = list.FirstOrDefault(x => x.Id == id);
        if (p == null) { Console.WriteLine("Record not found."); return; }

        Console.Write($"First name ({p.FirstName}): ");
        string fn = Console.ReadLine() ?? "";
        if (fn != "") p.FirstName = fn;

        Console.Write($"Last name ({p.LastName}): ");
        string ln = Console.ReadLine() ?? "";
        if (ln != "") p.LastName = ln;

        Console.Write($"Phone ({p.Phone}): ");
        string ph = Console.ReadLine() ?? "";
        if (ph != "") p.Phone = ph;

        Console.Write($"City ({p.City}): ");
        string ct = Console.ReadLine() ?? "";
        if (ct != "") p.City = ct;

        Console.Write($"Balance ({p.Balance}): ");
        string bs = Console.ReadLine() ?? "";
        if (decimal.TryParse(bs, out decimal nb)) p.Balance = nb;

        FileHelper.SavePersons(list);
    }

    static void DeletePerson()
    {
        var list = FileHelper.LoadPersons();

        Console.Write("ID: ");
        int.TryParse(Console.ReadLine(), out int id);

        var p = list.FirstOrDefault(x => x.Id == id);
        if (p == null) { Console.WriteLine("Record not found."); return; }

        Console.Write($"Delete {p.FirstName} {p.LastName}? (y/n): ");
        string ans = Console.ReadLine() ?? "";
        if (ans.ToLower() != "y") return;

        list.Remove(p);
        FileHelper.SavePersons(list);
    }

    static void Report()
    {
        var list = FileHelper.LoadPersons();
        if (!list.Any()) { Console.WriteLine("No data."); return; }

        var c = CultureInfo.GetCultureInfo("en-US");

        var groups = list.GroupBy(p => p.City);

        foreach (var g in groups)
        {
            Console.WriteLine($"\nCity: {g.Key}");
            decimal subtotal = 0;

            foreach (var p in g)
            {
                Console.WriteLine($"{p.Id} {p.FirstName} {p.LastName} {p.Balance.ToString("C", c)}");
                subtotal += p.Balance;
            }

            Console.WriteLine($"Subtotal {g.Key}: {subtotal.ToString("C", c)}");
        }
    }

    static void Save()
    {
        var list = FileHelper.LoadPersons();
        FileHelper.SavePersons(list);
        Console.WriteLine("Saved.");
    }
}
