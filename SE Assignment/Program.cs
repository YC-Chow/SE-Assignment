// See https://aka.ms/new-console-template for more information


#region Initializing objects
using SE_Assignment;

List<string> options = new List<string>() {
    "Browse Hotel Rooms", 
    "Make Hotel Reservation",
    "View Booking History" , 
    "Cancel Reservation", 
    "Make a rating and review",
    "Make payment"
};

//Maunally creating Guest for testing purposes
Guest guest = new Guest("John", "23223", "ssdsdasd", "sdsdssd", "232132131");
new Reservation(guest, DateTime.Now, DateTime.Now.AddDays(7)) { ReservationId = 2, ReservationStatus = new SubmittedState()};
new Reservation(guest, DateTime.Now, DateTime.Now.AddDays(8)) { ReservationId = 3, ReservationStatus = new SubmittedState()};
new Reservation(guest, DateTime.Now, DateTime.Now.AddDays(9)) { ReservationId = 4, ReservationStatus = new SubmittedState()};
new Reservation(guest, DateTime.Now.AddDays(3), DateTime.Now.AddDays(5)) { ReservationId = 1, ReservationStatus = new SubmittedState()};
#endregion

main();
void main() {
    bool end = false;
    while (!end) {
        displayOptions();
        Console.Write("Enter your option: ");
        int option = Int32.Parse(Console.ReadLine());
        switch (option) {
            case 0:
                end = true;
                break;
            case 3:
                reviewReservationOption();
                break;

            case 4:
                cancelReservationOption();
                break;

        }
    }
}

void displayOptions() {
    foreach(string option in options) {
        Console.WriteLine(string.Format("[{0}] {1}", options.IndexOf(option) + 1, option));
    }
    Console.WriteLine("[0] Exit");
}

void cancelReservationOption() {
    guest.ListAllReservations();
    Console.Write("Which reservation to cancel? ");
    int opt = Int32.Parse(Console.ReadLine());
    opt -= 1;
    if (opt >= guest.ReservationList.Count || opt <= 0) {
        Console.WriteLine("not valid option");
    }
    else {
        bool success = guest.cancelReservation(guest.ReservationList.GetReservation(opt));
        if (!success) {
            Console.WriteLine("Check in date within two days, cannot cancel");
        }
    }
}

void reviewReservationOption()
{
    guest.ListAllReservations();
    Console.Write("Which reservation to review? ");
    int opt = Int32.Parse(Console.ReadLine());
    opt -= 1;
    if (opt >= guest.ReservationList.Count)
    {
        Console.WriteLine("not valid option");
    }
}