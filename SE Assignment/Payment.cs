
using SE_Assignment;
/// <summary>
/// Summary description for Class1
/// </summary>
/// 
public class Payment
{
    public Payment(int transactionId, Reservation reservationToPay, double payableAmount)
    {
        TransactionId = transactionId;
        ReservationToPay = reservationToPay;
        PayableAmount = payableAmount;
    }

    private int transactionId;

    public int TransactionId   // property
    {
        get { return transactionId; }   // get method
        set { transactionId = value; }  // set method
    }

    private double payableAmount;
    public double PayableAmount   // property
    {
        get { return payableAmount; }   // get method
        set { payableAmount = value; }  // set method
    }

    private Reservation reservationToPay;
    public Reservation ReservationToPay
    {
        get { return reservationToPay; }
        set { reservationToPay = value; }
    }

    private Voucher voucherUsage;
    public Voucher VoucherUsage
    {
        get { return voucherUsage; }
        set { voucherUsage = value; }
    }

    public void makePayment(double payableAmount, Reservation reservationToPay, Voucher? voucherUsage)
    {
        reservationToPay.ReservedByGuest.AccBal = reservationToPay.ReservedByGuest.AccBal - payableAmount;
        reservationToPay.setState(new ConfirmedState());
        // Confirm and payment successful
    }

    public double checkdiscountedprice(double payableAmount,Voucher? voucherUsage) 
    {
        if (voucherUsage != null)
        {
            payableAmount = payableAmount - voucherUsage.VoucherValue;
        }
        return payableAmount;

    }
}

