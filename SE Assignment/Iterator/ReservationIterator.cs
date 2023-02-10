
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
            while ((!IsCompleted) && collection.GetReservation(current).ReservationStatus.getStatusName() != "Confirmed") {
                current++;
            }
            if (IsCompleted) {
                return null;
            }
            return collection.GetReservation(current);
        }

        public Reservation Next() {
            current += 1;
            //if (!IsCompleted  && (collection.GetReservation(current).ReservationStatus.getStatusName() == "Submitted" ||
            //    collection.GetReservation(current).ReservationStatus.getStatusName() == "Confirmed")) {
            //    return collection.GetReservation(current);
            //}
            //else {
            //    return null;
            //}
            while(!IsCompleted && collection.GetReservation(current).ReservationStatus.getStatusName() != "Confirmed") {
                current++;
            }
            if (IsCompleted) {
                return null;
            }
            return collection.GetReservation(current);
        }

        public bool IsCompleted {
            get { return current >= collection.Count; }
        }

      
    }
}
