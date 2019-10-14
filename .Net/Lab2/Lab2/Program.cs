using System;
using System.Collections.Generic;

namespace Lab2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var contents = new Dictionary<string, string>()
            {
                { "First", "Some content here" } 
            };
            var book = new Book("name", "me", 500, contents, "image.jpg");

            try 
            {
                Console.WriteLine(book.RePublish().Name);
                Console.WriteLine((book as IPublishable).RePublish().Name);
                Console.WriteLine((book as INewPubishable).RePublish().Name);
                var chapter = book["not existing chapter"];
            }
            catch (ChapterNotFoundExeption e) 
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
