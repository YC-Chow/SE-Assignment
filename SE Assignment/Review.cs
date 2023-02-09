using System.Xml.Linq;

public class Review : SE_Assignment.Observer.ISubject
{
    public Review(int reviewId, DateTime reviewDate,Hotel hotel, Guest guest, int rating, string reviewContent)
    {
        this.reviewId = reviewId;
        this.reviewDate = reviewDate;
        this.rating = rating;
        this.reviewContent = reviewContent;
        this.hotel = hotel;
        this.guest = guest;
        this.Observers = new List<SE_Assignment.Observer.IObserver>();
    }

    private List<SE_Assignment.Observer.IObserver> Observers { get; set; }

    private int reviewId;
    public int ReviewId   // property
    {
        get { return reviewId; }   // get method
        set { reviewId = value; }  // set method
    }

    private DateTime reviewDate;
    public DateTime ReviewDate   // property
    {
        get { return reviewDate; }   // get method
        set { reviewDate = value; }  // set method
    }

    private Hotel hotel;
    public Hotel Hotel
    {
        get { return hotel; }   // get method
        set { hotel = value; }
    }

    private Guest guest;
    public Guest Guest
    {
        get { return guest; }   // get method
        set { guest = value; }
    }

    private int rating;
    public int Rating   // property
    {
        get { return rating; }   // get method
        set { rating = value; }  // set method
    }

    private string reviewContent;
    public string ReviewContent   // property
    {
        get { return reviewContent; }   // get method
        set { reviewContent = value; }  // set method
    }



    public void registerObserver(SE_Assignment.Observer.IObserver observer)
    {
        Observers.Add(observer);
    }

    public void removeObserver(SE_Assignment.Observer.IObserver observer)
    {
        Observers.Remove(observer);
    }

    public void notifyObserver()
    {
        foreach (var observer in Observers)
        {
            observer.Update(this);
        }
    }
}


