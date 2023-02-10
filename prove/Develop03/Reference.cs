using System;

public class Reference
{
    private string _book;
    private string _chapter;
    private string _verse;

    /*I realized that if I was returning a string regardless
     it would be easier to convert within the constructor*/
    //private String[] _verses;

    //Format the full scripture reference, the '_book' and '_chapter'.
    public string[] FullReference()
    {
        string fullRef = $"{_book} {_chapter}";
        string[] fullText = {fullRef, _verse};
        return fullText;
    }

    public string GetVerse()
    {
        string verse = _verse;
        return verse;
    }

    /*Constructors*/
    //Takes three inputs of 'string' type.
    public Reference(string book, string chapter, string verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
    }

    //Takes three inputs, two 'string' types and a 'string[]' type.
    //Changes the verses parameter to a 'string'.
    public Reference(string book, string chapter, string[] verses)
    {
        _book = book;
        _chapter = chapter;
        int currentNum = 1;
        foreach (string line in verses)
        {
            if (currentNum == verses.Count())
            {
                _verse += line;
            }
            else
            {
                _verse += line + " ";
            }
            currentNum += 1;
        }
    }
}