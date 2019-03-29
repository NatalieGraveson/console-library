using System;
using console_library.Models;

namespace console_library
{
  class Program
  {
    static void Main(string[] args)
    {
      bool InLibrary = true;
      Book whereTheSidewalkEnds = new Book("Where the Sidewalk Ends", "Shel Silverstein");
      Book codingForLosers = new Book("Coding For Losers", "Natalie");
      Library library = new Library("TheWorksOfCode", "Lame");
      library.AddBook(whereTheSidewalkEnds);
      library.AddBook(codingForLosers);
      System.Console.WriteLine("Welcome to annoying librarys that are annoying to build");
      System.Console.WriteLine("Available Books to hit yourself in the head with include:");
      while (InLibrary)
      {
        library.PrintBooks();
        System.Console.WriteLine("Select a book number to checkout, (Q)uit, or (R)eturn a book ");
        string selection = Console.ReadLine().ToUpper();
        if (selection == "Q")
        {
          return;
        }
        library.Checkout(selection);
        if (selection == "R")
        {
          System.Console.WriteLine("select a book number to return");
          string Removeselection = Console.ReadLine().ToUpper();
          library.ReturnBook(Removeselection);
        }
      }

    }

  }
}

