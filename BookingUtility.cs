namespace mis_221_pa_5_aevansmartinez
{
    public class BookingUtility
    {
        private List<Booking> bookings = new List<Booking>();
        private List<Listing> listings = new List<Listing>();
        public BookingUtility(List<Booking> bookings){
            this.bookings = bookings;
        }
        public void GetAllSessionsFromFile(){
            StreamReader inFile = new StreamReader("transactions.txt");
            string line = inFile.ReadLine();
            while (line != null){
                string[] temp = line.Split('#');
                bookings.Add(new Booking(int.Parse(temp[0]), temp[1], temp[2], DateTime.Parse(temp[3]), int.Parse(temp[4]), temp[5], temp[6], int.Parse(temp[7])));
                line = inFile.ReadLine();
            }
            inFile.Close();
        }
        public void AddBooking(int sessionID, DateTime date, string tName, int tID, int cost){ 
            Booking newBooking = new Booking();

            newBooking.SetSessionID(sessionID);

            System.Console.WriteLine("Please enter customer name: ");
            newBooking.SetCustomerName(Console.ReadLine());
            System.Console.WriteLine("Please enter customer email: ");
            newBooking.SetCustomerEmail(Console.ReadLine());

            newBooking.SetSessionDate(date);
            newBooking.SetTrainerName(tName);
            newBooking.SetTrainerID(tID);
            
            newBooking.SetStatus("Booked");    
            newBooking.SetCost(cost); 
            
            bookings.Add(newBooking);
            Save(); 
        }
        private void Save(){
            StreamWriter outFile = new StreamWriter("transactions.txt");
            for (int i =0; i < bookings.Count(); i++){
                outFile.WriteLine(bookings[i].ToFile());
            }
            outFile.Close();
        }
        public void ViewAllTransactions(){
            UpdateStatusForAll();
            Console.Clear();
            for (int i = 0; i< bookings.Count(); i++){
                System.Console.WriteLine(bookings[i].ToString());
            }
        }

        private void UpdateStatusForAll(){
            foreach(Booking booking in bookings){
                if (booking.GetSessionDate() <= DateTime.Now){
                    booking.SetStatus("Completed");
                }
            }
            Save();
        }
        
        /*FIX ME:private int Find(int ID){
            for (int i = 0; i< bookings.Count(); i++){
                if (bookings[i].GetListingID() == ID){
                    return i;
                }
            }
            return -1;
        } */
    }
}