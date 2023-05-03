//CLASS DONE.....PRETTY SURE
using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace mis_221_pa_5_aevansmartinez
{
    public class Menu
    {
        private int selectedIndex;
        //private string[] options;
        private List<string> options;
        private string prompt;
        public Menu(){
        }
        public Menu(string Prompt, List<string> Options){
            this.prompt = Prompt;
            this.options = Options;
            this.selectedIndex = 0;
        }
        private void DisplayMenuOptions(){
            WriteLine(prompt);
            Write("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");

            for (int i =0; i < options.Count(); i++){
                string current = options[i];
                string prefix;
                if (i == selectedIndex){
                    prefix = "*";
                    ForegroundColor = ConsoleColor.Black;
                    BackgroundColor = ConsoleColor.White;
                }
                else{
                    prefix = " ";
                    ForegroundColor = ConsoleColor.White;
                    BackgroundColor = ConsoleColor.Black;
                }
                WriteLine($"{prefix} ~~ {current} ~~");
            }
            ResetColor();
        }
        public int Run(){
            ConsoleKey keyPressed;
            do {
                Clear();
                DisplayMenuOptions();

                ConsoleKeyInfo keyInfo = ReadKey(true);
                keyPressed = keyInfo.Key;
                
                if (keyPressed == ConsoleKey.UpArrow){
                    selectedIndex --;
                    if (selectedIndex == -1){
                        selectedIndex = options.Count() -1;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow){
                    selectedIndex ++;
                    if (selectedIndex == options.Count()){
                        selectedIndex = 0;
                    }
                }
            } while (keyPressed != ConsoleKey.Enter);
            
            return selectedIndex;
        }
    }
}