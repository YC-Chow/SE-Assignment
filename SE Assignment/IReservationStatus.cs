

namespace SE_Assignment
{
     public interface IReservationStatus
     {
        public void makeReservation(DateTime checkInDate, DateTime checkOutDate, List<int> RoomTypeIdList, Guest guest);
        public void cancelReservation(Reservation reservation);

        //public void makePayment(Double amount, int reservationId, string paymentMethod);
        public void guestCheckIn(Reservation reservation);

        public string getStatusName();
     }
    class SubmittedState : IReservationStatus
    {
        public void makeReservation(DateTime checkInDate, DateTime checkOutDate, List<int> RoomTypeIdList, Guest guest)
        {
            Reservation r = new Reservation(guest, checkInDate, checkOutDate);
            r.ReservedByGuest = guest;
            r.ReservationStatus = new ConfirmedState(); 
            r.ReservationDate = DateTime.Today;
            r.ReservationId = 0;
            guest.addReservation(r);
        }
        public void guestCheckIn(Reservation r) {
            Console.WriteLine("Payment has not been made yet. Please make payment to confirm this booking.");
        }
        public void cancelReservation(Reservation reservation)
        {
            Console.WriteLine("This booking has been cancelled successfully. No payment amount has been deducted.");
            reservation.ReservationStatus = new CancelledState();

        }

        public string getStatusName() {
            return "Submitted";
        }
    }
    class ConfirmedState : IReservationStatus
    {
        public void makeReservation(DateTime checkInDate, DateTime checkOutDate, List<int> RoomTypeIdList, Guest guest)
        {
            Console.WriteLine("You have an existing reservation confirmed! You can't rebook the same reservation.");
        }
        public void guestCheckIn(Reservation reservation)
        {
            if (DateTime.Now == reservation.CheckInDate && DateTime.Now < new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day,23,59,0) && DateTime.Now.Hour >= 14)//ontime
            {
                reservation.ReservationStatus = new FulfilledState();
                Console.WriteLine("Successfully checked-in to hotel.");

            }
            else
            {
                reservation.ReservationStatus = new NoShowState();
                Console.WriteLine("You have exceeded the grace period for checking-in. Sorry, check-in not allowed.");

            }

        }
        public void cancelReservation(Reservation reservation)
        {
            Console.WriteLine("This booking has been cancelled successfully. Payment made will be refunded to you.");
            reservation.ReservationStatus = new CancelledState();

        }

        public string getStatusName() {
            return "Confirmed";
        }
    }
    class FulfilledState : IReservationStatus
    {
        public void makeReservation(DateTime checkInDate, DateTime checkOutDate, List<int> RoomTypeIdList, Guest guest)
        {
            Console.WriteLine("Error. An existing reservation with the similarly specified reservation details has been fulfilled");
        }
        public void guestCheckIn(Reservation reservation)
        {
            Console.WriteLine("Error. This reservation has been fulfilled and guests have checked out.");
        }
        public void cancelReservation(Reservation reservation)
        {
            Console.WriteLine("This booking is ongoing as guests have already checked-in");
        }

        public string getStatusName() {
            return "Fulfiiled";
        }
    }
    class NoShowState : IReservationStatus
    {
        public void makeReservation(DateTime checkInDate, DateTime checkOutDate, List<int> RoomTypeIdList, Guest guest) {
            Console.WriteLine("Error. This existing reservation has been marked as no-show");
        }
        public void guestCheckIn(Reservation reservation)
        {
            Console.WriteLine("You have exceeded the grace period for checking-in. Sorry, check-in not allowed.");
        }
        public void cancelReservation(Reservation reservation)
        {
            Console.WriteLine("This booking has already been paid, and cannot be refunded as user failed to check-in ontime.");
        }

        public string getStatusName() {
            return "No Show";
        }
    }
    class CancelledState : IReservationStatus
    {
        public void makeReservation(DateTime checkInDate, DateTime checkOutDate, List<int> RoomTypeIdList, Guest guest)
        {
            Console.WriteLine("This reservation has been cancelled.");
        }
        public void guestCheckIn(Reservation reservation)
        {
            Console.WriteLine("This booking has been cancelled. No check-ins allowed.");
        }
        public void cancelReservation(Reservation reservation)
        {
            Console.WriteLine("This booking has already been cancelled.");
        }

        public string getStatusName() {
            return "Cancelled";
        }
    }
}
