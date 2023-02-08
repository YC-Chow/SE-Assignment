public class Review
{
    public Review(int reviewId, DateTime reviewDate,Hotel hotel, Guest guest, int reviewRating, string reviewDescription)
    {
        this.reviewId = reviewId;
        this.reviewDate = reviewDate;
        this.reviewRating = reviewRating;
        this.reviewDescription = reviewDescription;
        this.hotel = hotel;
        this.guest = guest;
    }

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

    private int reviewRating;
    public int ReviewRating   // property
    {
        get { return reviewRating; }   // get method
        set { reviewRating = value; }  // set method
    }

    private string reviewDescription;
    public string ReviewDescription   // property
    {
        get { return reviewDescription; }   // get method
        set { reviewDescription = value; }  // set method
    }

    private Reservation reservation;
    public Reservation Reservation
    {
        get { return reservation; }   // get method
        set { reservation = value; }
    }

}


