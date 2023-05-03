using mis_221_pa_5_aevansmartinez;

using System;
//using System.Collections.Generic;
//using System.Text;
using static System.Console;

namespace mis_221_pa_5_aevansmartinez
{
    public class TLAC
    {
        static List<Trainer> trainers = new List<Trainer>();
        static TrainerUtility trainerUtility = new TrainerUtility(trainers);
        static List<Listing> listings = new List<Listing>();
        static ListingUtility listingUtility = new ListingUtility(listings, trainers);
        static List<Booking> bookings = new List<Booking>();
        static BookingUtility bookingUtility = new BookingUtility(bookings);
        public void SetUp(){
            trainerUtility.GetAllTrainerssFromFile();
            listingUtility.GetAllListingsFromFile();
            bookingUtility.GetAllSessionsFromFile();
        }
        public void RunMainMenu(){
            string tempPrompt = @"                                                                                           
 ______         _         __   _ __          ___      _______                   _         
/_  __/______ _(_)__     / /  (_) /_____    / _ |    / ___/ /  ___ ___ _  ___  (_)__  ___ 
 / / / __/ _ `/ / _ \   / /__/ /  '_/ -_)  / __ |   / /__/ _ \/ _ `/  ' \/ _ \/ / _ \/ _ \
/_/ /_/  \_,_/_/_//_/  /____/_/_/\_\\__/  /_/ |_|   \___/_//_/\_,_/_/_/_/ .__/_/\___/_//_/
                                                                     /_/                
Select an option from below.
(Use the arrow keys to cycle through options. Press enter when you have made a selection)";
    
            List<string> tempOptions = new List<string>{"Manage Trainer Data","Manage Listing Data","Manage Customer Booking Data",
            "Run Reports","Exit"};
            Menu mainMenu = new Menu(tempPrompt, tempOptions);
            int selectedIndex = mainMenu.Run();

            if (selectedIndex == 0) ManageTrainerData();
            else if (selectedIndex == 1) ManageListingData();
            else if (selectedIndex == 2) ManageBookingData();
            else if (selectedIndex == 3) RunReports();
            else Exit();
        }
        private void ManageTrainerData(){
            Clear();

            string tempPrompt = "What would you like to do:";
            List<string> tempOptions = new List<string>{"See All Trainers", "Add a Trainer", "Edit a Trainer", "Delete a Trainer", "Return to Main Menu"};
            Menu trainerMenu = new Menu(tempPrompt, tempOptions);
            int selectedIndex = trainerMenu.Run();

            if (selectedIndex == 0) trainerUtility.PrintAllTrainers();
            else if (selectedIndex == 1) trainerUtility.AddTrainer();
            else if (selectedIndex == 2) trainerUtility.EditTrainer();
            else if (selectedIndex == 3) trainerUtility.DeleteTrainer();
            else RunMainMenu();

            WriteLine("Press any key to continue");
            ReadKey(true);
            ManageTrainerData();
        }
        private void ManageListingData(){
            Clear();

            string tempPrompt = "What would you like to do:";
            List<string> tempOptions = new List<string>{"See All Listings", "Add a Listing", "Edit a Listing", "Delete a Listing", "Return to Main Menu"};
            Menu listingMenu = new Menu(tempPrompt, tempOptions);
            int selectedIndex = listingMenu.Run();

            if (selectedIndex == 0) listingUtility.PrintAllListings();
            else if (selectedIndex == 1) listingUtility.AddListing();
            else if (selectedIndex == 2) listingUtility.EditListing();
            else if (selectedIndex == 3) listingUtility.DeleteListing();
            else RunMainMenu();

            WriteLine("Press any key to continue");
            ReadKey(true);
            ManageListingData();
        }
        /* optimize me*/ private void ManageBookingData(){
            Clear();

            string tempPrompt = "What would you like to do:";
            List<string> tempOptions = new List<string>{"View Available Sessions", "View All Transactions", "Book a Session", "Return to Main Menu"};
            
            Menu bookingMenu = new Menu(tempPrompt, tempOptions);
            int selectedIndex = bookingMenu.Run();

            if (selectedIndex == 0) listingUtility.ViewAvailableSessions();
            else if (selectedIndex == 1) bookingUtility.ViewAllTransactions();
            else if (selectedIndex == 2) BookSession();
            else RunMainMenu();

            WriteLine("Press any key to continue");
            ReadKey(true);
            ManageBookingData();
        }
        private void BookSession(){
            string tempPrompt = "What session would you like to book:";
            List<string> tempOptions = new List<string>();
            for (int i = 0; i< listings.Count(); i++){
                if (listings[i].GetAvailable() == "Available"){
                    System.Console.WriteLine(listings[i].ToStringAvailable());
                    tempOptions.Add($"{listings[i].GetListingID().ToString()} | {listings[i].GetTrainerName()} | {listings[i].GetDateAndTime()}");
                }
            }
            Menu availableSessions = new Menu(tempPrompt, tempOptions);
            int selectedIndex = availableSessions.Run();

            // adding the booking stuff
            string str = tempOptions[selectedIndex].Substring(0,3);
            int ID = int.Parse(str); //finds the listingID of the selected session
            int foundInListing = listingUtility.Find(ID);

            int tempSessID = listings[foundInListing].GetListingID();
            DateTime tempDate = listings[foundInListing].GetDateAndTime();
            string tempTrainerName = listings[foundInListing].GetTrainerName();
            int tempCost = listings[foundInListing].GetCost();

            int foundInTrainer = trainerUtility.Find(tempTrainerName);
            int tempTrainerID = trainers[foundInTrainer].GetID();
            bookingUtility.AddBooking(tempSessID, tempDate, tempTrainerName, tempTrainerID, tempCost);
            
            listings[foundInListing].ChangeStatus("Booked");
            listingUtility.Save();
        }
        /* FIX ME*/private void RunReports(){
            Reports report = new Reports(trainers, listings, bookings);
            Clear();

            string tempPrompt = "What report would you like to see:";
            List<string> tempOptions = new List<string>{"Individual Customer Sessions", "Historical Customer Sessions", "Historical Revenue"};
            tempOptions.Add("Individual Trainer Listings & Bookings");
            tempOptions.Add("Return to Main Menu");
            Menu reportMenu = new Menu(tempPrompt, tempOptions);
            int selectedIndex = reportMenu.Run();

            if (selectedIndex == 0) report.IndividualCustomer();
            else if (selectedIndex == 1) report.HistoricalCustomer();
            else if (selectedIndex == 2) report.HistoricalRevenue();
            else if (selectedIndex == 3) report.SeeSpecificTrainerInfo();
            else RunMainMenu();

            WriteLine("Press any key to continue");
            ReadKey(true);
            RunReports();
        }
        private void Exit(){
            WriteLine("Thank you for visiting Train Like A Champion. See you next time!");
            Environment.Exit(0);
        }
    }
}