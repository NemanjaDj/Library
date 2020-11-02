using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Library.Hardcodes
{
    public class UserService: MasterService
    {
        public void AddBookForUser(string userId, int bookId)
        {
            userRepository.AddBookForUser(userId, bookId);
        }

        public List<Book> GetUserBooks(string userId)
        {
            var bookIds = userRepository.GetUserBooks(userId);
            List<Book> books = new List<Book>();
            foreach(var item in bookIds)
            {
                books.Add(bookRepository.getBookById(item));
            }
            return books;
        }
    }
}
