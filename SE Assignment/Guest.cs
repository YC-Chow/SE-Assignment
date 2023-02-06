using System;
using System.Collection;

public class Guest
{

    public Guest(string name,string passportNo, string icNo, string emailAddress,string contactNo)
    {
        name = name;
        if (icNo != null)
        {
            icNo = icNo;
        }
        if (passportNo != null){
            passportNo = passportNo;
        }  
        emailAddress = emailAddress;
        contactNo = contactNo;
        voucherList = new List<Voucher>();
    }
    private string name;
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    private string icNo = null;
    public string IcNo
    {
        get { return icNo; }
        set { icNo = value; }
    }
    private string passportNo = null;
    public string PassportNo
    {
        get { return passportNo; }
        set { passportNo = value; }
    }
    private int guestId;
    public int GuestId {
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
    private List<Voucher> voucherList;
    public List<Voucher> VoucherList
    {
        get { return voucherList; }
        set
        {
            if (voucherList != value)
            {
                voucherList = value;
                voucherList.myGuest = this;
            }
        }
    }
    private List<Reservation> reservationList;
    public List<Reservation> ReservationList
    {
        set {  reservationList = value;}
        get { return reservationList; }
    }

    public void addReservation(Reservation r)
    {
        ReservationList.Add(r);
    }
    public addVoucher(Voucher v)
    {
        VoucherList.Add(v);
    }
    public int registerGuest(string name,string passportNo = "", string icNo = "" ,string emailAddress,string contactNo)
    {
        
        if (!string.IsNullOrEmpty(name) && (!string.IsNullOrEmpty(passportNo) || !string.IsNullOrEmpty(icNo)) && !string.IsNullOrEmpty(emailAddress) && !string.IsNullOrEmpty(contactNo))
        {
            Guest guest = new Guest(name,passportNo,icNo,emailAddress,contactNo);
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
        foreach(Guest g in guestList)
        {
            if (g.guestId == idNo)
            {
                guestFound == true;
                break;
            }
        }
        return guestFound;
    } 
}