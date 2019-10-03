using System.Collections.Generic;

public abstract class Publisher
{
    public string Name   { get; set; }
    public string Author { get; set; }
    public double Price  { get; set; }
    public IList<string> TableOfContents { get; private set; }

    
}