namespace mis_221_pa_5_aevansmartinez{
    //CLASS DONE.....PRETTY SURE
    public class Listing{
        private int listingID;
        private string trainerName;
        private int cost;
        private string status;
        private DateTime dateAndTime;
        public Listing(){
            //no args constructor
        }
        public Listing(int ID, string tName, DateTime dateAndTime, int cost, string status ){
            this.listingID = ID;
            this.trainerName = tName;
            this.cost = cost;
            this.status = status;
            this.dateAndTime = dateAndTime;
        }
        
        public void SetListingID(){
            System.Console.WriteLine("Please enter the listing ID: ");
            int x;
            if (int.TryParse(Console.ReadLine(), out x)) {
                if (x <= 100 || x >= 1000) {
                    System.Console.WriteLine("The listing ID must be an int value between 100 and 999");
                    SetListingID();
                }
                else this.listingID = x;
            }
            else {
                System.Console.WriteLine("This is not a valid listing ID; please try again.");     
                SetListingID();
            }
        }
        public void SetTrainerName(List<Trainer> trainers){
            string tempPrompt = "Select a trainer:";
            List<string> tempOptions = new List<string>();
            foreach (Trainer trainer in trainers){
                tempOptions.Add(trainer.GetName());
            }
            Menu selectTrainerMenu = new Menu(tempPrompt, tempOptions);
            int selectedIndex = selectTrainerMenu.Run();
            
            this.trainerName = trainers[selectedIndex].GetName();
        }
        public void SetCost(){
            System.Console.WriteLine("Please enter the cost: ");
            int x;
            if (int.TryParse(Console.ReadLine(), out x)) {
                if (x <= 0 || x > 200) {
                    System.Console.WriteLine("The cost must be an int value between 1 and 200");
                    SetCost();
                }
                else this.cost = x;
            }
            else {
                System.Console.WriteLine("This is not a valid cost; please try again.");
                SetCost();
            }
        }
        public void SetStatus(){
            string tempPrompt = "Please select the status:";
            List<string> tempOptions = new List<string>(){"Available", "Booked"};
            Menu selectStatusMenu = new Menu(tempPrompt, tempOptions);
            int selectedIndex = selectStatusMenu.Run();
            
            if (selectedIndex == 0) this.status = "Available";
            else this.status = "Booked";
        }
        public void ChangeStatus(string status){
            this.status = status;
        }
        public void SetDateAndTime (){
            System.Console.WriteLine("Please enter the date: ");
            DateTime x;
            if (DateTime.TryParse(Console.ReadLine(), out x)) {
                this.dateAndTime = x;
            }
            else {
                System.Console.WriteLine("This is not a date or time; please try again.");
                SetDateAndTime();
            }
        }
        public int GetListingID(){
            return listingID;
        }
        public string GetTrainerName(){
            return trainerName;
        }
        public int GetCost(){
            return cost;
        }
        public string GetAvailable(){
            return status;
        }
        public DateTime GetDateAndTime(){
            return dateAndTime;
        }
        public string ToFile(){
            return $"{listingID}#{trainerName}#{dateAndTime}#{cost}#{status}";
        }
        public override string ToString(){
            return $"LISTING ID:{listingID} | TRAINER: {trainerName} | DATE & TIME: {dateAndTime} | COST: {cost} | AVAILABLE: {status}";   
        }
        public string ToStringAvailable(){
            return $"LISTING ID:{listingID} | TRAINER: {trainerName} | DATE & TIME: {dateAndTime} | COST: {cost}";   
        }
    }
}