
public class Facility
{

    public Facility() { }

    public Facility(int facilityId, string facilityName) { 
        
        FacilityId = facilityId;
        FacilityName = facilityName;

    }

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

