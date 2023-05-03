namespace mis_221_pa_5_aevansmartinez{
    /* CLASS DONE, REALLY THIS TIME*/
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
        public void SetID(){
            System.Console.WriteLine("Please enter the trainer ID: ");
            int x;
            if (int.TryParse(Console.ReadLine(), out x)) {
                if (x <= 100 || x >= 1000) {
                    System.Console.WriteLine("The trainer ID must be an int value between 100 and 999");
                    SetID();
                }
                else this.ID = x;
            }
            else {
                System.Console.WriteLine("This is not a valid listing ID; please try again.");     
                SetID();
            }
        }
        public void SetName(){
            System.Console.WriteLine("Please enter trainer name: ");
            this.name = Console.ReadLine();
        }
        public void SetMailing(){
            System.Console.WriteLine("Please enter the mailing address: ");
            this.mailingAdd = Console.ReadLine();
        }
        public void SetEmail(){
            System.Console.WriteLine("Please enter the email: ");
            string temp = Console.ReadLine();
            if (temp.Contains("@")==false) SetEmail();
            else this.email = temp;
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