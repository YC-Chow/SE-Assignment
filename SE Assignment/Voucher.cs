
public class Voucher
{
    public Voucher(int voucherId, string issuer,double voucherValue, DateTime expiryDate, bool isPercentage, bool isUsed)
    {
        this.voucherId = voucherId;
        this.voucherValue = voucherValue;
        this.issuer = issuer;
        this.expiryDate = expiryDate;
        this.isPercentage = isPercentage;
        this.isUsed = isUsed;
    }

    private int voucherId;
    public int VoucherId   // property
    {
        get { return voucherId; }   // get method
        set { voucherId = value; }  // set method
    }


    private string issuer;
    public string Issuer   // property
    {
        get { return issuer; }   // get method
        set { issuer = value; }  // set method
    }

    private DateTime expiryDate;
    public DateTime ExpiryDate   // property
    {
        get { return expiryDate; }   // get method
        set { expiryDate = value; }  // set method
    }
    private double voucherValue;
    public double VoucherValue   // property
    {
        get { return voucherValue; }   // get method
        set { voucherValue = value; }  // set method
    }
    private bool isPercentage;
    public bool IsPercentage
    {
        get { return isPercentage; }
        set { isPercentage = value; }
    }
    private bool isUsed;
    public bool IsUsed
    {
        get { return isUsed; }
        set { isUsed = value; }
    }
}
