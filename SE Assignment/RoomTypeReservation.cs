
namespace SE_Assignment
{
    public class RoomTypeReservation
    {
        public int RoomTypeId
        {
            set
            {
                roomTypeId = value;
            }
            get
            {
                return RoomTypeId;
            }
        }
        private int roomTypeId;
        private int reservationId;
        public int ReservationId
        {
            set { reservationId = value; }
            get { return reservationId; }
        }
    }
}
