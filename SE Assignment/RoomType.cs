using SE_Assignment.Iterator;

public class RoomType
{
    public RoomType(int roomTypeId, string roomTypeName, int maxNumGuest, double roomTypeCost, bool breakfastServed, string roomDescription) {
        
        this.roomTypeId = roomTypeId;
        this.roomTypeName = roomTypeName;
        this.maxNumGuest = maxNumGuest;
        this.roomTypeCost = roomTypeCost;
        this.breakfastServed = breakfastServed;
        this.roomDescription = roomDescription;
        this.facilities = new FacilityCollection();

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

    private FacilityCollection facilities;
    public FacilityCollection Facilities
    {
        get { return facilities; }
        set { facilities = value; }
    }

    public void listAllFacilities()
    {
        if (facilities.Count > 0)
        {
            Console.WriteLine("This Room Type contains the following facilities:");
            FacilityIterator facilityIterator = facilities.CreateIterator();
            for (Facility facility = facilityIterator.First();
                !facilityIterator.isCompleted;
                facility = facilityIterator.Next())
            {
                Console.WriteLine(string.Format("[{0}] {1}", facility.FacilityId, facility.FacilityName));
            }
        }
        else
        {
            Console.WriteLine("This Room Type does not conain any facilities. ");
        }
    }

    public bool hasFacilities(List<Facility> checkFacilities) {
        bool hasFacilities = true;

        FacilityIterator facilityIterator = facilities.CreateIterator();
        foreach (Facility checkFacility in checkFacilities) {
        
            for (Facility facility = facilityIterator.First();
                !facilityIterator.isCompleted;
                facility = facilityIterator.Next()) {

                if(facility == checkFacility) {
                    continue;
                }

                if (facilityIterator.isCompleted) {
                    hasFacilities = false;
                }
            }
        }

        return hasFacilities;
    }
} 
