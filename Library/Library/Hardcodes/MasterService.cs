using Library.Data;
using Library.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Hardcodes
{
    abstract public class MasterService
    {
        protected IBookRepository bookRepository;
        protected IWriterRepository writerRepository;
        protected IUserRepository userRepository;

        public MasterService()
        {
            this.bookRepository = new BookRepository(new ApplicationDbContext());
            this.writerRepository = new WriterRepository(new ApplicationDbContext());
            this.userRepository = new UserRepository(new ApplicationDbContext());
        }


    }
}
