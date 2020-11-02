using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Library.Hardcodes;
using Library.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class UserController : Controller
    {

        private BookService bookService;
        private UserService userService;

        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)

        {
            this.bookService = new BookService();
            this.userService = new UserService();
            _userManager = userManager;
        }

        public IActionResult UserPage()
        {
            ViewData["Books"] = userService.GetUserBooks(_userManager.GetUserId(HttpContext.User));
            return View();
        }

        public IActionResult AddBookForUser(int id)
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            userService.AddBookForUser(userId, id);
            var bookrender = bookService.RenderBook(id);
            return RedirectToAction("BookTemplate", "Book", new { id = id });
        }
    }
}