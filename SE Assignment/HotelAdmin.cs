using SE_Assignment;

public class HotelAdmin
{
    public HotelAdmin() { }

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

    private Hotel managedHotel;

    public Hotel ManagedHotel
    {
        get { return managedHotel; }

        set
        {
            if (managedHotel != value)
            {
                managedHotel = value;
                //value.addHotel(this);
            }
        }
    }

    public Reservation BookHotelRoom(DateTime checkInDate, DateTime checkOutDate, int roomId, int guestId )
    {
        return null; //temporrary return
    }


}

