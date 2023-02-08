
using SE_Assignment.Iterator;

public class Hotel {

	public Hotel() { }

	public Hotel(int hotelId, string hotelName, string hotelType, string area, bool hasVoucher) {
		HotelId = hotelId; ;
		HotelName = hotelName;
		HotelType = hotelType;
		Area = area;
		HasVoucher = hasVoucher;
		RoomTypes = new RoomTypeCollection();
	}

	private int hotelId;

	public int HotelId {
		get { return hotelId; }
		set { hotelId = value; }
	}

	private string hotelName;

	public string HotelName {
		get { return hotelName; }
		set { hotelName = value; }
	}

	private string hotelType;

	public string HotelType {
		get { return hotelType; }
		set { hotelType = value; }
	}

	private string area;

	public string Area {
		get { return area; }
		set { area = value; }
	}

	private bool hasVoucher;

	public bool HasVoucher {
		get { return hasVoucher; }
		set { hasVoucher = value; }
	}

	private List<Review> reviews;

	public List<Review> Reviews {
		get { return reviews; }
		set { reviews = value; }
	}

	private List<HotelAdmin> hotelAdmins;

	public List<HotelAdmin> HotelAdmins {
		get { return hotelAdmins; }
		set { hotelAdmins = value; }
	}

	private RoomTypeCollection roomTypes;

	public RoomTypeCollection RoomTypes {
		get { return roomTypes; }
		set { roomTypes = value; }
	}

	public List<Review> getReview() {
		return reviews;
	}

	public int getNumOfRooms() {
		return 0;
	}

	public RoomTypeCollection getRoomTypes() {
		return roomTypes;
	}

	public RoomTypeCollection GetRoomTypes(List<Facility> facilities = null, double minAmt = 0.00, double maxAmt = 9999999999999999.99) {
		RoomTypeCollection filteredRoomTypes = new RoomTypeCollection();

		RoomTypeIterator roomTypeIterator = roomTypes.CreateIterator();
		for (RoomType roomType = roomTypeIterator.First();
			!roomTypeIterator.isCompleted;
			roomType = roomTypeIterator.Next()){

			if (roomType.RoomTypeCost >= minAmt && roomType.RoomTypeCost <= maxAmt) {
				if (roomType.hasFacilities(facilities)) {
					filteredRoomTypes.Add(roomType);
				}
			}
		}

		return roomTypes;
	}
	public bool satisfiesFilters (string filterArea = "", double minReviewScore = 0.00, string checkHotelType = "", bool? allowVouchers = null) {
		bool satisfies = true;

		//Check Area
		if (filterArea != "" && filterArea != area) { satisfies = false; }

		//Check Review Score

		//Check hotel type
		if (checkHotelType != "" && checkHotelType != hotelType) { satisfies = false; }

		//Check vouchers 
		if (allowVouchers != null && allowVouchers != hasVoucher) { satisfies = false; }

		return satisfies;
	}
}
