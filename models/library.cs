using System;
using System.Collections.Generic;
namespace console_library.Models
{
  public class Library
  {

    //Properties
    public string Location { get; set; }
    public string Name { get; set; }

    public List<Book> CheckedOut { get; set; } = new List<Book>();
    public List<Book> AvailableBooks { get; set; } = new List<Book>();
    private List<Book> Books { get; set; } = new List<Book>();




    public Library(string location, string name)
    {
      Location = location;
      Name = name;
    }
    public void PrintBooks()
    {
      for (int i = 0; i < Books.Count; i++)
      {
        Console.WriteLine($"{i + 1} {Books[i].Title} - {Books[i].Author} - Available: {Books[i].Available}");
      }
    }
    public void AddBook(Book book)
    {
      Books.Add(book);
      AvailableBooks.Add(book);
    }
    public void Checkout(string selection)
    {
      Book selectedBook = ValidateBook(selection, AvailableBooks);

      if (selectedBook == null)
      {
        Console.Clear();
        System.Console.WriteLine(@"Invalid Selection");
        return;
      }
      selectedBook.Available = false;
      AvailableBooks.Remove(selectedBook);
      CheckedOut.Add(selectedBook);
      System.Console.WriteLine("Congrats my dude, you go it");
    }
    private Book ValidateBook(string selection, List<Book> bookList)
    {
      int bookIndex = -1;
      bool valid = Int32.TryParse(selection, out bookIndex);
      if (!valid || bookIndex < 0 || bookIndex > bookList.Count)
      {
        return null;
      }
      return bookList[bookIndex - 1];

    }
    public void ReturnBook(string selection)
    {
      Book selectedBook = ValidateBook(selection, CheckedOut);

      if (selectedBook == null || selectedBook.Available == true)
      {
        Console.Clear();
        System.Console.WriteLine(@"Invalid Selection");
        return;
      }
      else
      {
        selectedBook.Available = true;
        AvailableBooks.Add(selectedBook);
        CheckedOut.Remove(selectedBook);
        System.Console.WriteLine("Congrats my Dude, Book is back");
      }
    }







  }
}



