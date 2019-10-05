using System;
using System.Text;
using System.Collections.Generic;

public class Book : PrintedEdition, IPublishable, INewPubishable
{
    public string TitleImage { get; set; }
    public Book() { }
    public Book(string name) : base(name) { } 

    public Book(string name, string author, double price, IDictionary<string, string> contents, string titleImage) : base(name, author, price, contents) 
    {
        TitleImage = titleImage ?? throw new ArgumentNullException("titleImage was null");
    }
    public override string Print()
    {
        var builder = new StringBuilder();
        foreach (var chapter in Contents)
            builder.Append($"Chapter {chapter.Key}\n\n{chapter.Value}\n\n");
        return builder.ToString();
    }

    public Book RePublish()
    {
        return new Book()
        {
            Name = this.Name + "new edition",
            Author = this.Author,
            Price = this.Price,
            Contents = this.Contents,
            TitleImage = this.TitleImage
        };
    }

    Book IPublishable.RePublish()
    {
        throw new NotImplementedException();
    }

    Book INewPubishable.RePublish()
    {
        throw new NotImplementedException();
    }
}