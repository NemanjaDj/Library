﻿using Library.Data;
using Library.Models;
using Library.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Hardcodes
{
    public class BookService: MasterService
    {

        public void InsertBook(Book book, string writerName, IEnumerable<string> genres)
        {
            book.WriterId = GetWriterByName(writerName).WriterId;
            bookRepository.InsertBook(book);
            foreach (var genre in genres)
            {
                var genretmp = bookRepository.getGenreByName(genre);
                MapBookGenres(book.BookId, genretmp.GenreId);
            }
            InsertNumberOfBooks(book.BookId, 1);
        }

        public IEnumerable<Models.Book> ShowBooks()
        {
            return bookRepository.ShowBooks();
        }

        public Book getBookById(int bookId)
        {
            return bookRepository.getBookById(bookId);
        }

        public IEnumerable<Genre> GetAllGenre()
        {
            return bookRepository.GetAllGenres();
        }

        public void MapBookGenres(int bookId, int genreId)
        {
            try
            {
                bookRepository.AddBookGenre(bookId, genreId);
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public Genre GetGenreById(int genreId)
        {
            return bookRepository.getGenreById(genreId);
        }

        public ICollection<Genre> BookGenres(int bookId)
        {
            List<Genre> genres = new List<Genre>();
            List<int> genreId = new List<int>();

            genreId = bookRepository.GetGenresId(bookId);

            foreach (var id in genreId)
            {
                genres.Add(bookRepository.getGenreById(id));
            }

            return genres;
        }

        public BookModel RenderBook(int id)
        {
            BookModel bookModel = new BookModel();
            var book = getBookById(id);
            bookModel.Book = book;
            bookModel.Writer = GetBookWriter(id);
            bookModel.Genres = BookGenres(id);
            bookModel.NumberOfBooks = NumberOfBook(id);
            return bookModel;
        }

        public Writer GetWriterByName(string writerName)
        {
            return writerRepository.GetWriterByName(writerName);
        }

        public Writer GetWriterById(int writerId)
        {
            return writerRepository.GetWriterById(writerId);
        }

        public void InsertWriter(Writer writer)
        {
            writerRepository.InsertWriter(writer);
        }

        public IEnumerable<Writer> GetWriters()
        {
            return writerRepository.GetWriters();
        }

        public Writer GetBookWriter(int bookId)
        {
            return writerRepository.GetBookWriter(bookId);
        }

        public int? NumberOfBook(int bookId)
        {
            return bookRepository.NumberOfBook(bookId);
        }

        // insert number of books
        public void InsertNumberOfBooks(int bookId, int? numberOfBooks)
        {
            bookRepository.AddNumberOfBooks(bookId, numberOfBooks);
        }

        // add additional number of books for bookId
        public void AddNumberOfBooks(int bookId, int? numberOfBooks)
        {
            var _currentNumberOfBooks = NumberOfBook(bookId);
            InsertNumberOfBooks(bookId, _currentNumberOfBooks + numberOfBooks);
        }

        public int? GetWriterAge(int writerId)
        {
            var writerAge = DateTime.Now.Year - writerRepository.GetWriterYearOfBirth(writerId);
            return writerAge;
        }

        public List<Book> FindBookByName(string bookName)
        {
            if (String.IsNullOrEmpty(bookName))
            {
                return bookRepository.ShowBooks().ToList();
            }
            return bookRepository.FindBookByName(bookName);
        }

        public void UpdateBook(Book book, string writerName, IEnumerable<string> genres)
        {
            book.WriterId = GetWriterByName(writerName).WriterId;
            bookRepository.DeleteBookGenres(book.BookId);
            foreach (var genre in genres)
            {
                var genretmp = bookRepository.getGenreByName(genre);
                MapBookGenres(book.BookId, genretmp.GenreId);
            }
            bookRepository.UpdateBook(book);
        }

        public bool DoesBookExists(int bookId)
        {
            var doesExists = bookRepository.getBookById(bookId);
            return doesExists == null ? false : true;
        }

        public void UpdateWriter(Writer writer)
        {
            writerRepository.UpdateWriter(writer);
        }

        public void DeleteWriter(int id)
        {
            writerRepository.DeleteWriter(GetWriterById(id));
        }

        public IEnumerable<Book> WriterBooks(int writerId)
        {
            return writerRepository.WriterBooks(writerId);
        }

        public ICollection<Genre> WriterGenres(int writerId)
        {
            var books = WriterBooks(writerId);
            HashSet<Genre> writergenres = new HashSet<Genre>();

            foreach(var book in books)
            {
                var genres = BookGenres(book.BookId);

                foreach(var genre in genres)
                {
                    writergenres.Add(genre);
                }
            }

            return writergenres;
        }

        public List<Book> FindBooksByGenre(int genreId)
        {
            if(genreId == 0)
            {
                return bookRepository.ShowBooks().ToList();
            }
            return bookRepository.GetBooksByGenre(genreId);
        }
    }
}
