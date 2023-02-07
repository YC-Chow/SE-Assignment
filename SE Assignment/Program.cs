// See https://aka.ms/new-console-template for more information

using System.Runtime.InteropServices;

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
guest.addReservation(new Reservation(DateTime.Now, DateTime.Now.AddDays(5)) { ReservationId = 1});
guest.addReservation(new Reservation(DateTime.Now, DateTime.Now.AddDays(7)) { ReservationId = 2});
guest.addReservation(new Reservation(DateTime.Now, DateTime.Now.AddDays(8)) { ReservationId = 3});
guest.addReservation(new Reservation(DateTime.Now, DateTime.Now.AddDays(9)) { ReservationId = 4});

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
    if (opt >= guest.ReservationList.Count) {
        Console.WriteLine("not valid option");
    }
    else {
        bool success = guest.cancelReservation(guest.ReservationList.GetReservation(opt));
        if (success) {
            Console.WriteLine("Reservation sucessfully cancelled");
        }
        else {
            Console.WriteLine("Reservation cancelled failed");
        }
    }
}
