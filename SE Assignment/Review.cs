public class Review
{
    public Review() { }

    private string reviewId;
    public string ReviewId   // property
    {
        get { return reviewId; }   // get method
        set { reviewId = value; }  // set method
    }

    private Datetime reviewDate;
    public Datetime ReviewDate   // property
    {
        get { return reviewDate; }   // get method
        set { reviewDate = value; }  // set method
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


