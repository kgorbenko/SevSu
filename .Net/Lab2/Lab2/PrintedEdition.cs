using System;
using System.Collections.Generic;

public abstract class PrintedEdition
{
    public string Name   { get; set; }
    public string Author { get; set; }
    public double Price  { get; set; }
    public IDictionary<string, string> Contents { get; set; }
    public PrintedEdition() { }
    public PrintedEdition(string name)
    {
        Name = name ?? throw new ArgumentNullException("name was null.");
    } 
    public PrintedEdition(string name, string author, double price, IDictionary<string, string> contents)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Author = author ?? throw new ArgumentNullException(nameof(author));
        Contents = contents ?? throw new ArgumentNullException(nameof(contents));
        Price = price;
    }
    public string this[string chapter]
    {
        get 
        {
            if (chapter == null)
            {
                throw new ArgumentNullException(nameof(chapter));
            }
            return Contents.ContainsKey(chapter) ? Contents[chapter] : throw new ChapterNotFoundExeption($"The key \"{chapter}\" was not found");
        }
        set
        {
            if (value != null)
            {
                Contents[chapter] = value;
            }
        }
    }

    public abstract string Print();
}