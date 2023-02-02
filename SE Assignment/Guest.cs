using System;
using System.Collection;

public class Guest
{

    public Guest()
    {

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
}