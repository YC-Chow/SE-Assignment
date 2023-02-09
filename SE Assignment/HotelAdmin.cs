
public class HotelAdmin
{
    public HotelAdmin(string name, string email)
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
        if (checkInDate != null &&  checkOutDate != null && roomId >0 && guestId > 0)
        {
            Reservation res = new Reservation(null,checkInDate, checkOutDate);
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

