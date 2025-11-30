public class User
{
    public string Username { get; set; } = "";
    public string Password { get; set; } = "";
    public bool Active { get; set; }

    public User() { }

    public User(string username, string password, bool active)
    {
        Username = username;
        Password = password;
        Active = active;
    }
}

