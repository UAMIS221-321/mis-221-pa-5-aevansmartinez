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
        /*
        public void HistoricalCustomer(){
            public void Sort(){
            for (int i =0 ; i < Book.GetCount() - 1; i++){
                int smaller = i;
                for (int j = i+1; j < Book.GetCount(); j++){
                    if ((books[j].GetGenre().CompareTo(books[smaller].GetGenre()) < 0) ||
                     (books[j].GetGenre() == books[smaller].GetGenre() && books[j].GetPages() < books[smaller].GetPages())){
                        smaller = j;
                    }
                    if (smaller != i) Swap(smaller, i);
                }
            }
        }
            System.Console.WriteLine($"This customer has attended {count} sessions total");
        } */
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
            
        }

    }
}