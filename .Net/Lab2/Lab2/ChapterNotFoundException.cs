using System;
using System.Collections.Generic;

public class ChapterNotFoundExeption : KeyNotFoundException
{
    public ChapterNotFoundExeption() { }
    public ChapterNotFoundExeption(string name) : base(name) { }
    public ChapterNotFoundExeption(string name, Exception inner) { }
}