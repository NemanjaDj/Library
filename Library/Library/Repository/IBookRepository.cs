﻿using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Repository
{
    public interface IBookRepository
    {
        IEnumerable<Book> ShowBooks();        

        void InsertBook(Book book);

        Book getBookById(int bookId);
        List<Genre> GetAllGenres();

        Genre getGenreByName(string genreName);

        void AddBookGenre(int bookId, int genreId);
        
        Genre getGenreById(int genreId);

        List<int> GetGenresId(int bookId);

        void AddNumberOfBooks(int bookId, int? numberOfBooks);

        int? NumberOfBook(int bookId);

        List<Book> FindBookByName(string bookName);

        void UpdateBook(Book book);

        void DeleteBookGenres(int bookId);
        List<Book> GetBooksByGenre(int genreId);
    }
}
