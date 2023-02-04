public class HotelAdmin
{
    public HotelAdmin() { }

    private string name;
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string EmailAddress
    {
        get { return emailAddress; }
        set { emailAddress = value; }
    }

    private Hotel managedHotel;

    public Hotel ManagedHotel
    {
        set
        {
            if (managedHotel != value)
            {
                managedHotel = value;
                value.addHotel(this);
            }
        }
    }

    public Reservation BookHotelRoom(DateTime checkInDate, DateTime checkInDate, int roomId, int guestId )
    {

        return Reservation;
    }


}

