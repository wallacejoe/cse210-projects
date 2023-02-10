using System;

class Program
{
    static void Main(string[] args)
    {
        string userInput = "";
        string scriptureBook = "Proverbs";
        string scriptureChapter = "3:5-6";
        string[] scriptureText = {"Trust in the Lord with all thine heart and lean not unto thine own understanding;", "in all thy ways acknowledge him, and he shall direct thy paths."};
        Reference scripRef = new Reference(scriptureBook, scriptureChapter, scriptureText);
        Scripture scrip = new Scripture(scripRef.FullReference());

        //Loops the program until the user enters 'quit'.
        while (userInput != "quit") {
            userInput = scrip.IsCompletelyHidden();
        }
    }
}