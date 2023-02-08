using SE_Assignment;

public class Reservation
{


	public enum Status {
		SUBMITTED, //0
		CONFIRMED, //1
		FULFILLED, //2
		CANCELLED, //3
		NO_SHOW //4
	}
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
	private Status reservationStatus;
	public Status ReservationStatus
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
				//ReservedRoomsList.addReservation(this);
				//create new method to add reservation
			}
		}
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
				//value.myReservation = this;
            }
        }
    }
	
	public void makeReservation(DateTime checkInDate, DateTime checkOutDate,List<int> RoomTypeIdList,Guest guest)
    {
		
		Reservation r = new Reservation(checkInDate,checkOutDate);
		r.ReservedByGuest = guest;
		
		if (r.reservationStatus == null)
        {
			r.reservationStatus = Status.SUBMITTED;
			r.reservationDate = DateTime.Today;
			
			r.ReservationId = 0;
			guest.addReservation(r);
		}
		else if (r.reservationStatus == Status.CONFIRMED)
        {
			Console.WriteLine("You have an existing reservation confirmed! You can't rebook the same reservation.");
        }else if (r.reservationStatus == Status.CANCELLED)
        {
			Console.WriteLine("This reservation has been cancelled.");
        }else if (r.reservationStatus == Status.NO_SHOW)
        {
			Console.WriteLine("Error. This existing reservation has been marked as no-show");
        }
		

    }
	public void GuestCheckIn(int reservationId)
    {
		if (reservationStatus == Status.SUBMITTED){
			Console.WriteLine("Payment has not been made yet. Please make payment to confirm this booking.");
        }else if(reservationStatus == Status.CANCELLED)
        {
			Console.WriteLine("This booking has been cancelled. No check-ins allowed.");
        }else if (reservationStatus == Status.NO_SHOW)
        {
			Console.WriteLine("You have exceeded the grace period for checking-in. Sorry, check-in not allowed.");
        }else if (reservationStatus == Status.CONFIRMED)
        {
			if (DateTime.Now == checkInDate && DateTime.Now.Hour < 23 && DateTime.Now.Minute >= 14)//ontime
            {
				reservationStatus = Status.FULFILLED;
				Console.WriteLine("Successfully checked-in to hotel.");

			}
			else
            {
				reservationStatus = Status.NO_SHOW;
				Console.WriteLine("You have exceeded the grace period for checking-in. Sorry, check-in not allowed.");

			}
		}
    }
	public cancelReservation(int ReservationId)
    {
		if (this.reservationStatus == Status.CANCELLED)
        {
			Console.WriteLine("This booking has already been cancelled.");
        }else if(this.reservationStatus == Status.FULFILLED)
        {
			Console.WriteLine("This booking is ongoing as guests have already checked-in");
        }else if (this.reservationStatus == Status.NO_SHOW)
        {
			Console.WriteLine("This booking has already been paid, and cannot be refunded as user failed to check-in ontime.");
        }else if (this.reservationStatus == Status.CONFIRMED)
        {
			Console.WriteLine("This booking has been cancelled successfully. Payment made will be refunded to you.");
			this.reservationStatus = Status.CANCELLED;
			
        }else if (this.reservationStatus == Status.SUBMITTED)
        {
			Console.WriteLine("This booking will has been cancelled successfully. No payment amount has been deducted.");
			this.reservationStatus = Status.CANCELLED;

        }
    }
}
