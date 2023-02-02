using System;
using System.Collections;

public class RoomType
{
    public RoomType() { }

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
}
