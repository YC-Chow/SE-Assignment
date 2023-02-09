using SE_Assignment;

public class Reservation
{
	~Reservation() { Console.WriteLine("Reservation Record has been deleted"); }
	public Reservation(Guest reservedByGuest, DateTime checkInDate, DateTime? checkOutDate)//constructor
	{
		reservationStatus = new SubmittedState(); //initalise Reservation object to Submitted State
		ReservedByGuest = reservedByGuest;
		this.checkInDate = checkInDate;
		this.checkOutDate = checkOutDate;
        
    }
    public void setState(ReservationStatus state)
	{
		this.reservationStatus = state;
	}
	private int reservationId;
	public int ReservationId
	{
		get { return reservationId; }
		set { reservationId = value; }
	}
	private DateTime reservationDate;
	public DateTime ReservationDate
	{
		get { return reservationDate; }
		set { reservationDate = value; }
	}
	private DateTime checkInDate;
	public DateTime CheckInDate
	{
		get { return checkInDate; }
		set { checkInDate = value; }
	}
	private DateTime? checkOutDate;
	public DateTime? CheckOutDate
	{
		get { return checkOutDate; }
		set { checkOutDate = value; }
	}
	public ReservationStatus ReservationStatus {
		get { return reservationStatus; }
		set { reservationStatus = value; }
	}
	private ReservationStatus reservationStatus;
	private Guest reservedByguest;
	public Guest ReservedByGuest
	{
		get { return reservedByguest; }
		set
		{
			if (reservedByguest != value)
			{
				reservedByguest = value;
				value.addReservation(this);
			}
		}
	}
	private List<RoomType> bookedRoomTypes;
	public List<RoomType> BookedRoomTypes
	{
		get { return bookedRoomTypes; }
		set { bookedRoomTypes = value; }

	}
	private List<RoomTypeReservation> roomReservationList;

	public List<RoomTypeReservation> RoomReservationList {
		get { return roomReservationList; }
		set { roomReservationList = value; }
	}

	private Payment myPayment;
	public Payment MyPayment
	{
		set
		{
			if (myPayment != value)
			{
				myPayment = value;
				value.ReservationToPay = this;
			}
		}
		get
		{
			return myPayment;
		}
	}
	private double reservationPrice;
	public double ReservationPrice
	{
		get { return reservationPrice; }
		set { reservationPrice = value; }
	}
	public double computeReservationTotal(List<RoomType> roomsToBook){
		foreach(RoomType roomType in roomsToBook)
		{
			this.reservationPrice += roomType.RoomTypeCost;
        }
		return this.reservationPrice;
	}

}
