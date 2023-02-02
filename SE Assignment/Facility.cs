using System;

public class Facility
{
    public Facility() { }

    private int facilityId;
    public int FacilityId
    {
        get { return facilityId; }
        set { facilityId = value; }
    }

    private string facilityName;
    public string FacilityName
    {
        get { return facilityName; }
        set { facilityName = value; }
    }
}

