namespace mis_221_pa_5_aevansmartinez{
    /* CLASS DONE, REALLY THIS TIME*/
    public class TrainerUtility
    {
        private List<Trainer> trainers = new List<Trainer>();
        public TrainerUtility(List<Trainer> trainers){  /*DONE*/
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
        public void AddTrainer(){   /*DONE*/
            Trainer newbie = new Trainer();
            newbie.SetID();
            newbie.SetName();
            newbie.SetMailing();
            newbie.SetEmail();
            trainers.Add(newbie);
            
            Save();
        }
        public void EditTrainer(){  /*DONE*/
            //Menu for chosing which trainer to edit
            string tempPrompt = "What trainer would you like to edit:";
            List<string> tempOptions = new List<string>();
            foreach (Trainer trainer in trainers){
                tempOptions.Add(trainer.ToString());
            }
            tempOptions.Add("Cancel");
            Menu choseTrainer = new Menu(tempPrompt, tempOptions);
            int selectedIndex = choseTrainer.Run();
            
            //menu for chosing which field to edit for the trainer
            string tempPrompt2 = "What field would you like to edit:";
            List<string> tempOptions2 = new List<string>{"ID", "Name", "Mailing Address", "Email"};
            Menu choseField = new Menu(tempPrompt2, tempOptions2);
            int selectedIndex2 = choseField.Run();

            if (selectedIndex < trainers.Count()){  //checks to make sure user did not select cancel
                if (selectedIndex2 == 0) trainers[selectedIndex].SetID();
                else if (selectedIndex2 == 1) trainers[selectedIndex].SetName();
                else if (selectedIndex2 == 2) trainers[selectedIndex].SetMailing();
                else trainers[selectedIndex].SetEmail();
                Save();
            }
            
        }
        public void DeleteTrainer(){   /*DONE*/
            string tempPrompt = "What trainer would you like to delete: (Press cancel to return to Listing menu)";
            List<string> tempOptions = new List<string>();
            foreach (Trainer trainer in trainers){
                tempOptions.Add(trainer.ToString());
            }
            tempOptions.Add("Cancel");
            Menu deleteMenu = new Menu(tempPrompt, tempOptions);
            int selectedIndex = deleteMenu.Run();

            if (selectedIndex < trainers.Count()){
                trainers.RemoveAt(selectedIndex);
                Save();
             }
        }
        private void Save(){    /*DONE*/
            StreamWriter outFile = new StreamWriter("trainers.txt");
            for (int i =0; i < trainers.Count(); i++){
                outFile.WriteLine(trainers[i].ToFile());
            }
            outFile.Close();
        }
        public int Find(string searchVal){  /*DONE*/
            for (int i =0; i< trainers.Count(); i++){
                if (trainers[i].GetName().ToUpper() == searchVal.ToUpper()){
                    return i;
                }
            }
            return -1;
        }
        public void PrintAllTrainers(){     /*DONE*/
            Console.Clear();
            for (int i = 0; i< trainers.Count(); i++){
                System.Console.WriteLine(trainers[i].ToString());
            }
        }

    }
}