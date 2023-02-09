// See https://aka.ms/new-console-template for more information


#region Initializing objects
using SE_Assignment;
using SE_Assignment.Iterator;

List<string> options = new List<string>() {
    "Browse Hotel Rooms", 
    "Make Hotel Reservation",
    "View Reservation History" , 
    "Cancel Reservation", 
    "Make a rating and review",
    "Make payment"
};

//List of possible areas for hotels
List<string> areaList = new List<string>()
{
    "Serangoon",
    "Sentosa"
};

//List of possible hotel types
List<string> hotelTypeList = new List<string>()
{
    "Budget",
    "Luxury"
};

//Maunally creating Guest for testing purposes
Guest guest = new Guest("John", "23223", "ssdsdasd", "sdsdssd", "232132131");
new Reservation(guest, DateTime.Now.AddDays(5), DateTime.Now.AddDays(7)) { ReservationId = 2, ReservationStatus = new SubmittedState() };
guest.ReservationList.GetReservation(0).MyPayment = new Payment(guest.ReservationList.GetReservation(0), "sdsd", 100.40, "Paid",
    new Voucher(1, "whoknows", DateTime.Now, false, true));
new Reservation(guest, DateTime.Now, DateTime.Now.AddDays(8)) { ReservationId = 3, ReservationStatus = new ConfirmedState() };
new Reservation(guest, DateTime.Now, DateTime.Now.AddDays(9)) { ReservationId = 4, ReservationStatus = new CancelledState() };
new Reservation(guest, DateTime.Now, DateTime.Now.AddDays(5)) { ReservationId = 1, ReservationStatus = new SubmittedState() };



//Create Facilities
List<Facility> facilityList = new List<Facility>();
Facility facility1 = new Facility(1, "Bathtub");
Facility facility2 = new Facility(2, "Hot water");
Facility facility3 = new Facility(3, "King-Sized bed");
Facility facility4 = new Facility(4, "Balcony");
facilityList.Add(facility1);
facilityList.Add(facility2);
facilityList.Add(facility3);
facilityList.Add(facility4);


//Create Room Types
RoomType roomType1 = new RoomType(1, "Basic", 2, 100.00, false, "basic room");
roomType1.Facilities.Add(facility1);
roomType1.Facilities.Add(facility2);

RoomType roomType2 = new RoomType(2, "Suite", 4, 200.00, true, "Deluxe room");
roomType2.Facilities.Add(facility1);
roomType2.Facilities.Add(facility2);
roomType2.Facilities.Add(facility3);

RoomType roomType3 = new RoomType(3, "Basic", 3, 150.00, false, "basic room");
roomType3.Facilities.Add(facility1);
roomType3.Facilities.Add(facility4);

RoomType roomType4 = new RoomType(4, "Family", 6, 300.00, true, "For the entire family");
roomType4.Facilities.Add(facility1);
roomType4.Facilities.Add(facility2);
roomType4.Facilities.Add(facility3);
roomType4.Facilities.Add(facility4);




//Create Hotels
Hotel hotel1 = new Hotel(1, "Hotel 99", "Budget", "Serangoon", true);
Hotel hotel2 = new Hotel(2, "Hard Jazz Cafe", "Luxury", "Sentosa", false);

roomType1.Hotel = hotel1;
roomType2.Hotel = hotel1;
hotel1.RoomTypes.Add(roomType1);
hotel1.RoomTypes.Add(roomType2);

roomType3.Hotel = hotel2;
roomType4.Hotel = hotel2;
hotel2.RoomTypes.Add(roomType3);
hotel2.RoomTypes.Add(roomType4);

//Hotel Collection
HotelCollection hotelCollection = new HotelCollection();
hotelCollection.Add(hotel1);
hotelCollection.Add(hotel2);

//testing data for review a hotel
Reservation FulfilledRes = new Reservation(guest, DateTime.Now, DateTime.Now.AddDays(4)) { ReservationId = 7, ReservationStatus = new FulfilledState() };
FulfilledRes.BookedRoomTypes = new List<RoomType> { roomType1 };

#endregion

Main();
void Main() {
    bool end = false;
    while (!end) {
        displayOptions();
        Console.Write("Enter your option: ");
        int option = Int32.Parse(Console.ReadLine());
        switch (option) {
            case 0:
                end = true;
                break;

            case 1:
                List<RoomType> bookableRoomTypes = browseHotelRooms();

                Console.Write("Would you like to make a reservation? (Y/N): ");
                string makeReservationOption = Console.ReadLine();
                string addRoomOption = "y";

                while (makeReservationOption.ToLower() != "y" && makeReservationOption.ToLower() != "n") 
                {
                    Console.Write("Enter Y or N only: ");
                    makeReservationOption = Console.ReadLine();
                }

                if (makeReservationOption == "y")
                {
                    List<RoomType> roomsToBook = new List<RoomType>();

                    roomsToBook = selectRooms(bookableRoomTypes, roomsToBook);
                    Console.Write("Do you wish to add more rooms? (Y/N): ");
                    addRoomOption = Console.ReadLine();
                    while (addRoomOption.ToLower() != "y" && addRoomOption.ToLower() != "n")
                    {
                        Console.Write("Enter Y or N only: ");
                        addRoomOption = Console.ReadLine();
                    }

                    while(addRoomOption != "n")
                    {
                        bookableRoomTypes = browseHotelRooms();

                        roomsToBook = selectRooms(bookableRoomTypes, roomsToBook);
                        Console.Write("Do you wish to add more rooms? (Y/N): ");
                        addRoomOption = Console.ReadLine();
                        while (addRoomOption.ToLower() != "y" && addRoomOption.ToLower() != "n")
                        {
                            Console.Write("Enter Y or N only: ");
                            addRoomOption = Console.ReadLine();
                        }
                    }

                    //makeReservation(roomsToBook);
                }
                else
                {
                    continue;
                }

                break;



            case 4:
                cancelReservationOption();
                break;

            case 5:
                reviewReservationOption();
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
    Console.Write("Which reservation to cancel? (0 to exit): ");
    int opt = Int32.Parse(Console.ReadLine());
    if (opt == 0) {
        Console.WriteLine("Exiting");
        return;
    }
    opt -= 1;
    if (opt >= guest.ReservationList.Count || opt < 0) {
        Console.WriteLine("not valid option");
    }
    else {
        guest.cancelReservation(guest.ReservationList.GetReservation(opt));
    }
}

void reviewReservationOption()
{
    guest.ListAllReservations();
    Console.Write("Which reservation to review? ");
    int opt = Int32.Parse(Console.ReadLine());
    if (opt == 0)
    {
        Console.WriteLine("Exiting");
        return;
    }
    opt -= 1;
    if (opt >= guest.ReservationList.Count || opt < 0)
    {
        Console.WriteLine("not valid option");
    }
    else
    {
        if (guest.ReservationList.GetReservation(opt).ReservationStatus.getStatusName() != "Fulfiiled")
        {
            Console.WriteLine("Unable to review it");

        }
        else
        {
            Console.Write("Please enter a rating for the hotel (1-5): ");
            int rating = int.Parse(Console.ReadLine());

            Console.Write("Please enter a short review for the hotel: ");
            string reviewText = Console.ReadLine();

            //guest.makeReview(rating, reviewText, guest.ReservationList.GetReservation(opt));
            Console.WriteLine("Thank you for your review!");
        }



    }
}

List<RoomType> browseHotelRooms()
{
    //Initialize values
    double minAmt = 0.00;
    double maxAmt = 999999999999.99;
    double minReviewScore = 0.00;
    bool? allowVouchers = null;

    List<string> areas = new List<string>();
    List<string> hotelTypes = new List<string>();

    List<Facility> facilitiesToCheck = new List<Facility>();

    //Print Lines
    Console.WriteLine();
    Console.WriteLine("Browsing Hotel Rooms...");
    Console.WriteLine();

    Console.Write("Add filters? (Y/N): ");
    string response = Console.ReadLine();
    Console.WriteLine();

    bool roomSatisfies = false;
    List<RoomType> bookableRoomTypes = new List<RoomType>();

    while (!roomSatisfies)
    {
        if (response.ToLower() == "y")
        {
            Console.WriteLine("Press [enter] to skip filter\n");

            //Input Minimum Cost
            Console.Write("Enter Minimum Cost: ");
            string minAmtString = Console.ReadLine();
            while (!double.TryParse(minAmtString, out minAmt) && minAmtString != "")
            {
                Console.Write("Enter a valid Cost: ");
                minAmtString = Console.ReadLine();
            }
            if (minAmt < 0.00) { minAmt = 0.00; }

            //Input Maximium Cost
            Console.Write("Enter Maximum Cost: ");
            string maxAmtString = Console.ReadLine();
            bool valid = false;
            while (!valid)
            {
                if (double.TryParse(maxAmtString, out maxAmt))
                {
                    if (minAmt <= maxAmt) {valid = true; continue; }
                    else
                    {
                        Console.Write("Enter a valid Cost: ");
                        maxAmtString = Console.ReadLine();
                        continue;
                    }
                }
                else if (maxAmtString == "") { maxAmt = 999999999.99; valid = true; continue; }

                Console.Write("Enter a valid Cost: ");
                maxAmtString = Console.ReadLine();
            }

            //Input Area
            foreach (string a in areaList)
            {
                Console.WriteLine(string.Format("[{0}] {1}", areaList.IndexOf(a) + 1, a));
            }
            Console.Write("Enter Area Index(es): ");
            string areaIndexesString = Console.ReadLine();
            bool areaIndexValid = false;
            while (!areaIndexValid)
            {
                areas = new List<string>();
                if (areaIndexesString == "") { areaIndexValid = true; }
                else
                {
                    List<string> areaIndexesList = areaIndexesString.Split(",").ToList();
                    foreach (string areaIndexString in areaIndexesList)
                    {
                        if (Int32.TryParse(areaIndexString, out int areaIndex))
                        {
                            if (areaIndex > 0 && areaIndex <= areaList.Count)
                            {
                                areas.Add(areaList[areaIndex-1]);
                                areaIndexValid = true;
                            }
                            else { areaIndexValid = false; break; }
                        }
                        else{ areaIndexValid = false; break; }
                    }
                }
                if (!areaIndexValid)
                {
                    Console.Write("Enter valid index(es): ");
                    areaIndexesString = Console.ReadLine();
                }
            }

            //Input Minimum Review Score
            Console.Write("Enter Minimum Review Score: ");
            string minReviewScoreString = Console.ReadLine();
            while (!double.TryParse(minReviewScoreString, out minReviewScore) && minReviewScoreString != "")
            {
                Console.Write("Enter a valid Review Score: ");
                minReviewScoreString = Console.ReadLine();
            }
            if (minReviewScore < 0.00) { minReviewScore = 0.00; }

            //Input Hotel Type
            foreach (string h in hotelTypeList)
            {
                Console.WriteLine(string.Format("[{0}] {1}", hotelTypes.IndexOf(h) + 1, h));
            }
            Console.Write("Enter Hotel Type Index(es): ");
            string hotelIndexesString = Console.ReadLine();
            bool hotelIndexValid = false;
            while (!hotelIndexValid)
            {
                hotelTypes = new List<string>();
                if (hotelIndexesString == "") { hotelIndexValid = true; }
                else
                {
                    List<string> hotelIndexesList = hotelIndexesString.Split(",").ToList();
                    foreach (string hotelIndexString in hotelIndexesList)
                    {
                        if (Int32.TryParse(hotelIndexString, out int hotelIndex))
                        {
                            if (hotelIndex > 0 && hotelIndex <= hotelTypeList.Count)
                            {
                                hotelTypes.Add(hotelTypeList[hotelIndex - 1]);
                                hotelIndexValid = true;
                            }
                            else { hotelIndexValid = false; break; }
                        }
                        else { hotelIndexValid = false; break; }
                    }
                }
                if (!hotelIndexValid)
                {
                    Console.Write("Enter valid index(es): ");
                    areaIndexesString = Console.ReadLine();
                }
            }

            //Input allowing of voucher
            Console.Write("Hotels that allow vouchers? (Y/N): ");
            string voucherResponse = Console.ReadLine();
            if (voucherResponse != "")
            {
                if (voucherResponse.ToLower() == "y") { allowVouchers = true; }
                else { allowVouchers = false; }
            }

            //Input Facilities
            foreach (Facility f in facilityList)
            {
                Console.WriteLine(string.Format("[{0}] {1}", f.FacilityId, f.FacilityName));
            }
            Console.Write("Enter Facility Index(es): ");
            string facilityIndexesString = Console.ReadLine();
            bool facilityIndexValid = false;
            while (!facilityIndexValid)
            {
                facilitiesToCheck = new List<Facility>();
                if (facilityIndexesString == "") { facilityIndexValid = true; }
                else
                {
                    List<string> facilityIndexesList = facilityIndexesString.Split(",").ToList();
                    foreach (string facilityIndexString in facilityIndexesList)
                    {
                        if (Int32.TryParse(facilityIndexString, out int facilityIndex))
                        {
                            if (facilityIndex > 0 && facilityIndex <= facilityList.Count)
                            {                                
                                facilitiesToCheck.Add(facilityList[facilityIndex - 1]);
                                facilityIndexValid = true;
                            }
                            else { facilityIndexValid = false; break; }
                        }
                        else { facilityIndexValid = false; break; }
                    }
                }
                if (!facilityIndexValid)
                {
                    Console.Write("Enter valid index(es): ");
                    facilityIndexesString = Console.ReadLine();
                }
            }
        }
        else { roomSatisfies = true; }

        Console.WriteLine();

        //Iterate through hotels, browse if filters are met
        HotelIterator hotelIterator = hotelCollection.CreateIterator();
        for (Hotel hotel = hotelIterator.First();
            !hotelIterator.isCompleted;
            hotel = hotelIterator.Next())
        {
            if (hotel.satisfiesFilters(areas, minReviewScore, hotelTypes, allowVouchers))
            {
                RoomTypeCollection availableRooms = hotel.GetRoomTypes(facilitiesToCheck, minAmt, maxAmt);
                if (availableRooms.Count > 0)
                {
                    roomSatisfies = true;

                    RoomTypeIterator roomTypeIterator = availableRooms.CreateIterator();

                    for (RoomType roomType = roomTypeIterator.First();
                        !roomTypeIterator.isCompleted;
                        roomType = roomTypeIterator.Next())
                    {
                        bookableRoomTypes.Add(roomType);

                        string breakfastServed = "No";
                        if (roomType.BreakfastServed) { breakfastServed = "Yes"; }

                        Console.WriteLine(string.Format("{0}\t{1}\t\t{2}\t{3}\t{4}\t{5}\t{6}",
                        "ID", "Hotel", "Room Name", "Max Guests", "Cost", "Breakfast?", "Room Description"));

                        Console.WriteLine(string.Format("{0}\t{1}\t{2}\t\t{3}\t\t{4}\t{5}\t\t{6}",
                        roomType.RoomTypeId.ToString(), hotel.HotelName, roomType.RoomTypeName,
                        roomType.MaxNumGuest.ToString(), roomType.RoomTypeCost.ToString(), breakfastServed, roomType.RoomDescription));

                        roomType.listAllFacilities();
                        Console.WriteLine();
                    }
                }
            }
        }

        if (!roomSatisfies)
        {
            Console.WriteLine("There are no rooms that meet your filters. Please try again... ");
            Console.WriteLine();
            continue;
        }
    }
    return bookableRoomTypes;
}

List<RoomType> selectRooms(List<RoomType> bookableRoomTypes, List<RoomType> roomsToBook)
{
    Console.Write("Enter Room ID(s): ");
    string roomIdsString = Console.ReadLine();
    bool roomIdValid = false;
    RoomType tempRoom = new RoomType();
    while (!roomIdValid)
    {
        roomsToBook = new List<RoomType>();
        if (roomIdsString == "") { roomIdValid = true; }
        else
        {
            List<string> roomIdList = roomIdsString.Split(",").ToList();
            foreach (string roomIdString in roomIdList)
            {
                if (Int32.TryParse(roomIdString, out int roomId))
                {
                    foreach (RoomType roomType in bookableRoomTypes)
                    {
                        if (roomType.RoomTypeId == roomId)
                        {
                            tempRoom = roomType;
                            roomIdValid = true;
                            break;
                        }
                    }
                    foreach (RoomType bookedRoomType in roomsToBook)
                    {
                        if (bookedRoomType.RoomTypeId == roomId)
                        {
                            roomIdValid = false;
                            break;
                        }
                    }

                    if (roomIdValid) { roomsToBook.Add(tempRoom); tempRoom = new RoomType(); }

                }
                else { roomIdValid = false; break; }
            }
        }
        if (!roomIdValid)
        {
            Console.Write("Enter valid index(es): ");
            roomIdsString = Console.ReadLine();
        }
    }

    return roomsToBook;
}