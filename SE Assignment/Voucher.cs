using System;

/// <summary>
/// Summary description for Class1
/// </summary>
/// 
public class Voucher
{
    public Voucher(int VOUCHERiD) 
    { }
   
    private int voucherId;
    public int VoucherId   // property
    {
        get { return voucherId; }   // get method
        set { voucherId = value; }  // set method
    }

    private string serialNo;
    public string SerialNo   // property
    {
        get { return serialNo; }   // get method
        set { serialNo = value; }  // set method
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
