using System;
using System.Collections.Generic;
using System.Linq;

public class Book
{
    public string Title { get; }
    public string Author { get; }
    public string ISBN { get; }
    public int Copies { get; private set; }

    public Book(string title, string author, string isbn, int copies)
    {
        Title = title;
        Author = author;
        ISBN = isbn;
        Copies = copies;
    }

    public bool IsAvailable()
    {
        return Copies > 0;
    }

    public void Borrow()
    {
        if (Copies > 0) Copies--;
    }

    public void Return()
    {
        Copies++;
    }
}

public class Reader
{
    public string Name { get; }
    public int Id { get; }

    public Reader(string name, int id)
    {
        Name = name;
        Id = id;
    }
}

public class Library
{
    private List<Book> books = new List<Book>();
    private List<Reader> readers = new List<Reader>();
    private Dictionary<int, List<Book>> borrowed = new Dictionary<int, List<Book>>();

    public void AddBook(Book book)
    {
        books.Add(book);
    }

    public void RemoveBook(string isbn)
    {
        books.RemoveAll(b => b.ISBN == isbn);
    }

    public void RegisterReader(Reader reader)
    {
        readers.Add(reader);
    }

    public void RemoveReader(int id)
    {
        readers.RemoveAll(r => r.Id == id);
        borrowed.Remove(id);
    }

    public bool BorrowBook(int readerId, string isbn)
    {
        var reader = readers.FirstOrDefault(r => r.Id == readerId);
        var book = books.FirstOrDefault(b => b.ISBN == isbn);
        if (reader == null || book == null || !book.IsAvailable()) return false;

        book.Borrow();
        if (!borrowed.ContainsKey(readerId)) borrowed[readerId] = new List<Book>();
        borrowed[readerId].Add(book);
        return true;
    }

    public bool ReturnBook(int readerId, string isbn)
    {
        if (!borrowed.ContainsKey(readerId)) return false;
        var book = borrowed[readerId].FirstOrDefault(b => b.ISBN == isbn);
        if (book == null) return false;

        book.Return();
        borrowed[readerId].Remove(book);
        return true;
    }

    public void PrintStatus()
    {
        Console.WriteLine("Books:");
        foreach (var b in books)
            Console.WriteLine($"{b.Title} ({b.Author}) - {b.Copies} copies");

        Console.WriteLine("\nReaders:");
        foreach (var r in readers)
            Console.WriteLine($"{r.Name} (ID: {r.Id})");
    }
}

public class Program
{
    public static void Main()
    {
        var library = new Library();

        var b1 = new Book("1984", "George Orwell", "111", 3);
        var b2 = new Book("Brave New World", "Aldous Huxley", "222", 2);
        library.AddBook(b1);
        library.AddBook(b2);

        var r1 = new Reader("Alice", 1);
        var r2 = new Reader("Bob", 2);
        library.RegisterReader(r1);
        library.RegisterReader(r2);

        library.PrintStatus();

        library.BorrowBook(1, "111");
        library.BorrowBook(2, "222");
        library.BorrowBook(1, "222");

        Console.WriteLine("\nAfter borrowing:");
        library.PrintStatus();

        library.ReturnBook(1, "111");
        Console.WriteLine("\nAfter returning:");
        library.PrintStatus();
    }
}
