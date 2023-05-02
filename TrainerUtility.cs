namespace mis_221_pa_5_aevansmartinez{
    //CLASS DONE.....PRETTY SURE
    public class TrainerUtility
    {
        private List<Trainer> trainers = new List<Trainer>();
        public TrainerUtility(List<Trainer> trainers){
            this.trainers = trainers;
        }
        public void GetAllTrainerssFromFile(){
            StreamReader inFile = new StreamReader("trainers.txt");
            string line = inFile.ReadLine();
            while (line != null){
                string[] temp = line.Split('#');
                trainers.Add(new Trainer(int.Parse(temp[0]), temp[1], temp[2], temp[3]));
                line = inFile.ReadLine();
            }
            inFile.Close();
        }
        public void AddTrainer(){
            Trainer newbie = new Trainer();

            System.Console.WriteLine("\nPlease enter the ID: ");
            newbie.SetID(int.Parse(Console.ReadLine()));
            System.Console.WriteLine("Please enter the name: ");
            newbie.SetName(Console.ReadLine());
            System.Console.WriteLine("Please enter the mailing address: ");
            newbie.SetMailing(Console.ReadLine());
            System.Console.WriteLine("Please enter the email: ");
            newbie.SetEmail(Console.ReadLine());

            trainers.Add(newbie);
            Save();
        }
        public void EditTrainer(){
            // extra/to fix: be able to update single value without editing the rest
            System.Console.WriteLine("What trainer do you want to update? Enter name: ");
            string searchVal = Console.ReadLine();
            int foundIndex = Find(searchVal);
            if (foundIndex != -1){
                System.Console.WriteLine("Please enter the ID: ");
                trainers[foundIndex].SetID(int.Parse(Console.ReadLine()));
                System.Console.WriteLine("Please enter the name: ");
                trainers[foundIndex].SetName(Console.ReadLine());
                System.Console.WriteLine("Please enter the mailing address: ");
                trainers[foundIndex].SetMailing(Console.ReadLine());
                System.Console.WriteLine("Please enter the email: ");
                trainers[foundIndex].SetEmail(Console.ReadLine());
                Save();
            }
            else System.Console.WriteLine("Trainer not found.");
        }
        public void DeleteTrainer(){
            System.Console.WriteLine("What trainer do you want to delete? Enter name: ");
            string searchVal = Console.ReadLine();
            int foundIndex = Find(searchVal);
            if (foundIndex != -1){
                trainers.RemoveAt(foundIndex);
                Save();
            }
            else {
                System.Console.WriteLine("Trainer not found.");
            }
        }
        private void Save(){
            StreamWriter outFile = new StreamWriter("trainers.txt");
            for (int i =0; i < trainers.Count(); i++){
                outFile.WriteLine(trainers[i].ToFile());
            }
            outFile.Close();
        }
        public int Find(string searchVal){
            for (int i =0; i< trainers.Count(); i++){
                if (trainers[i].GetName().ToUpper() == searchVal.ToUpper()){
                    return i;
                }
            }
            return -1;
        }
        public void PrintAllTrainers(){
            Console.Clear();
            for (int i = 0; i< trainers.Count(); i++){
                System.Console.WriteLine(trainers[i].ToString());
            }
        }

    }
}