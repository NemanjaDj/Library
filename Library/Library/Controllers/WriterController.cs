﻿using Library.Hardcodes;
using Library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
    public class WriterController : Controller
    {
        private BookService bookService;

        public WriterController()
        {
            bookService = new BookService();
        }

        public IActionResult Writers()
        {
            var writers = bookService.GetWriters();

            foreach(var writer in writers)
            {
                writer.YearOfBirth = bookService.GetWriterAge(writer.WriterId);
            }

            return View(writers);
        }

        public IActionResult AddWriter()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddWriter(IFormCollection collection, Writer writer)
        {
            if (!ModelState.IsValid)
            {
                return View("AddWriter", writer);
            }

            try
            {
                bookService.InsertWriter(writer);
                return RedirectToAction("Writers");
            }
            catch (Exception ex)
            {
            }

            return View();
        }
    }
}
