
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

    public int makePayment(double payableAmount, Reservation reservationToPay, Voucher? voucherUsage)
    {
        //if user decide to use voucher
        if (voucherUsage != null)
        {
            if(voucherUsage.ExpiryDate > DateTime.Today)
            {
                if (reservationToPay.ReservedByGuest.AccBal > 0)
                {
                    payableAmount = payableAmount - voucherUsage.VoucherValue;
                    reservationToPay.ReservedByGuest.AccBal = reservationToPay.ReservedByGuest.AccBal - payableAmount;
                    Console.WriteLine("Your new balance is:",reservationToPay.ReservedByGuest.AccBal);
                    reservationToPay.setState(new ConfirmedState());
                    return 1;// Confirm and payment successful
                }
                else
                {
                    return 2;//No money, call make payment method again
                }
            }
            else
            {
                //Console.WriteLine("Your voucher has expired\n Please reselect your voucher to use.");
                return 3;

            }
        }
        else
        {
            return 4;
        }
        return 0;
    }
}

