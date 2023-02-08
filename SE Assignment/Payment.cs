
using SE_Assignment;
/// <summary>
/// Summary description for Class1
/// </summary>
/// 
public class Payment
{
    public Payment(Reservation reservationToPay,string transactionId,double payableAmount,string paymentStatus,Voucher? voucherUsage) 
    {
        ReservationToPay = reservationToPay;
        TransactionId = transactionId;
        PayableAmount = payableAmount;
        PaymentStatus = paymentStatus;
        VoucherUsage = voucherUsage;
    }

        private string transactionId;

        public string TransactionId   // property
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

        private string paymentStatus;
        public string PaymentStatus   // property
        {
            get { return paymentStatus; }   // get method
            set { paymentStatus = value; }  // set method
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

    public bool makePayment(double payableAmount,Reservation reservationToPay)
    {
        
        if(voucherUsage!=null)
        {
            //enough money in account balance
            if (reservationToPay.ReservedByGuest.AccBal > 0)
            {
                //make calculation for both voucher and acc deduction
                reservationToPay.setState(new ConfirmedState());
                return true;
            }
            // prompt user to add money into account
        }
        //else do base calculation
        return false;
    }
}
