
namespace SE_Assignment {
    public class Hotel {

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

		private List<RoomType> roomTypes;

		public List<RoomType> RoomTypes {
			get { return roomTypes; }
			set { roomTypes = value; }
		}


		public Hotel() { }

		public List<Review> getReview() {
			return List<Review> reviews;
		}

		public int getNumOfRooms() {
			return 0;
		}
    }
}
