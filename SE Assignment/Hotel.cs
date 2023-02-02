
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
		

		public Hotel() { }

		public double getRating() {
			return 0;
		}

		public int getNumOfRooms() {
			return 0;
		}
    }
}
