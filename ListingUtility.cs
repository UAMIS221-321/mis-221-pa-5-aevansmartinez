namespace mis_221_pa_5_aevansmartinez{
    /* CLASS DONE, REALLY THIS TIME*/
    public class ListingUtility
    {
        private List<Listing> listings = new List<Listing>();
        private List<Trainer> trainers = new List<Trainer>();
        public ListingUtility(List<Listing> listings, List<Trainer> trainers){  /*DONE*/
            this.listings = listings;
            this.trainers = trainers;
        }
        public void GetAllListingsFromFile(){   /*DONE*/
            StreamReader inFile = new StreamReader("listings.txt");
            string line = inFile.ReadLine();
            while (line != null){
                string[] temp = line.Split('#');
                listings.Add(new Listing(int.Parse(temp[0]), temp[1], DateTime.Parse(temp[2]), int.Parse(temp[3]), temp[4]));
                line = inFile.ReadLine();
            }
            inFile.Close();
        }
        public void AddListing(){   /*DONE*/
            Listing newListing = new Listing();

            newListing.SetListingID();
            newListing.SetTrainerName(trainers);
            newListing.SetCost();
            newListing.SetStatus();
            newListing.SetDateAndTime();
            listings.Add(newListing);

            Save(); 
        }
        public void EditListing(){  /*DONE*/
          //Menu for chosing which listing to edit
            string tempPrompt = "What trainer would you like to edit:";
            List<string> tempOptions = new List<string>();
            foreach (Listing listing in listings){
                tempOptions.Add(listing.ToString());
            }
            tempOptions.Add("Cancel");
            Menu choseListing = new Menu(tempPrompt, tempOptions);
            int selectedIndex = choseListing.Run();

          //menu for chosing which field to edit for the trainer
            string tempPrompt2 = "What field would you like to edit:";
            List<string> tempOptions2 = new List<string>{"Listing ID", "Trainer Name", "Cost", "Status", "Date & Time"};
            Menu choseField = new Menu(tempPrompt2, tempOptions2);
            int selectedIndex2 = choseField.Run();
            
          //actually does the edits
            if (selectedIndex < listings.Count()){  //checks to make sure user did not select cancel
                if (selectedIndex2 == 0) listings[selectedIndex].SetListingID();
                else if (selectedIndex2 == 1) listings[selectedIndex].SetTrainerName(trainers);
                else if (selectedIndex2 == 2) listings[selectedIndex].SetCost();
                else if (selectedIndex2 == 3) listings[selectedIndex].SetStatus();
                else listings[selectedIndex].SetDateAndTime();
                Save();
            }
        }
        public void DeleteListing(){    /*DONE*/
            string tempPrompt = "What listing would you like to delete: (Press cancel to return to Listing menu)";
            List<string> tempOptions = new List<string>();
            foreach (Listing listing in listings){
                tempOptions.Add(listing.ToString());
            }
            tempOptions.Add("Cancel");
            Menu deleteMenu = new Menu(tempPrompt, tempOptions);
            int selectedIndex = deleteMenu.Run();

            if (selectedIndex < listings.Count()){
                listings.RemoveAt(selectedIndex);
                Save();
            }
        }
        public void Save(){    /*DONE*/
            StreamWriter outFile = new StreamWriter("listings.txt");
            for (int i =0; i < listings.Count(); i++){
                outFile.WriteLine(listings[i].ToFile());
            }
            outFile.Close();
        }
        public int Find(int ID){    /*DONE*/
            for (int i = 0; i< listings.Count(); i++){
                if (listings[i].GetListingID() == ID){
                    return i;
                }
            }
            return -1;
        }
        public void PrintAllListings(){     /*DONE*/
            Console.Clear();
            for (int i = 0; i< listings.Count(); i++){
                System.Console.WriteLine(listings[i].ToString());
            }
        }
        public void ViewAvailableSessions(){    /*DONE*/
            Console.Clear();
            for (int i = 0; i< listings.Count(); i++){
                if (listings[i].GetAvailable() == "Available"){
                    System.Console.WriteLine(listings[i].ToStringAvailable());
                }
            }
        }
    }
}