public class Facility
{
    public Facility(int facilityId, string facilityName) { 
        
        this.facilityId = facilityId;
        this.facilityName = facilityName;
        this.roomTypes= new List<RoomType>();

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

    private List<RoomType> roomTypes;
    public List<RoomType> RoomTypes
    {
        get { return roomTypes; }
        set { roomTypes = value; }
    }
}

