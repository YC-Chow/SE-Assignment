

namespace SE_Assignment
{
     public abstract class ReservationStatus
    {
        protected Reservation? reservation = null;
        public abstract void makeReservation(DateTime checkInDate, DateTime checkOutDate, List<int> RoomTypeIdList, Guest guest);
        public abstract void cancelReservation(Reservation reservation);

        //public void makePayment(Double amount, int reservationId, string paymentMethod);
        public abstract void guestCheckIn(Reservation reservation);
    }
    class SubmittedState : ReservationStatus
    {
        public override void makeReservation(DateTime checkInDate, DateTime checkOutDate, List<int> RoomTypeIdList, Guest guest)
        {
            Reservation r = new Reservation(guest,checkInDate, checkOutDate);
            r.ReservedByGuest = guest;
            r.setState(new ConfirmedState()); 
            r.ReservationDate = DateTime.Today;
            r.ReservationId = 0;
            guest.addReservation(r);
        }
        public override void guestCheckIn(Reservation r) {
            Console.WriteLine("Payment has not been made yet. Please make payment to confirm this booking.");
        }
        public override void cancelReservation(Reservation reservation)
        {
            Console.WriteLine("This booking has been cancelled successfully. No payment amount has been deducted.");
            reservation.setState(new CancelledState());

        }
    }
    class ConfirmedState : ReservationStatus
    {
        public override void makeReservation(DateTime checkInDate, DateTime checkOutDate, List<int> RoomTypeIdList, Guest guest)
        {
            Console.WriteLine("You have an existing reservation confirmed! You can't rebook the same reservation.");
        }
        public override void guestCheckIn(Reservation reservation)
        {
            if (DateTime.Now == reservation.CheckInDate && DateTime.Now < new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day,23,59,0) && DateTime.Now.Hour >= 14)//ontime
            {
                reservation.setState(new FulfilledState());
                Console.WriteLine("Successfully checked-in to hotel.");

            }
            else
            {
                reservation.setState(new NoShowState());
                Console.WriteLine("You have exceeded the grace period for checking-in. Sorry, check-in not allowed.");

            }

        }
        public override void cancelReservation(Reservation reservation)
        {
            Console.WriteLine("This booking has been cancelled successfully. Payment made will be refunded to you.");
            reservation.setState(new CancelledState());

        }
    }
    class FulfilledState : ReservationStatus
    {
        public override void makeReservation(DateTime checkInDate, DateTime checkOutDate, List<int> RoomTypeIdList, Guest guest)
        {
            Console.WriteLine("Error. An existing reservation with the similarly specified reservation details has been fulfilled");
        }
        public override void guestCheckIn(Reservation reservation)
        {
            Console.WriteLine("Error. This reservation has been fulfilled and guests have checked out.");
        }
        public override void cancelReservation(Reservation reservation)
        {
            Console.WriteLine("This booking is ongoing as guests have already checked-in");
        }



    }
    class NoShowState : ReservationStatus
    {
        public override void makeReservation(DateTime checkInDate, DateTime checkOutDate, List<int> RoomTypeIdList, Guest guest) {
            Console.WriteLine("Error. This existing reservation has been marked as no-show");
        }
        public override void guestCheckIn(Reservation reservation)
        {
            Console.WriteLine("You have exceeded the grace period for checking-in. Sorry, check-in not allowed.");
        }
        public override void cancelReservation(Reservation reservation)
        {
            Console.WriteLine("This booking has already been paid, and cannot be refunded as user failed to check-in ontime.");
        }

    }
    class CancelledState : ReservationStatus
    {
        public override void makeReservation(DateTime checkInDate, DateTime checkOutDate, List<int> RoomTypeIdList, Guest guest)
        {
            Console.WriteLine("This reservation has been cancelled.");
        }
        public override void guestCheckIn(Reservation reservation)
        {
            Console.WriteLine("This booking has been cancelled. No check-ins allowed.");
        }
        public override void cancelReservation(Reservation reservation)
        {
            Console.WriteLine("This booking has already been cancelled.");
        }

    }
}
