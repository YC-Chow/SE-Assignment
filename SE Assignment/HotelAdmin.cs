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
        if (!DateTime.IsNullOrEmpty(checkInDate) &&  (!DateTime.IsNullOrEmpty(checkOutDate)) && !int.IsNullOrEmpty(roomId) && !int.IsNullOrEmpty(guestId))
        {
            Reservation res = new Reservation(DateTime.Now, checkInDate, checkOutDate, "Confirmed");
            //Auto-generate the reservationID
            return res;
        }
        else
        {
            Console.WriteLine("Error occured. ");
            return null;
        }
    }


}

