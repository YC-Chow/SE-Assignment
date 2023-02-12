using SE_Assignment;

public class Admin: SE_Assignment.Observer.IObserver
{
    public Admin(string name, string email)
    {
        this.name = name;
        this.emailAddress = email;
    }

    private string name;
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    private string emailAddress;
    public string EmailAddress
    {
        get { return emailAddress; }
        set { emailAddress = value; }
    }

    public void Update(Review review)
    {
        Console.WriteLine("Admin notified of new hotel review: " + review.ReviewContent);
    }
}

