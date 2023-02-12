using System;
namespace SE_Assignment.State
{

    public abstract class ReservationStatus
    {
        protected Reservation? reservation = null;

        public abstract void makeReservation(Reservation r, DateTime checkInDate, DateTime checkOutDate, List<RoomType> RoomTypeList, Guest guest, double reservationPrice);
        public abstract void cancelReservation(Reservation reservation);
        public abstract Review? reviewReservation(int rating, string content, Reservation reservation);


        public abstract void makePayment(double payableAmount, Reservation reservationToPay, Voucher? voucherUsage);
        public abstract void guestCheckIn(Reservation reservation);
        public abstract string getStatusName();
    }

    class SubmittedState : ReservationStatus
    {
        public override void makeReservation(Reservation r, DateTime checkInDate, DateTime checkOutDate, List<RoomType> RoomTypeList, Guest guest,double reservationPrice)
        {
            r.ReservedByGuest = guest;
            r.CheckInDate = checkInDate;
            r.CheckOutDate = checkOutDate;
            r.BookedRoomTypes = RoomTypeList;
            r.ReservationPrice = reservationPrice;
            r.ReservationId = new Random().Next(100, 500);
            r.ReservationDate = DateTime.Today;
            r.ReservedByGuest = guest;
            r.ReservationDate = DateTime.Today;
            
            guest.addReservation(r);
            Console.WriteLine("You will be redirected to Make Payment...");

        }
        public override void guestCheckIn(Reservation r)
        {
            Console.WriteLine("Payment has not been made yet. Please make payment to confirm this booking.");
        }
        public override void cancelReservation(Reservation reservation)
        {
            if (DateTime.Now <= reservation.CheckInDate.AddDays(-2))
            {
                reservation.ReservedByGuest.AccBal += reservation.MyPayment.PayableAmount;
                Console.WriteLine(string.Format("Your new account balance: {0}", reservation.ReservedByGuest.AccBal));
                if (reservation.MyPayment.VoucherUsage != null)
                {
                    reservation.MyPayment.VoucherUsage.IsUsed = false;
                    Console.WriteLine("Voucher used has been returned");
                }
                Console.WriteLine("This booking has been cancelled successfully.");
                //reservation.setState(new CancelledState());
            }
            else
            {
                Console.WriteLine("Current day is not at least 2 days before check in date, cannot cancel");
            }

        }

        public override string getStatusName()
        {
            return "Submitted";
        }

        public override Review? reviewReservation(int rating, string content, Reservation reservation)
        {
            Console.WriteLine("Payment has not been made yet. You are unable to review the hotel");
            return null;
        }
        public override void makePayment(double payableAmount, Reservation reservationToPay, Voucher? voucherUsage)
        {
            reservationToPay.ReservedByGuest.AccBal = reservationToPay.ReservedByGuest.AccBal - payableAmount;
            // Confirm and payment successful
        }

    }
    class ConfirmedState : ReservationStatus
    {
        public override void makeReservation(Reservation r, DateTime checkInDate, DateTime checkOutDate, List<RoomType> RoomTypeList, Guest guest, double reservationPrice)
        {
            Console.WriteLine("You have an existing reservation confirmed! You can't rebook the same reservation.");
        }
        public override void guestCheckIn(Reservation reservation)
        {
            if (DateTime.Now == reservation.CheckInDate && DateTime.Now < new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 0) && DateTime.Now.Hour >= 14)//ontime
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
            if (DateTime.Now <= reservation.CheckInDate.AddDays(-2))
            {
                reservation.ReservedByGuest.AccBal += reservation.MyPayment.PayableAmount;
                Console.WriteLine(string.Format("Your new account balance: {0}", reservation.MyPayment.PayableAmount));
                if (reservation.MyPayment.VoucherUsage != null) {
                    reservation.MyPayment.VoucherUsage.IsUsed = false;
                    Console.WriteLine("Voucher used has been returned");
                }
                Console.WriteLine("This booking has been cancelled successfully.");
                reservation.setState(new CancelledState());
            }
            else
            {
                Console.WriteLine("Current day is not at least 2 days before check in date, cannot cancel");
            }


        }

        public override string getStatusName()
        {
            return "Confirmed";
        }

        public override Review? reviewReservation(int rating, string content, Reservation reservation)
        {
            Console.WriteLine("Your reservation is not completed, please review it after you complete it.");
            return null;
        }
        public override void makePayment(double payableAmount, Reservation reservationToPay, Voucher? voucherUsage)
        {
            Console.WriteLine("Error. Payment has already been made for this confirmed reservation.");
        }

    }
    class FulfilledState : ReservationStatus
    {
        public override void makeReservation(Reservation r, DateTime checkInDate, DateTime checkOutDate, List<RoomType> RoomTypeList, Guest guest, double reservationPrice)
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

        public override string getStatusName()
        {
            return "Fulfilled";
        }

        public override Review reviewReservation(int rating, string content, Reservation reservation)
        {

            Review review = new Review(DateTime.Now, reservation.BookedRoomTypes[0].Hotel, reservation.ReservedByGuest, rating, content);
            return review;
        }
        public override void makePayment(double payableAmount, Reservation reservationToPay, Voucher? voucherUsage)
        {
            Console.WriteLine("Error. Payment has already been made for this reservation. Reservation has also been fulfilled by guest");
        }
    }
    class NoShowState : ReservationStatus
    {
        public override void makeReservation(Reservation r, DateTime checkInDate, DateTime checkOutDate, List<RoomType> RoomTypeList, Guest guest, double reservationPrice)
        {
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

        public override string getStatusName()
        {
            return "No Show";
        }

        public override Review? reviewReservation(int rating, string content, Reservation reservation)
        {
            Console.WriteLine("You are unable to review the hotel.");
            return null;
        }
        public override void makePayment(double payableAmount, Reservation reservationToPay, Voucher? voucherUsage)
        {
            Console.WriteLine("Payment has already been made for this no-show reservation.");
        }

    }
    class CancelledState : ReservationStatus
    {
        public override void makeReservation(Reservation r, DateTime checkInDate, DateTime checkOutDate, List<RoomType> RoomTypeList, Guest guest,double reservationPrice)
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

        public override string getStatusName()
        {
            return "Cancelled";
        }

        public override Review? reviewReservation(int rating, string content, Reservation reservation)
        {
            Console.WriteLine("This booking has already been cancelled, you are unable to review it");
            return null;

        }
        public override void makePayment(double payableAmount, Reservation reservationToPay, Voucher? voucherUsage)
        {
            Console.WriteLine("This booking has been cancelled, no payment is allowed.");
        }

    }
}
