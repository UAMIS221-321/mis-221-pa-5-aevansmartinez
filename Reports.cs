namespace mis_221_pa_5_aevansmartinez
{
    public class Reports
    {
        private List<Trainer> trainers = new List<Trainer>();
        private List<Listing> listings = new List<Listing>();
        private List<Booking> bookings = new List<Booking>();
        
        public Reports(List<Trainer> trainers, List<Listing> listings, List<Booking> bookings){
            this.trainers = trainers;
            this.listings = listings;
            this.bookings = bookings;
        }
        public void IndividualCustomer(){
            System.Console.WriteLine("Enter the email of the customer you wish to find:");
            string email = Console.ReadLine();
            int count = 0;
            foreach (Booking session in bookings){
                if (session.GetCustomerEmail() == email){
                    session.ToString();
                    count ++;
                }
            }
            System.Console.WriteLine($"This customer has attended {count} sessions total");
        }
        public void HistoricalCustomer(){
            // Sort the bookings first by customer name and then by date
            bookings.Sort((a, b) =>
            {
                int cmp = string.Compare(a.GetCustomerName(), b.GetCustomerName(), StringComparison.OrdinalIgnoreCase);
                if (cmp != 0)
                    return cmp;
                else
                    return a.GetSessionDate().CompareTo(b.GetSessionDate());
            });

            // Print the count of sessions for each customer
            string lastCustomer = null;
            int sessionCount = 0;
            foreach (Booking booking in bookings)
            {
                if (booking.GetCustomerName() != lastCustomer)
                {
                    if (lastCustomer != null)
                        Console.WriteLine($"{lastCustomer}: {sessionCount} sessions");
                    lastCustomer = booking.GetCustomerName();
                    sessionCount = 0;
                }
                sessionCount++;
            }
            if (lastCustomer != null)
                Console.WriteLine($"{lastCustomer}: {sessionCount} sessions");
        }
        public void HistoricalRevenue(){
            var revenueByMonthYear = new Dictionary<string, decimal>();
            foreach (var booking in bookings)
            {
                if (booking.GetStatus() == "Completed")
                {
                    string monthYear = booking.GetSessionDate().ToString("yyyy-MM");
                    if (!revenueByMonthYear.ContainsKey(monthYear))
                    {
                        revenueByMonthYear[monthYear] = 0;
                    }
                    revenueByMonthYear[monthYear] += booking.GetCost();
                }
            }

            Console.WriteLine("Revenue Report:");
            foreach (var kvp in revenueByMonthYear)
            {
                Console.WriteLine($"Month/Year: {kvp.Key} Total Revenue: {kvp.Value:C}");
            }
        }
        public void SeeSpecificTrainerInfo(){
            string tempPrompt = "Select a trainer:";
            List<string> tempOptions = new List<string>();
            foreach (Trainer trainer in trainers){
                tempOptions.Add(trainer.GetName());
            }
            Menu selectTrainerMenu = new Menu(tempPrompt, tempOptions);
            int selectedIndex = selectTrainerMenu.Run();

            string tName = trainers[selectedIndex].GetName(); 

            System.Console.WriteLine($"All Listings by {tName}: ");
            foreach (Listing listing in listings){
                if (listing.GetTrainerName() == tName){
                    System.Console.WriteLine(listing.ToString());
                }
            }
            System.Console.WriteLine($"\nAll Transactions by {tName}: ");
            foreach (Booking booking in bookings){
                if (booking.GetTrainerName() == tName){
                    System.Console.WriteLine(booking.ToString());
                }
            }


        }
    }
}