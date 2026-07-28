class Customer
{
    string _firstname;
    string _lastname;

    public Customer(string firstname, string lastname)
    {
        this._firstname = firstname;
        this._lastname = lastname;
    }
    public string GetFullName()
    {
        console.WriteLine("Full Name: " + this._firstname + " " + this._lastname);
        return $"{_firstname} {_lastname}";
    }

    ~Customer()
    {
        console.WriteLine("Destructor is called");
    }
}

class Program
{
    static void Main()
    {
        Customer customer1 = new Customer("John", "Doe");
        customer1.GetFullName();
    }
}
