using SE_Assignment.Iterator;

public class Guest
{
    public Guest() {}
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
        voucherList = new VoucherCollection();
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
    private VoucherCollection voucherList;
    public VoucherCollection VoucherList
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

    public VoucherCollection getUnUsedVouchers()
    {
        return voucherList;
    }

    private ReservationCollection reservationList = new ReservationCollection();

    public ReservationCollection ReservationList
    {
        get { return reservationList; }
    }

    public void addReservation(Reservation r)
    {
        ReservationList.Add(r);
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

    public List<Reservation> ListAllReservations()
    {
        //iterator pattern for reservation
        int count = 1;
        ReservationIterator iterator = reservationList.createIterator();
        List<Reservation> list = new List<Reservation>();

        //Write the header
        string header = "{0,-5} | {1,-15} | {2,-15} | {3,-15} | {4,-15} | {5,-20}";
        string valueFormat = "[{0}]\t {1,-16} {2,-18} {3,-16} {4,-17} {5,-20}";
        Console.WriteLine(string.Format(header, "No.", "Reservation ID", "Hotel Name", "Check In Date", "Check Out Date", "Reservation Status"));
        for (Reservation rsvp = iterator.First(); !iterator.IsCompleted; rsvp = iterator.Next())
        {
            if (rsvp.CheckOutDate != null)
            {
                Console.WriteLine(string.Format(valueFormat, count, rsvp.ReservationId, rsvp.BookedRoomTypes[0].Hotel.HotelName,
                rsvp.CheckInDate.ToString("dd/MM/yyyy")
                , rsvp.CheckOutDate.Value.ToString("dd/MM/yyyy"), rsvp.ReservationStatus.getStatusName()));
            }
            else
            {
                Console.WriteLine(string.Format(valueFormat, count, rsvp.ReservationId, rsvp.BookedRoomTypes[0].Hotel.HotelName,
                rsvp.CheckInDate.ToString("dd/MM/yyyy")
                , "----------", rsvp.ReservationStatus.getStatusName()));
            }
            list.Add(rsvp);
            count++;
        }

        return list;

    }

    public List<Reservation> ListAllReservationsView()
    {
        //iterator pattern for reservation
        int count = 1;
        ReservationIterator iterator = reservationList.createIterator();
        List<Reservation> list = new List<Reservation>();

        //Write the header
        string header = "{0,-5} | {1,-15} | {2,-15} | {3,-15} | {4,-15} | {5,-20}";
        string valueFormat = "[{0}]\t {1,-16} {2,-18} {3,-16} {4,-17} {5,-20}";

        Console.WriteLine(string.Format(header, "No.", "Reservation ID", "Hotel Name", "Check In Date", "Check Out Date", "Reservation Status"));
        for (Reservation rsvp = iterator.Init(); !iterator.IsCompleted; rsvp = iterator.Looping())
        {
            if (rsvp.CheckOutDate != null)
            {
                Console.WriteLine(string.Format(valueFormat, count, rsvp.ReservationId,rsvp.BookedRoomTypes[0].Hotel.HotelName,
                rsvp.CheckInDate.ToString("dd/MM/yyyy")
                , rsvp.CheckOutDate.Value.ToString("dd/MM/yyyy"), rsvp.ReservationStatus.getStatusName()));
            }
            else
            {
                Console.WriteLine(string.Format(valueFormat, count, rsvp.ReservationId,rsvp.BookedRoomTypes[0].Hotel.HotelName,
                rsvp.CheckInDate.ToString("dd/MM/yyyy")
                , "----------", rsvp.ReservationStatus.getStatusName()));
            }
            if (rsvp.ReservationStatus.getStatusName() != "Cancelled")
            {
                list.Add(rsvp);
                count++;
            }

        }

        return list;

    }



    public void cancelReservation(Reservation reservation)
    {
        ReservationIterator iterator = reservationList.createIterator();
        for (Reservation rsvp = iterator.First(); !iterator.IsCompleted; rsvp = iterator.Next())
        {
            if (rsvp.ReservationId == reservation.ReservationId) {
                rsvp.ReservationStatus.cancelReservation(rsvp);
            }
        }
    }

    public Review? makeReview(int rating, string content,Reservation reservation)
    {
        ReservationIterator iterator = reservationList.createIterator();
        for (Reservation rsvp = iterator.Init(); !iterator.IsCompleted; rsvp = iterator.Looping())
        {
            if (rsvp.ReservationId == reservation.ReservationId)
            {
                Review? review = rsvp.ReservationStatus.reviewReservation(rating,content,rsvp);
                return review;
            }
        }
        return null;
    }
    public VoucherCollection GetUnUsedVouchers()
    {
        VoucherCollection voucherCollection = new VoucherCollection();
        VoucherIterator voucherIterator = voucherList.CreateIterator();

        for (Voucher voucher = voucherIterator.First();
            !voucherIterator.isCompleted;
            voucher = voucherIterator.Next())
        {
            if (voucher != null)
            {
                voucherCollection.Add(voucher);
            }
        }
        return voucherCollection;
    }
}
