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

            newBooking.SetCustomerName();
            newBooking.SetCustomerEmail();

            newBooking.SetSessionDate(date);
            newBooking.SetTrainerName(tName);
            newBooking.SetTrainerID(tID);
            
            newBooking.SetStatus("Booked");    
            newBooking.SetCost(cost); 
            
            bookings.Add(newBooking);
            Save(); 
        }
        public void CancelBooking(){
            string tempPrompt = "Which booking do you want to cancel";
            List<string> tempOptions = new List<string>();
            foreach (Booking booking in bookings){
                tempOptions.Add(booking.ToString());
            }
            Menu chose = new Menu(tempPrompt, tempOptions);
            int selectedIndex = chose.Run();

            bookings[selectedIndex].SetStatus("Cancelled");
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
        
    }
}