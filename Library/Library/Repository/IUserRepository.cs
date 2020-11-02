using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Repository
{
    public interface IUserRepository
    {
        void AddBookForUser(string userId, int bookId);
        List<int> GetUserBooks(string userId);
    }
}
