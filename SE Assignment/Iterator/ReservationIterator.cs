
using System.Reflection.PortableExecutable;

namespace SE_Assignment.Iterator {
    public class ReservationIterator {
        private ReservationCollection collection;
        private int current = 0;
        private int step = 1;

        public ReservationIterator(ReservationCollection reservations) { 
            this.collection = reservations;
        }

        public Reservation First() {
            current = 0;
            return collection.GetReservation(current);
        }

        public Reservation Next() {
            current += 1;
            if (!IsCompleted) {
                Reservation rsvp = collection.GetReservation(current);
                if (rsvp.ReservationStatus.getStatusName().Equals("Submitted") ||
                    rsvp.ReservationStatus.getStatusName().Equals("Confirmed")) {
                    return rsvp;
                }
            }
            return null;
        }

        public bool IsCompleted {
            get { return current >= collection.Count; }
        }

      
    }
}
