using Library.Data;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Repository
{
    public class UserRepository : IUserRepository
    {
        public ApplicationDbContext applicationDbContext;

        public UserRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public void AddBookForUser(string userId, int bookId)
        {
            var bookRent = new BookRent();
            bookRent.BookId = bookId;
            bookRent.UserId = userId;
            applicationDbContext.Add(bookRent);
            applicationDbContext.SaveChanges();
        }

        public List<int> GetUserBooks(string userId)
        {
            return applicationDbContext.BookRents.Where(br => br.UserId == userId).Select(br => br.BookId).ToList();
        }

        public void RateBook(string userId, int bookId, int rate)
        {
            var bookRateByUser = new Rating();
            bookRateByUser.UserId = userId;
            bookRateByUser.BookId = bookId;
            bookRateByUser.rate = rate;
            applicationDbContext.Add(bookRateByUser);
            applicationDbContext.SaveChanges();
        }
    }
}
