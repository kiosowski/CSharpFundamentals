using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class Library : IEnumerable<Book>
{
    public List<Book> Books { get; set; }

    public Library(params Book[] books)
    {
        this.Books = new List<Book>(books);
    }
    public IEnumerator<Book> GetEnumerator()
    {
        return new LibraryIterator(Books);
    }
    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

    private class LibraryIterator : IEnumerator<Book>
    {
        public LibraryIterator(IEnumerable<Book> books)
        {
            Reset();
            _books = new List<Book>(books);
        }
        private readonly List<Book> _books;
        private int currIndex;

        public bool MoveNext()
        {
            currIndex++;
            return currIndex < _books.Count;
        }

        public void Reset()
        {
            currIndex = -1;
        }
        public Book Current => this._books[currIndex];

        object IEnumerator.Current => this.Current;
        public void Dispose()
        {
        }
    }
}
