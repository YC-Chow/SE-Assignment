// See https://aka.ms/new-console-template for more information

List<string> options = new List<string>() {
    "Browse Hotel Rooms", 
    "Make Hotel Reservation",
    "View Booking History" , 
    "Cancel Reservation", 
    "Make a rating and review",
    "Make payment"
};

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
        }
    }
}

void displayOptions() {
    foreach(string option in options) {
        Console.WriteLine(string.Format("[{0}] {1}", options.IndexOf(option) + 1, option));
    }
    Console.WriteLine("[0] Exit");
}
