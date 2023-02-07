public class RoomType
{
    public RoomType(int roomTypeId, string roomTypeName, int maxNumGuest, double roomTypeCost, bool breakfastServed, string roomDescription) {
        
        this.roomTypeId = roomTypeId;
        this.roomTypeName = roomTypeName;
        this.maxNumGuest = maxNumGuest;
        this.roomTypeCost = roomTypeCost;
        this.breakfastServed = breakfastServed;
        this.roomDescription = roomDescription;
        this.facilities = new List<Facility>();

    }

    private int roomTypeId;
    public int RoomTypeId {
        get { return roomTypeId; }
        set { roomTypeId = value; }
    }

    private string roomTypeName;
    public string RoomTypeName
    {
        get { return roomTypeName; }
        set { roomTypeName = value; }
    }

    private int maxNumGuest;
    public int MaxNumGuest
    {
        get { return maxNumGuest; }
        set { maxNumGuest = value; }
    }

    private double roomTypeCost;
    public double RoomTypeCost
    {
        get { return roomTypeCost; }
        set { roomTypeCost = value; }
    }

    private bool breakfastServed;
    public bool BreakfastServed
    {
        get { return breakfastServed; }
        set { breakfastServed = value; }
    }

    private string roomDescription;
    public string RoomDescription
    {
        get { return roomDescription; }
        set { roomDescription = value; }
    }

    private List<Facility> facilities;
    public List<Facility> Facilities
    {
        get { return facilities; }
        set { facilities = value; }
    }

    public List<Facility> getFacilities()
    {
        return facilities;
    }
} 
