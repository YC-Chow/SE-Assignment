namespace SE_Assignment.Iterator {
    public class ReservationCollection {
        private List<Reservation> reservations = new List<Reservation>();

        public ReservationIterator createIterator() {
            return new ReservationIterator(this);
        }

        public int Count {
            get { return reservations.Count; }
        }

        public void Add(Reservation reservation) {
            reservations.Add(reservation);
        }

        public void Remove(Reservation reservation) {
            reservations.Remove(reservation);
        }

        public Reservation GetReservation(int index) {
            return reservations[index];
        }
    }
}
