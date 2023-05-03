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

            newListing.SetListingID();
            newListing.SetTrainerName();
            newListing.SetCost();
            newListing.SetStatus();
            newListing.SetDateAndTime();
            listings.Add(newListing);

            Save(); 
        }
        public void EditListing(){
            System.Console.WriteLine("What listing do you want to edit? Enter the ID: ");
            int searchVal = int.Parse(Console.ReadLine());
            int foundIndex = Find(searchVal);
            if (foundIndex != -1){
                listings[foundIndex].SetListingID();
                listings[foundIndex].SetTrainerName();  
                listings[foundIndex].SetCost();
                listings[foundIndex].SetStatus();
                listings[foundIndex].SetDateAndTime();
                Save();
            }
            else {
                System.Console.WriteLine("Listing not found.");
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
                System.Console.WriteLine("Trainer not found; Please try");
                DeleteListing();
            }
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