﻿using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Repository
{
    public interface IWriterRepository
    {

        Writer GetWriterByName(string writerName);

        IEnumerable<Writer> GetWriters();

        Writer GetWriterById(int writerId);

        Writer GetBookWriter(int bookId);

        void InsertWriter(Writer writer);

        int? GetWriterYearOfBirth(int writerId);

        void UpdateWriter(Writer writer);

        void DeleteWriter(Writer writer);

        IEnumerable<Book> WriterBooks(int writerId);
    }
}
