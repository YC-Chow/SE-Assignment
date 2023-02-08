public class Review
{
    public Review(int reviewId, DateTime reviewDate,int hotelId, int guestId, int reviewRating, string reviewDescription)
    {
        this.reviewId = reviewId;
        this.ReviewDate = ReviewDate;
        this.reviewRating = reviewRating;
        this.reviewDescription = reviewDescription;
        this.hotelId = hotelId;
        this.guestId = guestId;
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

    private int hotelId;
    public int HotelId   // property
    {
        get { return hotelId; }   // get method
        set { hotelId = value; }  // set method
    }

    private int guestId;
    public int GuestId   // property
    {
        get { return guestId; }   // get method
        set { guestId = value; }  // set method
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

}


