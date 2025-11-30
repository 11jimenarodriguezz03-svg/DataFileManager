using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

public static class FileHelper
{
    private static readonly string BasePath = AppContext.BaseDirectory;

    public static string UsersFile => Path.Combine(BasePath, "Users.txt");
    public static string PersonsFile => Path.Combine(BasePath, "Persons.txt");
    public static string LogFile => Path.Combine(BasePath, "Log.txt");

    public static List<User> LoadUsers()
    {
        var list = new List<User>();

        if (!File.Exists(UsersFile)) return list;

        foreach (var line in File.ReadAllLines(UsersFile))
        {
            var p = line.Split(',');
            if (p.Length != 3) continue;

            bool active = bool.TryParse(p[2], out bool a) && a;
            list.Add(new User(p[0], p[1], active));
        }

        return list;
    }

    public static void SaveUsers(List<User> users)
    {
        var lines = users.Select(u => $"{u.Username},{u.Password},{u.Active}");
        File.WriteAllLines(UsersFile, lines);
    }

    public static List<Person> LoadPersons()
    {
        var list = new List<Person>();

        if (!File.Exists(PersonsFile)) return list;

        foreach (var line in File.ReadAllLines(PersonsFile))
        {
            var p = line.Split(',');

            if (p.Length != 6) continue;

            int id = int.Parse(p[0]);
            decimal bal = decimal.Parse(p[5], CultureInfo.InvariantCulture);

            list.Add(new Person(id, p[1], p[2], p[3], p[4], bal));
        }

        return list;
    }

    public static void SavePersons(List<Person> persons)
    {
        var lines = persons.Select(p =>
            $"{p.Id},{p.FirstName},{p.LastName},{p.Phone},{p.City},{p.Balance.ToString(CultureInfo.InvariantCulture)}"
        );

        File.WriteAllLines(PersonsFile, lines);
    }

    public static void WriteLog(string user, string action)
    {
        string line = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | {user} | {action}";
        File.AppendAllText(LogFile, line + Environment.NewLine);
    }
}

