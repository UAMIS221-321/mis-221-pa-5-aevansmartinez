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
            //testing out the datetime variable
            this.listingID = ID;
            this.trainerName = tName;
            this.cost = cost;
            this.status = status;
            this.dateAndTime = dateAndTime;
        }
        public void SetListingID(int ID){
            this.listingID = ID;
        }
        public void SetTrainerName(string trainerName){
            this.trainerName = trainerName;
        }
        public void SetCost(int cost){
            this.cost = cost;
        }
        public void SetAvaliable(string status){
            this.status = status;
        }
        public void SetDateAndTime (DateTime dateAndTime){
            this.dateAndTime = dateAndTime;
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
            return $"Listing ID:{listingID} | Trainer Name: {trainerName} | Date & Time: {dateAndTime} | Cost: {cost} | Available: {status}";   
        }
        public string ToStringAvailable(){
            return $"Listing ID:{listingID} | Trainer: {trainerName} | Date & Time: {dateAndTime} | Cost: {cost}";   
        }
    }
}