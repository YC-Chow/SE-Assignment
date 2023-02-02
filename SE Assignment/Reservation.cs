using System;

public class Reservation
{
	public Reservation()//constructor
	{
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
}
