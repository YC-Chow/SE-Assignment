using SE_Assignment;
using SE_Assignment.Iterator;

public class Guest
{

    public Guest(string name, string passportNo, string icNo, string emailAddress, string contactNo,double accBal=0)
    {
        Name = name;
        if (icNo != null)
        {
            this.IcNo = icNo;
        }
        if (passportNo != null)
        {
            PassportNo = passportNo;
        }
        EmailAddress = emailAddress;
        ContactNo = contactNo;
        voucherList = new List<Voucher>();
        AccBal = accBal;
    }

    private string name;
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    private string icNo = "";
    public string IcNo
    {
        get { return icNo; }
        set { icNo = value; }
    }
    private string passportNo = "";
    public string PassportNo
    {
        get { return passportNo; }
        set { passportNo = value; }
    }
    private int guestId;
    public int GuestId
    {
        get { return guestId; }
        set { guestId = value; }
    }
    private string emailAddress;
    public string EmailAddress
    {
        get { return emailAddress; }
        set { emailAddress = value; }
    }
    private string contactNo;
    public string ContactNo
    {
        get { return contactNo; }
        set { contactNo = value; }
    }
    private double accBal;

    public double AccBal
    {
        get { return accBal; }
        set { accBal = value; }
    }

    private List<Voucher> voucherList;
    public List<Voucher> VoucherList
    {
        get { return voucherList; }
        set
        {
            if (voucherList != value)
            {
                voucherList = value;
                //voucherList.myGuest = this;
            }
        }
    }
    private ReservationCollection reservationList = new ReservationCollection();

    public ReservationCollection ReservationList
    {
        get { return reservationList; }
    }

    public void addReservation(Reservation r)
    {
        reservationList.Add(r);
    }
    public void addVoucher(Voucher v)
    {
        VoucherList.Add(v);
    }
    public int registerGuest(string name, string emailAddress, string contactNo, string passportNo = "", string icNo = "")
    {

        if (!string.IsNullOrEmpty(name) && (!string.IsNullOrEmpty(passportNo) || !string.IsNullOrEmpty(icNo)) && !string.IsNullOrEmpty(emailAddress) && !string.IsNullOrEmpty(contactNo))
        {
            Guest guest = new Guest(name, passportNo, icNo, emailAddress, contactNo);
            guest.guestId = 1; //to be confirmed
            return guest.guestId;
        }
        else
        {
            Console.WriteLine("Missing Guest Credentials. Please check whether Name, Contact No., Email Address and Passport Number or NRIC are provided. ");
            return 0;
        }
    }
    public bool loginGuest(int idNo, List<Guest> guestList)
    {
        bool guestFound = false;
        foreach (Guest g in guestList)
        {
            if (g.guestId == idNo)
            {
                guestFound = true;
                break;
            }
        }
        return guestFound;
    }

    public void ListAllReservations()
    {
        //iterator pattern for reservation
        int count = 1;
        ReservationIterator iterator = reservationList.createIterator();
        for (Reservation rsvp = iterator.First(); !iterator.IsCompleted; rsvp = iterator.Next())
        {
            if (rsvp.CheckOutDate != null)
            {
                Console.WriteLine(string.Format("[{0}] {1} {2} {3} {4} {5}", count, rsvp.ReservationId,
                rsvp.ReservationDate.ToString("dd/mm/yyyy"), rsvp.CheckInDate.ToString("dd/mm/yyyy")
                , rsvp.CheckOutDate.ToString("dd/mm/yyyy"), rsvp.ReservationStatus.ToString()));
            }
            else
            {
                Console.WriteLine(string.Format("[{0}] {1} {2} {3} {4} {5}", count, rsvp.ReservationId,
                rsvp.ReservationDate.ToString("dd/mm/yyyy"), rsvp.CheckInDate.ToString("dd/mm/yyyy")
                , "--------", rsvp.ReservationStatus.ToString()));
            }
            count++;
        }

    }

    public bool cancelReservation(Reservation reservation)
    {
        ReservationIterator iterator = reservationList.createIterator();
        for (Reservation rsvp = iterator.First(); !iterator.IsCompleted; rsvp = iterator.Next())
        {
            if (rsvp.ReservationId == reservation.ReservationId)
            {
                if (rsvp.ReservationStatus == Reservation.Status.SUBMITTED || rsvp.ReservationStatus == Reservation.Status.CONFIRMED)
                {
                    rsvp.ReservationStatus = Reservation.Status.CANCELLED;
                    return true;
                }
            }
        }
        return false;
    }


    public void makeReview(int rating, string description, Hotel hotel, Reservation res)
    {
        ReservationIterator iterator = reservationList.createIterator();
        for (Reservation rsvp = iterator.First(); !iterator.IsCompleted; rsvp = iterator.Next())
        {
            if (rsvp.ReservationId == res.ReservationId)
            {
                if (rsvp.ReservationStatus == Reservation.Status.FULFILLED)
                {
                    Review newReview = new Review(1,DateTime.Now,hotel.HotelId, guestId,rating,description);
                    hotel.Reviews.Add(newReview);
                }
            }
        }

    }
}
