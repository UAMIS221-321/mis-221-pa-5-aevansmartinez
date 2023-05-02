namespace mis_221_pa_5_aevansmartinez{
    //CLASS DONE.....PRETTY SURE
    public class Trainer {
        private int ID;
        private string name;
        private string mailingAdd;
        private string email;
        static private int count;
        public Trainer(){
            //no args constructor
        }
        public Trainer(int ID, string name, string mail, string email){
            //args constructor
            this.ID = ID;
            this.name = name;
            this.mailingAdd = mail;
            this.email = email;
        }
        public void SetID(int ID){
            this.ID = ID;
        }
        public void SetName(string name){
            this.name = name;
        }
        public void SetMailing(string mailingAdd){
            this.mailingAdd = mailingAdd;
        }
        public void SetEmail(string email){
            this.email = email;
        }
        public int GetID(){
            return ID;
        }
        public string GetName(){
            return name;
        }
        public string GetMailing(){
            return mailingAdd;
        }
        public string GetEmail(){
            return email;
        }
        public string ToFile(){
            return $"{ID}#{name}#{mailingAdd}#{email}";
        }

        public override string ToString(){
            return $"TRAINER ID:{ID} | NAME: {name} | ADDRESS: {mailingAdd} | EMAIL: {email}";   
        }
    }
}