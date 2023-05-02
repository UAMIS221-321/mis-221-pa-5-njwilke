using System;

namespace mis_221_pa_5_njwilke {
    class Program {
        
        static void Main(string[] args) {
            // Start Main
            Trainer[] myTrainers = new Trainer[100];
            CreateTrainer(myTrainers);
            Listing[] myListings = new Listing[100];
            CreateListing(myListings);
            Booking[] myBookings = new Booking[100];
            CreateBooking(myBookings);
            Rating[] myRatings = new Rating[100];
            CreateRating(myRatings);
            Membership[] myMemberships = new Membership[100];
            CreateMembership(myMemberships);
            StartMenu(myTrainers, myListings, myBookings, myRatings, myMemberships);
            // End main
            // Start Menu
            static void StartMenu(Trainer[] myTrainers, Listing[] myListings, Booking[] myBookings, Rating[] myRatings, Membership[] myMemberships) { // Gets the date from user and routes user to either Admin Portal or Customer Portal
                Console.Clear();
                System.Console.WriteLine("Please enter today's date in a mm/dd/yy format: ");
                string currDate = Console.ReadLine();
                DisplayStartMenu();
                string userChoice = Console.ReadLine();
                while(!IsValidChoice(userChoice)) {
                    System.Console.WriteLine("You entered an invalid input, Please try again");
                    PauseAction();
                    DisplayStartMenu();
                    userChoice = Console.ReadLine();
                }
                if(userChoice == "1") {
                    AdminPortal(myTrainers, myListings, myBookings, myRatings, myMemberships, currDate);
                }
                else if(userChoice == "2") {
                    CustomerPortal(myTrainers, myListings, myBookings, myRatings, myMemberships, currDate);
                }
            }
            static bool IsValidChoice(string userChoice) { // Checks to make sure user input for StartMenu is a valid option
                if(userChoice == "1" || userChoice == "2" || userChoice == "3") {
                    return true;
                }
                else return false;
            }
            static void DisplayStartMenu() { // Displays start menu options to user 
                Console.Clear();
                System.Console.WriteLine("Hello, Welcome to the Train Like A Champion Fitness Portal!");
                System.Console.WriteLine("  00000000                                      00000000");
                System.Console.WriteLine(" 0000000000                                    0000000000");
                System.Console.WriteLine("000000000000                                  000000000000");
                System.Console.WriteLine("0000000000000000000000000000000000000000000000000000000000");
                System.Console.WriteLine("0000000000000000000000000000000000000000000000000000000000");
                System.Console.WriteLine("000000000000                                  000000000000");
                System.Console.WriteLine(" 0000000000                                    0000000000");
                System.Console.WriteLine("  00000000                                      00000000");
                System.Console.WriteLine("1:   Enter the Admin Portal");
                System.Console.WriteLine("2:   Enter the Customer Portal");
                System.Console.WriteLine("3:   Exit the Menu");
            }
            static void AdminPortal(Trainer[] myTrainers, Listing[] myListings, Booking[] myBookings, Rating[] myRatings, Membership[] myMemberships, string currDate) { // Forces user to enter a password correctly to continue on to the menu. User's have 5 attempts before getting locked out.
                Console.Clear();
                System.Console.WriteLine("Hello, welcome to the Admin portal\nPlease enter the password to continue");
                string password = Console.ReadLine();
                int guessCount = 0;
                while(password != "Admin" && guessCount < 5) {
                    guessCount++;
                    System.Console.WriteLine($"Invalid password. You have {5 - guessCount} tries left");
                    password = Console.ReadLine();
                }
                if(password == "Admin") {
                    UpdateMemberships(myMemberships, currDate);
                    UpdateByDate(myBookings, currDate);
                    string userInput = GetAdminChoice();
                    while (userInput != "5") {
                        RouteAdmin(userInput, myTrainers, myListings, myBookings, myRatings, myMemberships, currDate);
                        userInput = GetAdminChoice();
                    }
                }
            }
            static void CustomerPortal(Trainer[] myTrainers, Listing[] myListings, Booking[] myBookings, Rating[] myRatings, Membership[] myMemberships, string currDate) { // Gets customer's first and last name in order to autofill any customerName portion
                Console.Clear();
                System.Console.WriteLine("Welcome to the customer portal! Before we begin there are a couple of questions that need to be answered");
                System.Console.WriteLine("What is your first and last name?");
                string customerName = Console.ReadLine();
                System.Console.WriteLine("What is your email?");
                string customerEmail = Console.ReadLine();
                string customerChoice = GetCustomerChoice();
                while(customerChoice != "5") {
                    RouteCustomer(myTrainers, myListings, myBookings, myRatings, customerChoice, myMemberships, currDate, customerName, customerEmail);
                    customerChoice = GetCustomerChoice();
                }
            }
            static void DisplayCustomerMenu() { // Displays the customer portal options
                Console.Clear();
                System.Console.WriteLine("Hello, welcome to the Train Like A Champion customer portal");
                System.Console.WriteLine("1:   Book a Session");
                System.Console.WriteLine("2:   Write a Review");
                System.Console.WriteLine("3:   View Trainer Ratings");
                System.Console.WriteLine("4:   Purchase Membership");
                System.Console.WriteLine("5:   Exit Customer Portal");
            }
            static string GetCustomerChoice() { // Gets customer's choice for the customer portal selections
                DisplayCustomerMenu();
                string userChoice = Console.ReadLine();
                while(!ValidMenuChoice(userChoice)) {
                    System.Console.WriteLine("Invalid menu choice. Please Enter a Valid Menu Choice");
                    DisplayCustomerMenu();
                    userChoice = Console.ReadLine();
                }
                return userChoice;
            }
            static void RouteCustomer(Trainer[] myTrainers, Listing[] myListings, Booking[] myBookings, Rating[] myRatings, string userChoice, Membership[] myMemberships, string currDate, string customerName, string customerEmail) { // Routes customer to appropriate sub-menu based off of userChoice
                if(userChoice == "1") {
                    BookSession(myTrainers, myListings, myBookings, currDate, customerName, customerEmail);
                }
                else if(userChoice == "2") {
                    AddRating(myTrainers, myRatings, customerName);
                }
                else if(userChoice == "3") {
                    RatingsByTrainer(myTrainers, myRatings);
                }
                else if(userChoice == "4") {
                    Memberships(myMemberships, currDate, customerName, customerEmail);
                }
            }
            static string GetAdminChoice(){ // Gets user's choice for admin portal 
                DisplayAdminMenu();
                string userInput = Console.ReadLine();
                while (!ValidMenuChoice(userInput))
                {
                    Console.WriteLine("Invalid menu choice.  Please Enter a Valid Menu Choice");
                    PauseAction();
                    DisplayAdminMenu();
                    userInput = Console.ReadLine();
                }
                return userInput;
            }
            static void DisplayAdminMenu(){ // Displays admin portal
                Console.Clear();
                System.Console.WriteLine("Welcome to the Train Like A Champion Admin Portal!");
                Console.WriteLine("1:   Manage Trainers");
                Console.WriteLine("2:   Manage Listings");
                Console.WriteLine("3:   Bookings");
                Console.WriteLine("4:   Run Reports");
                Console.WriteLine("5:   Exit Menu");
            }
            static bool ValidMenuChoice(string userInput){ // Ensures userInput is a valid menu choice
                if(userInput == "1" || userInput == "2" || userInput == "3" || userInput == "4" || userInput == "5") {
                    return true;
                } else return false;
            }
            static void RouteAdmin(string userInput, Trainer[] myTrainers, Listing[] myListings, Booking[] myBookings, Rating[] myRatings, Membership[] myMemberships, string currDate){ // Route user to desired menu function 
                if(userInput == "1") {
                    ManageTrainers(myTrainers);
                }
                else if(userInput == "2") {
                    ManageListings(myListings, currDate);
                }
                else if(userInput == "3") {
                    Bookings(myTrainers, myListings, myBookings, currDate);
                }
                else if(userInput == "4") {
                    Reports(myBookings, myListings, myRatings, myTrainers, myMemberships);
                }
            }
            static void PauseAction() { // Pauses action before continuing 
                System.Console.WriteLine("Please press any key to continue");
                Console.ReadKey();
            }
            // End Menu
            // Start Trainer
            static string GetUserChoice(string title) { // Gets user's choice for add/edit/delete menu
                Console.Clear();
                System.Console.WriteLine($"What would you like to do today?\n1:   Add a New {title}\n2:   Edit an Existing {title}\n3:   Delete an Existing {title}\n4:   Exit to Main Menu");
                string userChoice = Console.ReadLine();
                return userChoice;
            }
            static void ManageTrainers(Trainer[] myTrainers) { // Populates trainer array and routes user to add/edit/delete menu
                string title = "Trainer";
                string userChoice = GetUserChoice(title);
                while(userChoice != "4") {
                    RouteTrainer(myTrainers, userChoice);
                    userChoice = GetUserChoice(title);
                }
            }
            static void RouteTrainer(Trainer[] myTrainers, string userChoice) { // Routes user to either AddTrainer, EditTrainer, or DeleteTrainer
                if(userChoice == "1") {
                    AddTrainer(myTrainers);
                }
                else if(userChoice == "2") {
                    EditTrainer(myTrainers);
                }
                else if(userChoice == "3") {
                    DeleteTrainer(myTrainers);
                }
            }
            static void CreateTrainer(Trainer[] myTrainers) { // Populates Trainer array from trainers.txt
                StreamReader inFile = new StreamReader("trainers.txt");
                string line = inFile.ReadLine();
                int count = 0;
                while(line != null) {
                    string[] temp = new string[100];
                    temp = line.Split('#');
                    int.TryParse(temp[0], out int x);
                    Trainer newTrainer = new Trainer(x, temp[1], temp[2], temp[3]);
                    myTrainers[count] = newTrainer;
                    count++;
                    line = inFile.ReadLine();
                }
                inFile.Close();
            }
            static void AddTrainer(Trainer[] myTrainers) { // Adds new trainer array and writes it to trainers.txt
                Console.Clear();
                System.Console.WriteLine("Are you sure you'd like to add a new trainer?\nEnter 1 for yes\nEnter any other key for no");
                string userChoice = Console.ReadLine();
                int length = GetTrainerLength(myTrainers);
                int max = myTrainers[length - 1].GetTrainerID();
                for(int i = 0; i < length; i++) {
                    int currID = myTrainers[i].GetTrainerID();
                    if(currID > max) {
                        max = currID;
                    }
                }
                if(userChoice == "1") {
                    Console.Clear();
                    string[] temp = new string[100];
                    System.Console.WriteLine("Please Enter Their Name");
                    temp[0] = Console.ReadLine();
                    System.Console.WriteLine("Please Enter Their Mailing Address");
                    temp[1] = Console.ReadLine();
                    System.Console.WriteLine("Please Enter Their Email");
                    temp[2] = Console.ReadLine();
                    Trainer newTrainer = new Trainer(max + 1, temp[0], temp[1], temp[2]);
                    myTrainers[length] = newTrainer;
                    PrintAllTrainers(myTrainers);
                    System.Console.WriteLine("Your trainer has been added");
                    PauseAction();
                    string title = "add another trainer";
                    if(AskAgain(title)) {
                        AddTrainer(myTrainers);
                    }
                }
            }
            static bool AskAgain(string title) { // Asks user if they would like to repeat any function using a string called title
                Console.Clear();
                System.Console.WriteLine($"Would you like to {title}?\nEnter 1 for yes\nEnter any other key for no");
                string userChoice = Console.ReadLine();
                if(userChoice == "1") {
                    return true;
                }
                else return false;
            }
            static void PrintAllTrainers(Trainer[] myTrainers) { // Writes new trainers to trainers.txt
                StreamWriter inFile = new StreamWriter("trainers.txt");
                int length = GetTrainerLength(myTrainers);
                for(int i = 0; i < length; i++) {
                    int trainerID = myTrainers[i].GetTrainerID();
                    string trainerName = myTrainers[i].GetTrainerName();
                    string mailingAddress = myTrainers[i].GetMailingAddress();
                    string trainerEmail = myTrainers[i].GetTrainerEmail();
                    inFile.WriteLine($"{trainerID}#{trainerName}#{mailingAddress}#{trainerEmail}");
                }
                inFile.Close();
            }
            static void EditTrainer(Trainer[]myTrainers) { // Prompts user to edit a trainer 
                Console.Clear();
                int length = GetTrainerLength(myTrainers);
                System.Console.WriteLine("Are you sure you'd like to edit a trainer today?\nEnter 1 for yes\nEnter any other key for no");
                string userChoice = Console.ReadLine();
                if(userChoice == "1") {
                    ViewTrainers(myTrainers);
                    System.Console.WriteLine("Please enter the Trainer ID of the trainer you would like to edit");
                    int trainerID = int.Parse(Console.ReadLine());
                    for(int i = 0; i < length; i++) {
                        int id = myTrainers[i].GetTrainerID();
                        if(id == trainerID) {
                            Edit(myTrainers, i);
                        }
                    }
                    PrintAllTrainers(myTrainers);
                    Console.Clear();
                    string title = "edit another trainer";
                    if(AskAgain(title)) {
                        EditTrainer(myTrainers);
                    }
                }
            }
            static void Edit(Trainer[] myTrainers, int x) { // Edits selected trainer attribute in trainer array
                ViewTrainer(myTrainers, x);
                System.Console.WriteLine("What would you like to edit?\nPress 1 for Trainer Name, 2 for Mailing Address, or 3 for Email");
                string userChoice = Console.ReadLine();
                if(userChoice == "1") {
                    string currName = myTrainers[x].GetTrainerName();
                    System.Console.WriteLine($"The current name is {currName}\nwhat would you like to set the name to?");
                    myTrainers[x].SetTrainerName(Console.ReadLine());
                }
                else if(userChoice == "2") {
                    string currAddress = myTrainers[x].GetMailingAddress();
                    System.Console.WriteLine($"Their current mailing address is {currAddress}\nWhat would you like the address to be set to?");
                    myTrainers[x].SetMailingAddress(Console.ReadLine());
                }
                else if(userChoice == "3") {
                    string currEmail = myTrainers[x].GetTrainerEmail();
                    System.Console.WriteLine($"Their current email is {currEmail}\nWhat would you like to change their email to?");
                    myTrainers[x].SetTrainerEmail(Console.ReadLine());
                }
                ViewTrainer(myTrainers, x);
                System.Console.WriteLine("Your trainer has been edited");
                string title = "edit anything else";
                if(AskAgain(title)) {
                    Edit(myTrainers, x);
                }
            }
            static void DeleteTrainer(Trainer[] myTrainers) { // Prompts user to delete a trainer
                Console.Clear();
                int length = 0;
                while(myTrainers[length] != null) {
                    length++;
                }
                System.Console.WriteLine("Are you sure you'd like to Delete a Trainer today?\nEnter 1 for yes\nEnter any other key for No");
                string userChoice = Console.ReadLine();
                if(userChoice == "1") {
                    ViewTrainers(myTrainers);
                    System.Console.WriteLine("Please enter the trainer ID of the trainer you would like to delete");
                    int searchID = int.Parse(Console.ReadLine());
                    for(int i = 0; i < length; i++) {
                        int currID = myTrainers[i].GetTrainerID();
                        if(currID == searchID) {
                            Delete(myTrainers, i);
                            System.Console.WriteLine("Your trainer has been deleted");
                            string title = "delete another trainer";
                            if(AskAgain(title)) {
                                DeleteTrainer(myTrainers);
                            }
                        }
                    }
                }
            }
            static void Delete(Trainer[] myTrainers, int x) { // Deletes selected trainer from trainers.txt
                StreamWriter inFile = new StreamWriter("trainers.txt");
                int length = 0;
                while(myTrainers[length] != null) {
                    length++;
                }
                for(int i = 0; i < length; i++) {
                    int trainerID = myTrainers[i].GetTrainerID();
                    string trainerName = myTrainers[i].GetTrainerName();
                    string mailingAddress = myTrainers[i].GetMailingAddress();
                    string trainerEmail = myTrainers[i].GetTrainerEmail();
                    if(myTrainers[i] != myTrainers[x]) {
                        inFile.WriteLine($"{trainerID}#{trainerName}#{mailingAddress}#{trainerEmail}");
                    }
                }
                inFile.Close();
            }
            static void ViewTrainers(Trainer[] myTrainers) { // Displays all current trainers to user
                int length = GetTrainerLength(myTrainers);
                Console.Clear();
                System.Console.WriteLine("These are the current trainers: ");
                for(int i = 0; i < length; i++) {
                    int trainerID = myTrainers[i].GetTrainerID();
                    string trainerName = myTrainers[i].GetTrainerName();
                    string mailingAddress = myTrainers[i].GetMailingAddress();
                    string trainerEmail = myTrainers[i].GetTrainerEmail();
                    Console.WriteLine($"ID: {trainerID}\tName: {trainerName}\nAddress: {mailingAddress}\tEmail: {trainerEmail}");
                }
            }
            static void ViewTrainer(Trainer[] myTrainers, int x) { // Displays selected trainer to user
                int length = GetTrainerLength(myTrainers);
                Console.Clear();

                System.Console.WriteLine("This is the current trainer: ");
                int trainerID = myTrainers[x].GetTrainerID();
                string trainerName = myTrainers[x].GetTrainerName();
                string mailingAddress = myTrainers[x].GetMailingAddress();
                string trainerEmail = myTrainers[x].GetTrainerEmail();
                Console.WriteLine($"ID: {trainerID}\tName: {trainerName}\nAddress: {mailingAddress}\tEmail: {trainerEmail}");
            }
            static int GetTrainerLength(Trainer[] myTrainers) { // Gets length of partially filled Trainer array
                int length = 0;
                while(myTrainers[length] != null) {
                    length++;
                }
                return length;
            }
            // End Trainer
            // Start Listing
            static void ManageListings(Listing[] myListings, string currDate) { // Populates listing array and routes user to GetUserChoice
                string title = "Listing";
                string userChoice = GetUserChoice(title);
                while(userChoice != "4") {
                    RouteListing(myListings, userChoice, currDate);
                    userChoice = GetUserChoice(title);
                }
            }
            static void RouteListing(Listing[] myListings, string userChoice, string currDate) { // Routes user to add/edit/delete listing
                if(userChoice == "1") {
                    AddListing(myListings);
                }
                else if(userChoice == "2") {
                    EditListing(myListings, currDate);
                }
                else if(userChoice == "3") {
                    DeleteListing(myListings, currDate);
                }
            }
            static void CreateListing(Listing[] myListings) { // Populates Listing array from listings.txt
                StreamReader inFile = new StreamReader("listings.txt");
                string line = inFile.ReadLine();
                int count = 0;
                while(line != null) {
                    string[] temp = new string[100];
                    temp = line.Split('#');
                    int.TryParse(temp[0], out int x);
                    double.TryParse(temp[4], out double y);
                    int.TryParse(temp[5], out int z);
                    Listing newListing = new Listing(x, temp[1], temp[2], temp[3], y, z);
                    myListings[count] = newListing;
                    count++;
                    line = inFile.ReadLine();
                }
                inFile.Close();
            }
            static void AddListing(Listing[] myListings) { // Adds a new listing to the listing array
                Console.Clear();
                System.Console.WriteLine("Are you sure you'd like to add a new listing?\nEnter 1 for yes\nEnter any other key for no...");
                string userChoice = Console.ReadLine();
                int length = GetLength(myListings);
                int max = myListings[length - 1].GetListingID();
                for(int i = 0; i < length; i++) {
                    int currID = myListings[i].GetListingID();
                    if(currID > max) {
                        max = currID;
                    }
                }
                if(userChoice == "1") {
                    Console.Clear();
                    string[] temp = new string[100];
                    System.Console.WriteLine("Please enter the name of the trainer running the session");
                    temp[0] = Console.ReadLine();
                    System.Console.WriteLine("Please enter the date of the session");
                    temp[1] = Console.ReadLine();
                    System.Console.WriteLine("Please enter the time of the session");
                    temp[2] = Console.ReadLine();
                    System.Console.WriteLine("Will this session have a reduced cost?\nEnter 1 for yes\nEnter any other key to set the cost to $50");
                    string choice = Console.ReadLine();
                    if(choice == "1") {
                        System.Console.WriteLine("Please enter the cost of the session");
                        temp[3] = Console.ReadLine();
                        while(!IsNumber(temp[3])) {
                            System.Console.WriteLine("Please enter a numeric value: ");
                            temp[3] = Console.ReadLine();
                        }
                    }
                    else temp[3] = "50";
                    System.Console.WriteLine("Please set the availability of the session");
                    temp[4] = Console.ReadLine();
                    while(!IsNumber(temp[4])) {
                        System.Console.WriteLine("Please enter a numeric value: ");
                        temp[4] = Console.ReadLine();
                    }
                    double.TryParse(temp[3], out double cost);
                    int.TryParse(temp[4], out int availability);
                    Listing newListing = new Listing(max + 1, temp[0], temp[1], temp[2], cost, availability);
                    myListings[length] = newListing;
                    PrintAllListings(myListings);
                    System.Console.WriteLine("Your listing has been added");
                    PauseAction();
                    string title = "add another listing";
                    if(AskAgain(title)) {
                        AddListing(myListings);
                    }
                }
            }
            static bool IsNumber(string temp) { // Ensures user input is a numerical value for ints/doubles
                if(double.TryParse(temp, out double x)) {
                    return true;
                }
                else return false;
            }
            static void PrintAllListings(Listing[] myListings) { // Prints all listings to listings.txt
                StreamWriter inFile = new StreamWriter("listings.txt");
                int length = GetLength(myListings);
                SortListingByDate(myListings);
                for(int i = 0; i < length; i++) {
                    string trainerName = myListings[i].GetTrainerName();
                    string listingDate = myListings[i].GetSessionDate();
                    string listingTime = myListings[i].GetSessionTime();
                    double listingCost = myListings[i].GetSessionCost();
                    int listingAvailability = myListings[i].GetSessionAvailability();
                    inFile.WriteLine($"{i + 1}#{trainerName}#{listingDate}#{listingTime}#{listingCost}#{listingAvailability}");
                }
                inFile.Close();
            }
            static void EditListing(Listing[] myListings, string currDate) { // Prompts user to edit a listing
                Console.Clear();
                int length = GetLength(myListings);
                System.Console.WriteLine("Are you sure you'd like to edit a listing today?\nEnter 1 for yes\nEnter any other key for no");
                string userChoice = Console.ReadLine();
                if(userChoice == "1") {
                    ViewListings(myListings, currDate);
                    System.Console.WriteLine("Please enter the session ID of the listing you would like to edit");
                    int searchID = int.Parse(Console.ReadLine());
                    EditChoice(myListings, searchID);
                    System.Console.WriteLine("Your listing has been edited");
                    string title = "edit another listing";
                    if(AskAgain(title)) {
                        EditListing(myListings, currDate);
                    }
                }
                PrintAllListings(myListings);
            }
            static void ViewListings(Listing[] myListings, string currDate) { // Displays all available listings to user
                int length = GetLength(myListings);
                Console.Clear();
                string[] date = new string[100];
                date = currDate.Split('/');
                int.TryParse(date[2], out int x);
                System.Console.WriteLine("These are the current listings available: ");
                for(int i = 0; i < length; i++) {
                    int sessionID = myListings[i].GetListingID();
                    string trainerName = myListings[i].GetTrainerName();
                    string sessionDate = myListings[i].GetSessionDate();
                    string sessionTime = myListings[i].GetSessionTime();
                    double sessionCost = myListings[i].GetSessionCost();
                    int sessionAvailability = myListings[i].GetSessionAvailability();
                    string[] temp = new string[100];
                    temp = sessionDate.Split('/');
                    int.TryParse(temp[2], out int y);
                    if(string.Compare(currDate, sessionDate) < 0 || y > x)
                    System.Console.WriteLine($"ID: {sessionID}\tTrainer: {trainerName}\nDate: {sessionDate}\t Time: {sessionTime}\nCost: {sessionCost}\tAvailable Slots: {sessionAvailability}");
                }
            }
            static void ViewListing(Listing[] myListings, int searchVal) { // Displays selected listing to user
                searchVal--;
                Console.Clear();
                System.Console.WriteLine("This is the current listing: ");
                    int sessionID = myListings[searchVal].GetListingID();
                    string trainerName = myListings[searchVal].GetTrainerName();
                    string sessionDate = myListings[searchVal].GetSessionDate();
                    string sessionTime = myListings[searchVal].GetSessionTime();
                    double sessionCost = myListings[searchVal].GetSessionCost();
                    int sessionAvailability = myListings[searchVal].GetSessionAvailability();
                    System.Console.WriteLine($"ID: {sessionID}\tTrainer: {trainerName}\nDate: {sessionDate}\t Time: {sessionTime}\nCost: {sessionCost}\tAvailable Slots: {sessionAvailability}");
            }
            static void EditChoice(Listing[] myListings, int x) { // Prompts user for which attribute to edit and makes change
                ViewListing(myListings, x);
                System.Console.WriteLine("What would you like to edit?\nEnter 1 for Trainer Name\nEnter 2 for Listing Date\nEnter 3 for Listing Time\nEnter 4 for Listing Cost\nEnter 5 for Listing Availability");
                string userChoice = Console.ReadLine();
                x--;
                Console.Clear();
                if(userChoice == "1") {
                    string currName = myListings[x].GetTrainerName();
                    System.Console.WriteLine($"The current name is {currName}\nwhat would you like to set the name to?");
                    myListings[x].SetTrainerName(Console.ReadLine());
                }
                else if(userChoice == "2") {
                    string currDate = myListings[x].GetSessionDate();
                    System.Console.WriteLine($"The current session date is {currDate}\nWhat would you like the date to be set to?");
                    myListings[x].SetSessionDate(Console.ReadLine());
                }
                else if(userChoice == "3") {
                    string currTime = myListings[x].GetSessionTime();
                    System.Console.WriteLine($"The current session time is {currTime}\nWhat would you like to change the time to?");
                    myListings[x].SetSessionTime(Console.ReadLine());
                }
                else if(userChoice == "4") {
                    double currCost = myListings[x].GetSessionCost();
                    System.Console.WriteLine($"The current cost is set to {currCost}\nWhat would you like to set the cost to?");
                    myListings[x].SetSessionCost(double.Parse(Console.ReadLine()));
                }
                else if(userChoice == "5") {
                    int currAvail = myListings[x].GetSessionAvailability();
                    System.Console.WriteLine($"The current session availability is {currAvail}\nWhat would you like to set the availability to?");
                    myListings[x].SetSessionAvailability(int.Parse(Console.ReadLine()));
                }
                ViewListing(myListings, x + 1);
                string title = "edit anything else";
                if(AskAgain(title)) {
                    EditChoice(myListings, x);
                }
            }
            static void UpdateSessionAvailability(Listing[] myListings, int sessionID) { // Updates listing menu whenever a customer books a listing to take away a spot
                int currentAvailability = myListings[sessionID - 1].GetSessionAvailability();
                myListings[sessionID - 1].SetSessionAvailability(currentAvailability - 1);
                PrintAllListings(myListings);
            }
            static void DeleteListing(Listing[] myListings, string currDate) { // Prompts user to delete a listing
                Console.Clear();
                System.Console.WriteLine("Are you sure you'd like to delete a listing today?\nEnter 1 for yes\nEnter any other key for no");
                string userChoice = Console.ReadLine();
                int length = GetLength(myListings);
                if(userChoice == "1") {
                    Console.Clear();
                    System.Console.WriteLine("These are the current listings available: ");
                    ViewListings(myListings, currDate);
                    System.Console.WriteLine("Please enter the session ID of the listing you would like to delete");
                    int searchID = int.Parse(Console.ReadLine());
                    for(int i = 0; i < length; i++) {
                        int currID = myListings[i].GetListingID();
                        if(currID == searchID) {
                            DeleteChoice(myListings, i);
                            System.Console.WriteLine("The listing has been deleted");
                            PauseAction();
                        }
                    }
                    string title = "delete another listing";
                    if(AskAgain(title)) {
                        DeleteListing(myListings, currDate);
                    }
                }
            }
            static void DeleteChoice(Listing[] myListings, int x) { // Deletes selected listing from listings.txt
                StreamWriter inFile = new StreamWriter("listings.txt");
                int length = GetLength(myListings);
                for(int i = 0; i < length; i++) {
                    int listingID = myListings[i].GetListingID();
                    string trainerName = myListings[i].GetTrainerName();
                    string sessionDate = myListings[i].GetSessionDate();
                    string sessionTime = myListings[i].GetSessionTime();
                    double sessionCost = myListings[i].GetSessionCost();
                    int sessionAvailability = myListings[i].GetSessionAvailability();
                    if(myListings[i] != myListings[x]) {
                        inFile.WriteLine($"{listingID}#{trainerName}#{sessionDate}#{sessionTime}#{sessionCost}#{sessionAvailability}");
                    }
                }
                inFile.Close();
            }
            static int GetLength(Listing[] myListings) { // Gets length of partially filled Listing array
                int length = 0;
                while(myListings[length] != null) {
                    length++;
                }
                return length;
            }
            static void CreateDates2(Listing[] myListings, string[] month, string[] year) { // Creates the month and year arrays for myListing dates
                int length = GetLength(myListings);
                for(int i = 0; i < length; i++) {
                    string[] temp = new string[100];
                    string date = myListings[i].GetSessionDate();
                    temp = date.Split('/');
                    month[i] = temp[0];
                    year[i] = temp[2];
                }
            }
            static void SortListingByDate(Listing[] myListings) { // Sorts listing array by date
                int length = GetLength(myListings);
                string[] month = new string[100];
                string[] year = new string[100];
                CreateDates2(myListings, month, year);
                for(int maxElement = length - 1; maxElement > 0; maxElement--) {
                    for(int index = 0; index < maxElement; index++) {
                        int.TryParse(year[index], out int x);
                        int.TryParse(year[index + 1], out int y);
                        string currDate = myListings[index].GetSessionDate();
                        string compDate = myListings[index + 1].GetSessionDate();
                        if(x == y) {
                            if(string.Compare(currDate, compDate) > 0) {
                                SwapListings(myListings, index, index + 1);
                            }
                        }
                        else if(x > y) {
                            SwapListings(myListings, index, index + 1);
                            SwapYear(year, index, index + 1);
                        }
                    }
                }
            }
            static void SwapListings(Listing[] myListings, int x, int y) { // Swaps listing array 
                Listing temp = new Listing();
                temp = myListings[x];
                myListings[x] = myListings[y];
                myListings[y] = temp;
            }
            // End Listing
            // Start Booking
            static void Bookings(Trainer[] myTrainers, Listing[] myListings, Booking[] myBookings, string currDate) { // routes user to chosen Booking function
                DisplayBookingMenu();
                string userChoice = Console.ReadLine();
                while(!IsValidChoice(userChoice)) {
                    System.Console.WriteLine("Invalid input, please try again");
                    PauseAction();
                    DisplayBookingMenu();
                    userChoice = Console.ReadLine();
                }
                if(userChoice == "1") {
                    BookSessionForCustomer(myTrainers, myListings, myBookings, currDate);
                }
                else if(userChoice == "2") {
                    UpdateStatus(myBookings);
                }
            }
            static void DisplayBookingMenu() { // Display bookings menu to user
                Console.Clear();
                System.Console.WriteLine("Hello, welcome to the bookings portal!\n1:   Book a New Session for a Customer\n2:   Update a Session's Status\n3:   Exit to Main Menu");
            }
            static void CreateBooking(Booking[] myBookings) { // Populates Booking array from transactions.txt
                StreamReader inFile = new StreamReader("transactions.txt");
                string line = inFile.ReadLine();
                int count = 0;
                while(line != null) {
                    string[] temp = new string[100];
                    temp = line.Split('#');
                    int.TryParse(temp[0], out int x);
                    int.TryParse(temp[4], out int y);
                    Booking newBooking = new Booking(x, temp[1], temp[2], temp[3], y, temp[5], temp[6]);
                    myBookings[count] = newBooking;
                    count++;
                    line = inFile.ReadLine();
                }
                inFile.Close();
            }
            static void BookSession(Trainer[] myTrainers, Listing[] myListings, Booking[] myBookings, string currDate, string customerName, string customerEmail) { // Books a new session for customer that pre-fills their first and last name
                Console.Clear();
                System.Console.WriteLine("Are you sure you'd like to book a session?\nEnter 1 for yes\nEnter any other key for no");
                string userChoice = Console.ReadLine();
                if(userChoice == "1") {
                    ViewListings(myListings, currDate);
                    System.Console.WriteLine("Please enter the session ID of the session you would like to book");
                    int sessionID = int.Parse(Console.ReadLine());
                    ViewListing(myListings, sessionID);
                    int length = GetTrainerLength(myTrainers);
                    string[] temp = new string[100];
                    temp[0] = myListings[sessionID - 1].GetSessionDate();
                    temp[1] = myListings[sessionID - 1].GetTrainerName();
                    int trainerID = 0;
                    for(int i = 0; i < length; i++) {
                        string trainerName = myTrainers[i].GetTrainerName();
                        if(trainerName == temp[3]) {
                            trainerID = i + 1;
                        }
                    }
                    int bookingLength = GetBookingLength(myBookings);
                    Booking newBooking = new Booking(sessionID, customerName, customerEmail, temp[0], trainerID, temp[1], "Booked");
                    myBookings[bookingLength] = newBooking;
                    UpdateSessionAvailability(myListings, sessionID);
                    System.Console.WriteLine("You've successfully booked a session");
                    PrintAllBookings(myBookings);
                    string title = "book another session";
                    if(AskAgain(title)) {
                        BookSession(myTrainers, myListings, myBookings, currDate, customerName, customerEmail);
                    }
                }
            }
            static void BookSessionForCustomer(Trainer[] myTrainers, Listing[] myListings, Booking[] myBookings, string currDate) { // books a new session for a customer where admin manually enters their first and last name
                Console.Clear();
                System.Console.WriteLine("Are you sure you'd like to book a session for a customer?\nEnter 1 for yes\nEnter any other key for no");
                string userChoice = Console.ReadLine();
                if(userChoice == "1") {
                    ViewListings(myListings, currDate);
                    System.Console.WriteLine("Please enter the session ID of the session you would like to book");
                    int sessionID = int.Parse(Console.ReadLine());
                    ViewListing(myListings, sessionID);
                    int length = GetTrainerLength(myTrainers);
                    string[] temp = new string[100];
                    System.Console.WriteLine("Please enter the customer's name");
                    temp[0] = Console.ReadLine();
                    System.Console.WriteLine("Please enter the customer's email");
                    temp[1] = Console.ReadLine();
                    temp[2] = myListings[sessionID - 1].GetSessionDate();
                    temp[3] = myListings[sessionID - 1].GetTrainerName();
                    int trainerID = 0;
                    for(int i = 0; i < length; i++) {
                        string trainerName = myTrainers[i].GetTrainerName();
                        if(trainerName == temp[3]) {
                            trainerID = i + 1;
                        }
                    }
                    int bookingLength = GetBookingLength(myBookings);
                    Booking newBooking = new Booking(sessionID, temp[0], temp[1], temp[2], trainerID, temp[3], "Booked");
                    myBookings[bookingLength] = newBooking;
                    UpdateSessionAvailability(myListings, sessionID);
                    System.Console.WriteLine("You've successfully booked a session");
                    PrintAllBookings(myBookings);
                    string title = "book another session";
                    if(AskAgain(title)) {
                        BookSessionForCustomer(myTrainers, myListings, myBookings, currDate);
                    }
                }
            }
            static void PrintAllBookings(Booking[] myBookings) { // Prints all bookings to transactions.txt
                StreamWriter inFile = new StreamWriter("transactions.txt");
                int length = GetBookingLength(myBookings);
                string[] year = new string[100];
                string[] month = new string[100];
                CreateDates(myBookings, month, year);
                SortByDate(myBookings);
                for(int i = 0; i < length; i++) {
                    int sessionID = myBookings[i].GetSessionID();
                    string customerName = myBookings[i].GetCustomerName();
                    string customerEmail = myBookings[i].GetCustomerEmail();
                    string sessionDate = myBookings[i].GetTrainingDate();
                    int trainerID = myBookings[i].GetTrainerID();
                    string trainerName = myBookings[i].GetTrainerName();
                    string bookingStatus = myBookings[i].GetSessionStatus();
                    inFile.WriteLine($"{sessionID}#{customerName}#{customerEmail}#{sessionDate}#{trainerID}#{trainerName}#{bookingStatus}");
                }
                inFile.Close();
            }
            static int GetBookingLength(Booking[] myBookings) { // Gets length of partially filled Booking array
                int length = 0;
                while(myBookings[length] != null) {
                    length++;
                }
                return length;
            }
            static void UpdateStatus(Booking[] myBookings) { // Updates status of selected booking in Booking array
                Console.Clear();
                System.Console.WriteLine("Are you sure you'd like to update a session today?\nEnter 1 for yes\nEnter any other key for no");
                string userPick = Console.ReadLine();
                if(userPick == "1") {
                    ViewBookings(myBookings);
                    System.Console.WriteLine("Please enter the booking ID of the booking you would like to update");
                    int bookingID = int.Parse(Console.ReadLine());
                    ViewBooking(myBookings, bookingID);
                    System.Console.WriteLine("Please select your update reason\nEnter 1 to update the session to completed\nEnter 2 to update the session to canceled\nEnter any other key to keep the session the same");
                    string userChoice = Console.ReadLine();
                    if(userChoice == "1") {
                        myBookings[bookingID - 1].SetSessionStatus("Completed");
                    }
                    else if(userChoice == "2") {
                        myBookings[bookingID - 1].SetSessionStatus("Canceled");
                    }
                    PrintAllBookings(myBookings);
                    Console.Clear();
                    System.Console.WriteLine("The status has been updated");
                    string title = "update another session";
                    if(AskAgain(title)) {
                        UpdateStatus(myBookings);
                    }
                }
            }
            static void UpdateByDate(Booking[] myBookings, string date) { // Goes through bookings list and updates booking statuses to Complete if the currDate set at beginning is past booking date 
                int length = GetBookingLength(myBookings);
                string[] myDate = new string[100];
                myDate = date.Split('/');
                int.TryParse(myDate[2], out int x);
                for(int i = 0; i < length; i++) {
                    string currDate = myBookings[i].GetTrainingDate();
                    string currStatus = myBookings[i].GetSessionStatus();
                    string[] temp = new string[100];
                    temp = currDate.Split('/');
                    int.TryParse(temp[2], out int y);
                    if(string.Compare(date, currDate) > 0 && x >= y && currStatus == "Booked") {
                        myBookings[i].SetSessionStatus("Completed");
                    }
                }
                PrintAllBookings(myBookings);
            }
            static void ViewBookings(Booking[] myBookings) { // Displays all current bookings to user
                Console.Clear();
                System.Console.WriteLine("These are the current bookings on file: ");
                int length = GetBookingLength(myBookings);
                for(int i = 0; i < length; i++) {
                    int sessionID = myBookings[i].GetSessionID();
                    string customerName = myBookings[i].GetCustomerName();
                    string customerEmail = myBookings[i].GetCustomerEmail();
                    string sessionDate = myBookings[i].GetTrainingDate();
                    int trainerID = myBookings[i].GetTrainerID();
                    string trainerName = myBookings[i].GetTrainerName();
                    string sessionStatus = myBookings[i].GetSessionStatus();
                    System.Console.WriteLine($"\tBooking ID: {i + 1}\nSession ID: {sessionID}\tSession Date: {sessionDate}\nCustomer Name: {customerName}\tCustomer Email: {customerEmail}\nTrainer ID: {trainerID}\tTrainer Name: {trainerName}\n\tSession Status: {sessionStatus}");
                    System.Console.WriteLine("");
                }
            }
            static void ViewBooking(Booking[] myBookings, int x) { // Displays selected booking to user
                x--;
                Console.Clear();
                System.Console.WriteLine("Here is the booking you've selected: ");
                    int sessionID = myBookings[x].GetSessionID();
                    string customerName = myBookings[x].GetCustomerName();
                    string customerEmail = myBookings[x].GetCustomerEmail();
                    string sessionDate = myBookings[x].GetTrainingDate();
                    int trainerID = myBookings[x].GetTrainerID();
                    string trainerName = myBookings[x].GetTrainerName();
                    string sessionStatus = myBookings[x].GetSessionStatus();
                    System.Console.WriteLine($"\tBooking ID: {x + 1}\nSession ID: {sessionID}\tSession Date: {sessionDate}\nCustomer Name: {customerName}\tCustomer Email: {customerEmail}\nTrainer ID: {trainerID}\tTrainer Name: {trainerName}\n\tSession Status: {sessionStatus}");
                    System.Console.WriteLine("");
            }
            static void CreateDates(Booking[] myBookings, string[] month, string[] year) { // Populates month and year array for booking dates
                int length = GetBookingLength(myBookings);
                for(int i = 0; i < length; i++) {
                    string[] temp = new string[100];
                    string date = myBookings[i].GetTrainingDate();
                    temp = date.Split('/');
                    month[i] = temp[0];
                    year[i] = temp[2];
                }
            }
            static void SortByCustomer(Booking[] myBookings) { // Sorts booking array by customer name in alphabetical order
                int length = GetBookingLength(myBookings);
                for(int maxElement = length - 1; maxElement > 0; maxElement--) {
                    for(int index = 0; index < maxElement; index++) {
                        string currName = myBookings[index].GetCustomerName();
                        string compName = myBookings[index + 1].GetCustomerName();
                        if(string.Compare(currName, compName) > 0) {
                            SwapBookings(myBookings, index, index + 1);
                        }
                    }
                }
            }
            static void SortByDate(Booking[] myBookings) { // Sorts booking array by date
                int length = GetBookingLength(myBookings);
                string[] month = new string[100];
                string[] year = new string[100];
                CreateDates(myBookings, month, year);
                for(int maxElement = length - 1; maxElement > 0; maxElement--) {
                    for(int index = 0; index < maxElement; index++) {
                        int.TryParse(year[index], out int x);
                        int.TryParse(year[index + 1], out int y);
                        string currDate = myBookings[index].GetTrainingDate();
                        string compDate = myBookings[index + 1].GetTrainingDate();
                        if(x == y) {
                            if(string.Compare(currDate, compDate) > 0) {
                                SwapBookings(myBookings, index, index + 1);
                            }
                        }
                        else if(x > y) {
                            SwapBookings(myBookings, index, index + 1);
                            SwapYear(year, index, index + 1);
                        }
                    }
                }
            }
            static void SwapBookings(Booking[] myBookings, int x, int y) { // Swaps booking array
                Booking temp = new Booking();
                temp = myBookings[x];
                myBookings[x] = myBookings[y];
                myBookings[y] = temp; 
            }
            // End Booking
            // Start Rating
            static void CreateRating(Rating[] myRatings) { // Populates ratings array from ratings.txt
                StreamReader inFile = new StreamReader("ratings.txt");
                string line = inFile.ReadLine();
                int count = 0;
                while(line != null) {
                    string[] temp = new string[100];
                    temp = line.Split('#');
                    int.TryParse(temp[0], out int x);
                    int.TryParse(temp[3], out int y);
                    Rating newRating = new Rating(x, temp[1], temp[2], y, temp[4]);
                    myRatings[count] = newRating;
                    count++;
                    line = inFile.ReadLine();
                }
                inFile.Close();
            }
            static void AddRating(Trainer[] myTrainers, Rating[] myRatings, string customerName) { // Allows a customer to write a review of a trainer
                Console.Clear();
                System.Console.WriteLine("Are you sure you'd like to write a review?\nEnter 1 for yes\nEnter any other key for no");
                string userChoice = Console.ReadLine();
                if(userChoice == "1") {
                    ViewTrainers(myTrainers);
                    System.Console.WriteLine("Please enter the ID of the trainer you would like to rate");
                    int searchID = int.Parse(Console.ReadLine());
                    ViewTrainer(myTrainers, searchID - 1);
                    int length = GetRatingLength(myRatings);
                    string[] temp = new string[100];
                    temp[0] = myTrainers[searchID - 1].GetTrainerName();
                    System.Console.WriteLine("What would you rate this trainer out of 5 stars?");
                    string rating = Console.ReadLine();
                    while(!IsNumber(rating) || string.Compare(rating, "5") > 0) {
                        System.Console.WriteLine("Invalid input, please try again: ");
                        rating = Console.ReadLine();
                    }
                    System.Console.WriteLine("Please write your review of this trainer");
                    temp[1] = Console.ReadLine();
                    int.TryParse(rating, out int x);
                    Rating newRating = new Rating(searchID, temp[0], customerName, x, temp[2]);
                    myRatings[length] = newRating;
                    PrintAllRatings(myRatings);
                    System.Console.WriteLine("Thank you for leaving a review");
                    string title = "write another review";
                    if(AskAgain(title)) {
                        AddRating(myTrainers, myRatings, customerName);
                    }
                }
            }
            static void PrintAllRatings(Rating[] myRatings) { // Writes all ratings to ratings.txt
                StreamWriter inFile = new StreamWriter("ratings.txt");
                int length = GetRatingLength(myRatings);
                SortByID(myRatings);
                for(int i = 0; i < length; i++) {
                    int trainerID = myRatings[i].GetTrainerID();
                    string trainerName = myRatings[i].GetTrainerName();
                    string customerName = myRatings[i].GetCustomerName();
                    int starRating = myRatings[i].GetStarRating();
                    string rating = myRatings[i].GetRating();
                    inFile.WriteLine($"{trainerID}#{trainerName}#{customerName}#{starRating}#{rating}");
                }
                inFile.Close();
            }
            static void SortByID(Rating[] myRatings) { // Sorts ratings by trainerID
                int length = GetRatingLength(myRatings);
                for(int maxElement = length - 1; maxElement > 0; maxElement--) {
                    for(int index = 0; index < maxElement; index++) {
                        int currID = myRatings[index].GetTrainerID();
                        int compID = myRatings[index + 1].GetTrainerID();
                        if(currID > compID) {
                            SwapRatings(myRatings, index, index + 1);
                        }
                    }
                }
            }
            static void SwapRatings(Rating[] myRatings, int x, int y) { // Swaps rating array
                Rating temp = new Rating();
                temp = myRatings[x];
                myRatings[x] = myRatings[y];
                myRatings[y] = temp;
            }
            static int GetRatingLength(Rating[] myRatings) { // Gets length of partially filled rating array
                int length = 0;
                while(myRatings[length] != null) {
                    length++;
                }
                return length;
            }
            static void ViewRatings(Trainer[] myTrainers, Rating[] myRatings) { // Displays all ratings under a specific trainerID
                int length = GetRatingLength(myRatings);
                System.Console.WriteLine("Please enter the Trainer ID you would like to see ratings for");
                int searchID = int.Parse(Console.ReadLine());
                ViewTrainer(myTrainers, searchID - 1);
                for(int i = 0; i < length; i++) {
                    int trainerID = myRatings[i].GetTrainerID();
                    string trainerName = myRatings[i].GetTrainerName();
                    string customerName = myRatings[i].GetCustomerName();
                    int starRating = myRatings[i].GetStarRating();
                    string rating = myRatings[i].GetRating();
                    if(trainerID == searchID) {
                        Console.WriteLine("");
                        System.Console.WriteLine($"Trainer ID: {trainerID}\tTrainer Name: {trainerName}\n{starRating} out of 5 stars\n{rating}");
                    }
                }
                PauseAction();
            }
            // End Rating
            // Start Membership
            static void Memberships(Membership[] myMemberships, string currDate, string customerName, string customerEmail) { // Displays membership menu and routes user to purchase or exit menu based off userchoice
                Console.Clear();
                System.Console.WriteLine("1:   Purchase Membership");
                System.Console.WriteLine("2:   Exit Menu");
                string userChoice = Console.ReadLine();
                while(!IsValidMenuChoice(userChoice)) {
                    System.Console.WriteLine("Invalid choice, please try again");
                    userChoice = Console.ReadLine();
                }
                if(userChoice == "1") {
                    PurchaseMembership(myMemberships, currDate, customerName, customerEmail);
                }
            }
            static void PurchaseMembership(Membership[] myMemberships, string currDate, string customerName, string customerEmail) { // Allows user to purchase a new membership for themselves
                System.Console.WriteLine("A membership will cost $300 for one year and will allow you to have access to all of our facilities outside of training sessions");
                System.Console.WriteLine("Are you sure you'd like to purchase a membership today?\nEnter 1 for yes\nEnter any other key for no");
                string userChoice = Console.ReadLine();
                if(userChoice == "1") {
                    int length = GetMembershipLength(myMemberships);
                    Membership newMembership = new Membership(customerName, customerEmail, 300, currDate, "Active");
                    myMemberships[length] = newMembership;
                    PrintAllMemberships(myMemberships);
                }
            }
            static void PrintAllMemberships(Membership[] myMemberships) { // Writes all memberships to memberships.txt
                StreamWriter inFile = new StreamWriter("memberships.txt");
                int length = GetMembershipLength(myMemberships);
                SortMembershipByDate(myMemberships);
                for(int i = 0; i < length; i++) {
                    string customerName = myMemberships[i].GetCustomerName();
                    string customerEmail = myMemberships[i].GetCustomerEmail();
                    int membershipCost = myMemberships[i].GetMembershipCost();
                    string membershipDate = myMemberships[i].GetMembershipDate();
                    string membershipStatus = myMemberships[i].GetMembershipStatus();
                    inFile.WriteLine($"{customerName}#{customerEmail}#{membershipCost}#{membershipDate}#{membershipStatus}");
                }
                inFile.Close();
            }
            static void UpdateMemberships(Membership[] myMemberships, string date) { // Updates all memberships to Inactive if currDate is over a year past membershipDate
                int length = GetMembershipLength(myMemberships);
                string[] myDate = new string[100];
                myDate = date.Split('/');
                int.TryParse(myDate[2], out int x);
                for(int i = 0; i < length; i++) {
                    string currDate = myMemberships[i].GetMembershipDate();
                    string[] temp = new string[100];
                    string currStatus = myMemberships[i].GetMembershipStatus();
                    temp = currDate.Split('/');
                    int.TryParse(temp[2], out int y);
                    if(string.Compare(date, currDate) > 0 && x > y && currStatus == "Active") {
                        myMemberships[i].SetMembershipStatus("Inactive");
                    }
                }
                PrintAllMemberships(myMemberships);
            }
            static void SortMembershipByDate(Membership[] myMemberships) { // Sorts membership array by date
                int length = GetMembershipLength(myMemberships);
                string[] month = new string[100];
                string[] year = new string[100];
                CreateDates3(myMemberships, month, year);
                for(int maxElement = length - 1; maxElement > 0; maxElement--) {
                    for(int index = 0; index < maxElement; index++) {
                        int.TryParse(year[index], out int x);
                        int.TryParse(year[index + 1], out int y);
                        string currDate = myMemberships[index].GetMembershipDate();
                        string compDate = myMemberships[index + 1].GetMembershipDate();
                        if(x == y) {
                            if(string.Compare(currDate, compDate) > 0) {
                                SwapMemberships(myMemberships, index, index + 1);
                            }
                        }
                        else if(x > y) {
                            SwapMemberships(myMemberships, index, index + 1);
                            SwapYear(year, index, index + 1);
                        }
                    }
                }
            }
            static void SwapMemberships(Membership[] myMemberships, int x, int y) { // Swaps membership array
                Membership temp = new Membership();
                temp = myMemberships[x];
                myMemberships[x] = myMemberships[y];
                myMemberships[y] = temp;
            }           
            static void CreateMembership(Membership[] myMemberships) { // Populates membership array 
                StreamReader inFile = new StreamReader("memberships.txt"); 
                string line = inFile.ReadLine();
                int count = 0;
                while(line != null) {
                    string[] temp = new string[100];
                    temp = line.Split('#');
                    int.TryParse(temp[2], out int x);
                    Membership newMembership = new Membership(temp[0], temp[1], x, temp[3], temp[4]);
                    myMemberships[count] = newMembership;
                    count++;
                    line = inFile.ReadLine();
                }
                inFile.Close();
            }
            static int GetMembershipLength(Membership[] myMemberships) { // Gets length of partially filled membership array
                int length = 0;
                while(myMemberships[length] != null) {
                    length++;
                }
                return length;
            }
            static void CreateDates3(Membership[] myMemberships, string[] temp1, string[] temp2) { // Creates month and year arrays for membershipDates
                int length = GetMembershipLength(myMemberships);
                for(int i = 0; i < length; i++) {
                    string[] temp = new string[100];
                    string date = myMemberships[i].GetMembershipDate();
                    temp = date.Split('/');
                    temp1[i] = temp[0];
                    temp2[i] = temp[2];
                }
            }
            // End Membership
            // Start Reports
            static void Reports(Booking[] myBookings, Listing[] myListings, Rating[] myRatings, Trainer[] myTrainers, Membership[] myMemberships) { // Prompts user for menu choice and routes user to chosen function
                DisplayReportMenu();
                string userChoice = Console.ReadLine();
                while(!ValidMenuChoice(userChoice)) {
                    System.Console.WriteLine("Invalid choice, please try again");
                    DisplayReportMenu();
                    userChoice = Console.ReadLine();
                }
                if(userChoice != "5") {
                    RouteReports(userChoice, myTrainers, myBookings, myListings, myRatings, myMemberships);
                }
            }
            static void DisplayReportMenu() { // Displays options for reports 
                Console.Clear();
                System.Console.WriteLine("Hello, please select the report you would like to receive\n1:   View Individual Sessions by Customer\n2:   View Historical Customer Sessions\n3:   View Historical Revenue Information\n4:   View Average Rating per Trainer\n5:   Exit Menu");
            }
            static void RouteReports(string userChoice, Trainer[] myTrainers, Booking[] myBookings, Listing[] myListings, Rating[] myRatings, Membership[] myMemberships) { // Routes user to chosen sub-menu off of userChoice
                if(userChoice == "1") {
                    IndividualHistory(myBookings);
                }
                else if(userChoice == "2") {
                    HistoricalCustomer(myBookings);
                }
                else if(userChoice == "3") {
                    HistoricalRevenue(myBookings, myListings, myMemberships);
                }
                else if(userChoice == "4") {
                    RatingsByTrainer(myTrainers, myRatings);
                }
            }
            static void IndividualHistory(Booking[] myBookings) { // Displays customer history based off of customer email
                Console.Clear();
                System.Console.WriteLine("Please enter the email of the customer you would like to view session history for");
                SortByDate(myBookings);
                string searchEmail = Console.ReadLine();
                int length = GetBookingLength(myBookings);
                Console.Clear();
                for(int i = 0; i < length; i++) {
                    int sessionID = myBookings[i].GetSessionID();
                    string customerName = myBookings[i].GetCustomerName();
                    string customerEmail = myBookings[i].GetCustomerEmail();
                    string sessionDate = myBookings[i].GetTrainingDate();
                    int trainerID = myBookings[i].GetTrainerID();
                    string trainerName = myBookings[i].GetTrainerName();
                    string sessionStatus = myBookings[i].GetSessionStatus();
                    if(searchEmail == customerEmail) {
                        System.Console.WriteLine($"Session ID: {sessionID}\tSession Date: {sessionDate}\nCustomer Name: {customerName}\tCustomer Email: {customerEmail}\nTrainer ID: {trainerID}\tTrainer Name: {trainerName}\nSession Status: {sessionStatus}");
                        System.Console.WriteLine("");
                    }
                }
                if(AskToWrite()) {
                    string[] temp = new string[1000];
                    CreateReport(temp);
                    int tempLength = 0;
                    while(temp[tempLength] != null) {
                        tempLength++;
                    }
                    StreamWriter inFile = new StreamWriter("reports.txt");
                    for(int i = 0; i < tempLength; i++) {
                        inFile.WriteLine(temp[i]);
                    }
                    for(int i = 0; i < length; i++) {
                        int sessionID = myBookings[i].GetSessionID();
                        string customerName = myBookings[i].GetCustomerName();
                        string customerEmail = myBookings[i].GetCustomerEmail();
                        string sessionDate = myBookings[i].GetTrainingDate();
                        int trainerID = myBookings[i].GetTrainerID();
                        string trainerName = myBookings[i].GetTrainerName();
                        string sessionStatus = myBookings[i].GetSessionStatus();
                        if(searchEmail == customerEmail) {
                            inFile.WriteLine($"Session ID: {sessionID}\tSession Date: {sessionDate}\nCustomer Name: {customerName}\tCustomer Email: {customerEmail}\nTrainer ID: {trainerID}\tTrainer Name: {trainerName}\nSession Status: {sessionStatus}");
                        }
                    }
                    inFile.Close();
                }
            }
            static void HistoricalCustomer(Booking[] myBookings) { // Displays all customer bookings and then lists off customer bookings per customer 
                Console.Clear();
                System.Console.WriteLine("This is the historical customer summary: ");
                SortByCustomer(myBookings);
                SortAfter(myBookings);
                ViewBookings(myBookings);
                SessionsByCustomer(myBookings);
            }
            static void HistoricalRevenue(Booking[] myBookings, Listing[] myListings, Membership[] myMemberships) { // Sorts bookings by date and then prints revenue
                Console.Clear();
                SortByDate(myBookings);
                PrintRevenue(myBookings, myListings, myMemberships);
            }
            static void PrintRevenue(Booking[] myBookings, Listing[] myListings, Membership[] myMemberships) { // Prints off revenue report by month and by year. Breaks down where money came from as well
                double totalCost = 0;
                string[] temp1 = new string[100];
                string[] temp2 = new string[100];
                CreateDates3(myMemberships, temp1, temp2);
                string[] month = new string[100];
                string[] year = new string[100];
                CreateDates(myBookings, month, year);
                int length = GetBookingLength(myBookings);
                int membershipLength = GetMembershipLength(myMemberships);
                int count = 0;
                int membershipCount = 0;
                for(int i = 0; i < length - 1; i++) {
                    string sessionStatus = myBookings[i].GetSessionStatus();
                    int sessionID = myBookings[i].GetSessionID();
                    double sessionCost = myListings[sessionID - 1].GetSessionCost();
                    if(temp1[count] == month[i]) {
                        int membershipCost = myMemberships[count].GetMembershipCost();
                        string membershipStatus = myMemberships[count].GetMembershipStatus();
                        if(membershipStatus != "Inactive") {
                            totalCost += membershipCost;
                            membershipCount++;
                            count++;
                        }
                    }
                    if(month[i] == month[i + 1]) {
                        if(sessionStatus != "Canceled") {
                            totalCost += sessionCost;
                        }
                    }
                    else {
                        totalCost += sessionCost;
                        System.Console.WriteLine($"The total revenue for month {month[i]} of year {year[i]} is ${totalCost}");
                        System.Console.WriteLine($"The revenue breakdown includes ${membershipCount * 300} in membership purchases and ${totalCost - (membershipCount * 300)} in training sessions");
                        Console.WriteLine("");
                        totalCost = 0;
                        membershipCount = 0;
                    }    
                }
                if(AskToWrite()) {
                    string[] temp = new string[1000];
                    CreateReport(temp);
                    StreamWriter inFile = new StreamWriter("reports.txt");
                    int tempLength = 0;
                    while(temp[tempLength] != null) {
                        tempLength++;
                    }
                    count = 0;
                    for(int i = 0; i < tempLength; i++) {
                        inFile.WriteLine(temp[i]);
                    }
                    for(int i = 0; i < length - 1; i++) {
                        string sessionStatus = myBookings[i].GetSessionStatus();
                        int sessionID = myBookings[i].GetSessionID();
                        double sessionCost = myListings[sessionID - 1].GetSessionCost();
                        if(temp1[count] == month[i]) {
                            int membershipCost = myMemberships[count].GetMembershipCost();
                            string membershipStatus = myMemberships[count].GetMembershipStatus();
                            if(membershipStatus != "Inactive") {
                                totalCost += membershipCost;
                                membershipCount++;
                                count++;
                            }
                        }
                        if(month[i] == month[i + 1]) {
                            if(sessionStatus != "Canceled") {
                                totalCost += sessionCost;
                            }
                        }
                        else {
                            totalCost += sessionCost;
                            inFile.WriteLine($"The total revenue for month {month[i]} of year {year[i]} is ${totalCost}");
                            inFile.WriteLine($"The revenue breakdown includes ${membershipCount * 300} in membership purchases and ${totalCost - (membershipCount * 300)} in training sessions");
                            totalCost = 0;
                            membershipCount = 0;
                        }    
                    }
                    inFile.Close();
                }
            }
            static void SwapYear(string[] year, int x, int y) { // Swaps years in the year array to ensure SortDate functions with year
                string temp = year[x];
                year[x] = year[y];
                year[y] = temp;
            }
            static void SortAfter(Booking[] myBookings) { // Sorts booking array by date after its been sorted by customer 
                int length = GetBookingLength(myBookings);
                for(int maxElement = length - 1; maxElement > 0; maxElement--) {
                    for(int index = 0; index < maxElement; index++) {
                        string currName = myBookings[index].GetCustomerName();
                        string compName = myBookings[index + 1].GetCustomerName();
                        if(currName == compName) {
                            string currDate = myBookings[index].GetTrainingDate();
                            string compDate = myBookings[index + 1].GetTrainingDate();
                            if(string.Compare(currDate, compDate) > 0) {
                                SwapBookings(myBookings, index, index + 1);
                            }
                        }
                    }
                }
            }
            static void SessionsByCustomer(Booking[] myBookings) { // Displays how many sessions each customer has done
                int length = GetBookingLength(myBookings);
                string curr = myBookings[0].GetCustomerName();
                int sessionCount = 0;
                for(int i = 0; i < length; i++) {
                    if(myBookings[i].GetCustomerName() == curr) {
                        sessionCount += 1;
                    } 
                    else {
                        System.Console.WriteLine($"{curr}:\t\t{sessionCount} total sessions");
                        curr = myBookings[i].GetCustomerName();
                        sessionCount = 1;
                    }
                }
                System.Console.WriteLine($"{curr}:\t\t{sessionCount} total sessions");
                if(AskToWrite()) {
                    string[] temp = new string[1000];
                    CreateReport(temp);
                    int tempLength = 0;
                    while(temp[tempLength] != null) {
                        tempLength++;
                    }
                    curr = myBookings[0].GetCustomerName();
                    StreamWriter inFile = new StreamWriter("reports.txt");
                        for(int i = 0; i < tempLength; i++) {
                            inFile.WriteLine(temp[i]);
                        }
                        for(int i = 0; i < length; i++) {
                            if(myBookings[i].GetCustomerName() == curr) {
                            sessionCount += 1;
                            } 
                        else {
                            inFile.WriteLine($"{curr}:\t\t{sessionCount} total sessions");
                            curr = myBookings[i].GetCustomerName();
                            sessionCount = 1;
                        }
                    }
                inFile.WriteLine($"{curr}:\t\t{sessionCount} total sessions");
                inFile.Close();
                }
            } 
            static void RatingsByTrainer(Trainer[] myTrainers, Rating[] myRatings) { // Displays the average star rating for a trainer across however many reviews
                Console.Clear();
                int length = GetRatingLength(myRatings);
                int currID = myRatings[0].GetTrainerID();
                double average = 0;
                int ratingCount = 0;
                string[] temp = new string[100];
                int reportCount = 0;
                for(int i = 0; i < length; i++) {
                    int starRating = myRatings[i].GetStarRating();
                    if(myRatings[i].GetTrainerID() == currID) {
                        average += starRating;
                        ratingCount++;
                    }
                    else {
                        string trainerName = myTrainers[currID - 1].GetTrainerName();
                        System.Console.WriteLine($"{trainerName} (Trainer ID: {currID}) averaged a rating of {average / ratingCount} stars out of 5 over {ratingCount} ratings");
                        temp[reportCount] = $"{trainerName} (Trainer ID: {currID}) averaged a rating of {average / ratingCount} stars out of 5 over {ratingCount} ratings";
                        reportCount++;
                        ratingCount = 1;
                        average = 0;
                        average += starRating;
                        currID = myRatings[i].GetTrainerID();
                    }
                }
                string trainer = myTrainers[currID - 1].GetTrainerName();
                System.Console.WriteLine($"{trainer} (Trainer ID: {currID}) averaged a rating of {average / ratingCount} stars out of 5 over {ratingCount} ratings");
                if(AskToWrite()) {
                    string[] tempString = new string[1000];
                    CreateReport(tempString);
                    int tempLength = 0;
                    while(tempString[tempLength] != null) {
                        tempLength++;
                    }
                    StreamWriter inFile = new StreamWriter("reports.txt");
                    for(int i = 0; i < tempLength; i++) {
                        inFile.WriteLine(tempString[i]);
                    }
                    for(int i = 0; i < length; i++) {
                        int starRating = myRatings[i].GetStarRating();
                        if(myRatings[i].GetTrainerID() == currID) {
                            average += starRating;
                            ratingCount++;
                        }
                        else {
                            string trainerName = myTrainers[currID - 1].GetTrainerName();
                            inFile.WriteLine($"{trainerName} (Trainer ID: {currID}) averaged a rating of {average / ratingCount} stars out of 5 over {ratingCount} ratings");
                            ratingCount = 1;
                            average = 0;
                            average += starRating;
                            currID = myRatings[i].GetTrainerID();
                        }
                    }
                    inFile.WriteLine($"{trainer} (Trainer ID: {currID}) averaged a rating of {average / ratingCount} stars out of 5 over {ratingCount} ratings");
                    inFile.Close();
                }
                System.Console.WriteLine("Would you like to view ratings for a specific trainer?\nEnter 1 for yes\nEnter 2 for no");
                string userChoice = Console.ReadLine();
                while(!IsValidMenuChoice(userChoice)) {
                    System.Console.WriteLine("Invalid choice, please try again");
                    userChoice = Console.ReadLine();
                }
                if(userChoice == "1") {
                    ViewRatings(myTrainers, myRatings);
                }
            }
            static bool IsValidMenuChoice(string userChoice) { // Ensures userInput is a valid option
                if(userChoice == "1" || userChoice == "2") {
                    return true;
                }
                else return false;
            }
            static bool AskToWrite() { // Asks user if they would like to write a report to reports.txt
                System.Console.WriteLine("Would you like to save this report to a file?\nEnter 1 for yes\nEnter any other key for no");
                string userChoice = Console.ReadLine();
                if(userChoice == "1") {
                    return true;
                }
                else return false;
            }
            static void CreateReport(string[] temp) { // Creates a string array for reports in order to re-write them to reports.txt
                StreamReader inFile = new StreamReader("reports.txt");
                string line = inFile.ReadLine();
                int count = 0;
                while(line != null) {
                    temp[count] = line;
                    count++;
                    line = inFile.ReadLine();
                }
                inFile.Close();
            }
        }
    }
}