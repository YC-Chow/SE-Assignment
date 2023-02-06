using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    class RoomTypeReservation
    {
        public int RoomTypeId
        {
            set
            {
                roomTypeId = value;
            }
            get
            {
                return value;
            }
        }
        private int roomTypeId;
        private int reservationId;
        public int ReservationId
        {
            set { reservationId = value; }
            get { return value; }
        }
    }
}
