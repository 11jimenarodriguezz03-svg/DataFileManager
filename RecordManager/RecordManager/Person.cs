public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Phone { get; set; } = "";
    public string City { get; set; } = "";
    public decimal Balance { get; set; }

    public Person() { }

    public Person(int id, string firstName, string lastName, string phone, string city, decimal balance)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Phone = phone;
        City = city;
        Balance = balance;
    }
}

