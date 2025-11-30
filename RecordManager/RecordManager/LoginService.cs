using System;
using System.Collections.Generic;
using System.Linq;

public static class LoginService
{
    private const int MaxAttempts = 3;
    public static string CurrentUser { get; private set; } = "";

    public static bool Login()
    {
        var users = FileHelper.LoadUsers();
        int attempts = 0;

        while (attempts < MaxAttempts)
        {
            Console.Clear();
            DrawHeader("USER AUTHENTICATION");

            Console.Write("Username: ");
            string username = Console.ReadLine() ?? "";

            Console.Write("Password: ");
            string password = Console.ReadLine() ?? "";

            CurrentUser = username;

            var user = users.FirstOrDefault(u => u.Username == username);

            if (user == null)
            {
                DrawWarning("User not found.");
                attempts++;
                Pause();
                continue;
            }

            if (!user.Active)
            {
                DrawError("This user is BLOCKED.");
                Pause();
                return false;
            }

            if (user.Password == password)
            {
                FileHelper.WriteLog(username, "Login success");
                DrawSuccess("Access granted.");
                Pause();
                return true;
            }

            DrawWarning("Incorrect password.");
            FileHelper.WriteLog(username, "Login failed");
            attempts++;
            Pause();
        }

        BlockUser();
        return false;
    }

    private static void BlockUser()
    {
        var users = FileHelper.LoadUsers();
        var user = users.FirstOrDefault(u => u.Username == CurrentUser);

        if (user != null)
        {
            user.Active = false;
            FileHelper.SaveUsers(users);
            FileHelper.WriteLog(CurrentUser, "User blocked");
        }

        DrawError("User BLOCKED after 3 failed attempts.");
        Pause();
    }

    private static void Pause()
    {
        Console.WriteLine("\nPress ENTER to continue...");
        Console.ReadLine();
    }

    private static void DrawHeader(string title)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("===============================================");
        Console.WriteLine($"                  {title}                  ");
        Console.WriteLine("===============================================");
        Console.ResetColor();
    }

    private static void DrawSuccess(string msg)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n" + msg);
        Console.ResetColor();
    }

    private static void DrawError(string msg)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\n" + msg);
        Console.ResetColor();
    }

    private static void DrawWarning(string msg)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n" + msg);
        Console.ResetColor();
    }
}
