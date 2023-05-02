namespace mis_221_pa_5_aevansmartinez{
    //CLASS DONE.....PRETTY SURE
    public class Booking
    {
        private int sessionID;
        private string customerName;
        private string customerEmail;
        private DateTime sessionDate;
        private int trainerID;
        private string trainerName;
        private string status;
        private int cost;
        public Booking(){
            //no args constructor
        }
        public Booking(int sessionID, string cName, string cEmail, DateTime date, int trainerID, string tName, string status, int cost){
            this.sessionID = sessionID;
            this.customerName = cName;
            this.customerEmail = cEmail;
            this.sessionDate = date;
            this.trainerID = trainerID;
            this.trainerName = tName;
            this.status = status;
            this.cost = cost;
        }
        public void SetSessionID(int sID){
            this.sessionID = sID;
        }
        public void SetCustomerName(string cName){
            this.customerName = cName;
        }
        public void SetCustomerEmail(string cEmail){
            this.customerEmail = cEmail;
        }
        public void SetSessionDate(DateTime date){
            this.sessionDate = date;
        }
        public void SetTrainerID(int tID){
            this.trainerID = tID;
        }
        public void SetTrainerName(string tName){
            this.trainerName = tName;
        }
        public void SetStatus(string status){
            this.status = status;
        }
        public void SetCost(int cost){
            this.cost =cost;
        }
        public int GetSessionID(){
            return sessionID;
        }
        public string GetCustomerName(){
            return customerName;
        }
        public string GetCustomerEmail(){
            return customerEmail;
        }
        public DateTime GetSessionDate(){
            return sessionDate;
        }
        public int GetTrainerID(){
            return trainerID;
        }
        public string GetTrainerName(){
            return trainerName;
        }
        public string GetStatus(){
            return status;
        }
        public int GetCost(){
            return cost;
        }
        public string ToFile(){
            return $"{sessionID}#{customerName}#{customerEmail}#{sessionDate}#{trainerID}#{trainerName}#{status}#{cost}";
        }
        public override string ToString(){
            return @$"SESSION ID: {sessionID} | CUSTOMER NAME: {customerName} | CUSTOMER EMAIL: {customerEmail}
            SESSION DATE: {sessionDate} | TRAINER ID: {trainerID} | TRAINER NAME: {trainerName} | STATUS: {status} | COST: {cost}";
        }
    }
}