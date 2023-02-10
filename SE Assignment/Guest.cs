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
        Console.WriteLine(string.Format("{0} | {1} | {2} | {3} | {4}", "No.", "Reservation ID", "Check In Date", "Check Out Date", "Reservation Status"));
        for (Reservation rsvp = iterator.First(); !iterator.IsCompleted; rsvp = iterator.Next())
        {

            if (rsvp.CheckOutDate != null) {
                Console.WriteLine(string.Format("[{0}]\t\t {1} \t {2} \t {3} \t {4}", count, rsvp.ReservationId,
                rsvp.CheckInDate.ToString("dd/MM/yyyy")
                , rsvp.CheckOutDate.Value.ToString("dd/MM/yyyy"), rsvp.ReservationStatus.getStatusName()));
            }
            else {
                Console.WriteLine(string.Format("[{0}]\t\t {1} \t {2} \t {3} \t {4}", count, rsvp.ReservationId,
                rsvp.CheckInDate.ToString("dd/MM/yyyy")
                , "----------", rsvp.ReservationStatus.getStatusName()));
            }
            list.Add(rsvp);
            count++;
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

    public void makeReview(int rating, string content,Reservation reservation)
    {
        ReservationIterator iterator = reservationList.createIterator();
        for (Reservation rsvp = iterator.First(); !iterator.IsCompleted; rsvp = iterator.Next())
        {
            if (rsvp.ReservationId == reservation.ReservationId)
            {
                rsvp.ReservationStatus.reviewReservation(rating,content,rsvp);
            }
        }
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
