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
        Scripture scrip = new Scripture(scripRef.GetVerse());

        while (userInput != "quit") {
            /*I was originally going to have one of the classes
            control the display, but I liked the versatility provided
            by displaying from the Main program.*/
            Console.Clear();
            Console.WriteLine(($"{scripRef.FullReference()} {scrip.GetRenderedText()}"));
            Console.WriteLine("");
            /*Console.WriteLine("Press enter to continue or type 'quit' to finish:");
            userInput = Console.ReadLine();*/
            userInput = scrip.IsCompletelyHidden();
        }
    }
}