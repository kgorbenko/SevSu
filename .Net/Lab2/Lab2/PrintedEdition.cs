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
        Name = name ?? throw new ArgumentNullException("name was null.");
        Author = author ?? throw new ArgumentNullException("author was null.");
        Contents = contents ?? throw new ArgumentNullException("contents was null");
        Price = price;
    }
    public string this[string chapter]
    {
        get => Contents.ContainsKey(chapter) ? Contents[chapter] : throw new ChapterNotFoundExeption($"The key \"{chapter}\" was not found");
        set => Contents[chapter] = value;
    }

    public abstract string Print();
}