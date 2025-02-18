using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;

public class BooksController : Controller
{
    private readonly XmlBookService _bookService;

    public BooksController()
    {
        _bookService = new XmlBookService(Path.Combine(Directory.GetCurrentDirectory(), "Data", "Books.xml"));
    }

    public IActionResult Index()
    {
        var books = _bookService.GetAllBooks();
        return View(books);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Book book)
    {
        var books = _bookService.GetAllBooks();
        books.Add(book);
        _bookService.SaveBooks(books);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Edit(int id)
    {
        var books = _bookService.GetAllBooks();
        var book = books.Find(b => b.Id == id);
        if (book == null) return NotFound();
        return View(book);
    }

    [HttpPost]
    public IActionResult Edit(Book book)
    {
        var books = _bookService.GetAllBooks();
        var bookToUpdate = books.Find(b => b.Id == book.Id);
        if (bookToUpdate == null) return NotFound();

        bookToUpdate.Title = book.Title;
        bookToUpdate.Author = book.Author;
        _bookService.SaveBooks(books);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete(int id)
    {
        var books = _bookService.GetAllBooks();
        var book = books.Find(b => b.Id == id);
        if (book == null) return NotFound();
        return View(book);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var books = _bookService.GetAllBooks();
        var book = books.Find(b => b.Id == id);
        if (book != null)
        {
            books.Remove(book);
            _bookService.SaveBooks(books);
        }
        return RedirectToAction(nameof(Index));
    }
}
