namespace mis_221_pa_5_aevansmartinez{
    //CLASS DONE.....PRETTY SURE
    public class ListingUtility
    {
        private List<Listing> listings = new List<Listing>();
        public ListingUtility(List<Listing> listings){
            this.listings = listings;
        }
        public void GetAllListingsFromFile(){
            StreamReader inFile = new StreamReader("listings.txt");
            string line = inFile.ReadLine();
            while (line != null){
                string[] temp = line.Split('#');
                listings.Add(new Listing(int.Parse(temp[0]), temp[1], DateTime.Parse(temp[2]), int.Parse(temp[3]), temp[4]));
                line = inFile.ReadLine();
            }
            inFile.Close();
        }
        
        public void AddListing(){ 
            Listing newListing = new Listing();

            System.Console.WriteLine("Please enter listing ID: ");
            newListing.SetListingID(int.Parse(Console.ReadLine()));
            System.Console.WriteLine("Please enter trainer name: ");
            newListing.SetTrainerName(Console.ReadLine());
            System.Console.WriteLine("Please enter the cost: ");
            newListing.SetCost(int.Parse(Console.ReadLine()));
            System.Console.WriteLine("Please enter the status: ");
            newListing.SetAvaliable(Console.ReadLine());
            System.Console.WriteLine("Please enter the date and time: ");
            newListing.SetDateAndTime(DateTime.Parse(Console.ReadLine()));
            
            listings.Add(newListing);
            Save(); 
        }
        public void EditListing(){
            System.Console.WriteLine("What listing do you want to edit? Enter the ID: ");
            int searchVal = int.Parse(Console.ReadLine());
            int foundIndex = Find(searchVal);
            if (foundIndex != -1){
                System.Console.WriteLine("Please enter listing ID: ");
                listings[foundIndex].SetListingID(int.Parse(Console.ReadLine()));
                System.Console.WriteLine("Please enter trainer name: ");
                listings[foundIndex].SetTrainerName(Console.ReadLine());
                System.Console.WriteLine("Please enter the cost: ");
                listings[foundIndex].SetCost(int.Parse(Console.ReadLine()));
                System.Console.WriteLine("Please enter the status: ");
                listings[foundIndex].SetAvaliable(Console.ReadLine());
                System.Console.WriteLine("Please enter the date and time: ");
                listings[foundIndex].SetDateAndTime(DateTime.Parse(Console.ReadLine()));
                Save();
            }
            else {
                System.Console.WriteLine("Listing not found.");
                EditListing();
            }
        }
        public void DeleteListing(){
            //error handling done
            System.Console.WriteLine("What listing do you want to delete? Enter the ID: ");
            int searchVal = int.Parse(Console.ReadLine());
            int foundIndex = Find(searchVal);
            if (foundIndex != -1){
                listings.RemoveAt(foundIndex);
                Save();
            }
            else {
                System.Console.WriteLine("Trainer not found.");
                DeleteListing();
            }
        }
        public void UpdateStatus(int index, string status){
            listings[index].SetAvaliable(status);
                Save();
        }
        private void Save(){
            StreamWriter outFile = new StreamWriter("listings.txt");
            for (int i =0; i < listings.Count(); i++){
                outFile.WriteLine(listings[i].ToFile());
            }
            outFile.Close();
        }
        public int Find(int ID){
            for (int i = 0; i< listings.Count(); i++){
                if (listings[i].GetListingID() == ID){
                    return i;
                }
            }
            return -1;
        }
        public void PrintAllListings(){
            Console.Clear();
            for (int i = 0; i< listings.Count(); i++){
                System.Console.WriteLine(listings[i].ToString());
            }
        }
        public void ViewAvailableSessions(){
            Console.Clear();
            for (int i = 0; i< listings.Count(); i++){
                if (listings[i].GetAvailable() == "Available"){
                    System.Console.WriteLine(listings[i].ToStringAvailable());
                }
            }
        }
    }
}