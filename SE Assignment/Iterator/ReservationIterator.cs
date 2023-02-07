
namespace SE_Assignment.Iterator {
    interface ReservationIterator {
        Reservation First();
        Reservation Next();
        bool IsCompleted();
    }
}
