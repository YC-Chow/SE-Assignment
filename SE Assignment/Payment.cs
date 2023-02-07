
/// <summary>
/// Summary description for Class1
/// </summary>
/// 
public class Payment
{
    public Payment() { }

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

        private string paymentMethod;
        public string PaymentMethod   // property
        {
            get { return paymentMethod; }   // get method
            set { paymentMethod = value; }  // set method
        }

        private string paymentStatus;
        public string PaymentStatus   // property
        {
            get { return paymentStatus; }   // get method
            set { paymentStatus = value; }  // set method
        }
}
