using SE_Assignment;

public class Reservation
{
	const int SUBMITTED = 0;
	const int CONFIRMED = 1;
	const int FULFILLED = 2;
	const int CANCELLED = 3;
	const int NO_SHOW = 4;

	public Reservation(DateTime checkInDate,DateTime checkOutDate)//constructor
	{
		this.checkInDate = checkInDate;
		this.checkOutDate = checkOutDate;
		
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
	private DateTime checkOutDate;
	public DateTime CheckOutDate
	{
		get { return checkOutDate; }
		set { checkOutDate = value; }
	}
	private string reservationStatus;
	public string ReservationStatus
	{
		get { return reservationStatus; }
		set { reservationStatus = value; }
	}
	private Guest reservedByguest;
	public Guest ReservedByGuest
	{
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
        set
        {
			if (bookedRoomTypes != value)
            {
				bookedRoomTypes = value;
				value.reservedRoomsList.addReservation(this);
			}
		}
    }
	private List<RoomTypeReservation> roomReservationList;
	public List<RoomTypeReservation> RoomReservationList
    {
        set { roomReservationList = value; }
		get { return value; }
	}
	private Payment myPayment;
	public Payment MyPayment
    {
		set
        {
			if (myPayment != value)
            {
				myPayment = value;
				value.myReservation = this;
            }
        }
    }
	
	public void makeReservation(DateTime checkInDate, DateTime checkOutDate,int roomId,Guest guest)
    {
		
		Reservation r = new Reservation(checkInDate,checkOutDate);
		r.ReservedByGuest = guest;
		
		if (r.reservationStatus == null)
        {
			r.reservationStatus = SUBMITTED;
			r.reservationDate = DateTime.Today();
			
			r.ReservationId = 0;
			guest.addReservation(r);
		}
		else if (r.reservationStatus == CONFIRMED)
        {
			Console.WriteLine("You have an existing reservation confirmed! You can't rebook the same reservation.");
        }else if (r.reservationStatus == CANCELLED)
        {
			Console.WriteLine("This reservation has been cancelled.");
        }else if (r.reservationStatus == NO_SHOW)
        {
			Console.WriteLine("Error. This existing reservation has been marked as no-show");
        }
		

    }
	public void GuestCheckIn(int bookingId)
    {
		if (reservationStatus == SUBMITTED){
			Console.WriteLine("Payment has not been made yet. Please make payment to confirm this booking.");
        }else if(reservationStatus == CANCELLED)
        {
			Console.WriteLine("This booking has been cancelled. No check-ins allowed.");
        }else if (reservationStatus = NO_SHOW)
        {
			Console.WriteLine("You have exceeded the grace period for checking-in. Sorry, check-in not allowed.");
        }else if (reservationStatus == CONFIRMED)
        {
			if (DateTime.Now == checkInDate && DateTime.Now.Hour < 23 && DateTime.Now.Minute >= 14)//ontime
            {
				reservationStatus = FULFILLED;
				Console.WriteLine("Successfully checked-in to hotel.");

			}
			else
            {
				reservationStatus = NO_SHOW;
				Console.WriteLine("You have exceeded the grace period for checking-in. Sorry, check-in not allowed.");

			}
		}
    }
	public void CancelReservation()
    {

    }
}
