using SE_Assignment.Iterator;

public class Facility
{
    public Facility(int facilityId, string facilityName) { 
        
        this.facilityId = facilityId;
        this.facilityName = facilityName;
        this.roomTypes= new RoomTypeCollection();

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

    private RoomTypeCollection roomTypes;
    public RoomTypeCollection RoomTypes
    {
        get { return roomTypes; }
        set { roomTypes = value; }
    }

    public void listAllRoomTypes() //Lists all room types with the facility
    {
        if (roomTypes.Count > 0)
        {
            Console.WriteLine("The following room types contain this facility");
            RoomTypeIterator roomTypeIterator = roomTypes.CreateIterator();
            for (RoomType roomType = roomTypeIterator.First();
                !roomTypeIterator.isCompleted;
                roomType = roomTypeIterator.Next())
            {
                Console.WriteLine(string.Format("[{0}] {1}", roomType.RoomTypeId, roomType.RoomTypeName));
            }
        }
        else
        {
            Console.WriteLine("There are no room types with such a facility");
        }
    }
}

