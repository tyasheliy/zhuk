using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using zhuk.Data;
using zhuk.Models;

namespace zhuk.Controllers
{
    public class HomeController : Controller
    {
        private DataContext _db;
        public HomeController(DataContext db) => _db = db;
        public IActionResult Index()
        {
            return View();
        }

        [Route("about")]
        public IActionResult About()
        {
            return View();
        }
		
		[HttpGet]
        [Route("contact")]
        public IActionResult Contact()
        {
            return View();
        }

		[HttpPost]
		[Route("contact")]
		public IActionResult Contact(string firstname, string secondname, string middlename, string email, string phone, string message)
		{
		    var clientExists = false;
            foreach (var c in _db.Clients.ToList())
            {
                if (c.Email == email || c.Phone == phone)
                {
                    clientExists = true;
                    break;
                }
            }
            if (!clientExists)
            {
                var client = new Client
                {
                    Id = Guid.NewGuid(),
                    Firstname = firstname,
                    Secondname = secondname,
                    Middlename = middlename,
                    Email = email,
                    Phone = phone
                };
                _db.Clients.Add(client);
                try
                {
                    _db.SaveChanges();
                }
                catch
                {
                    return Redirect("/");
                }
            }
            var clientid = _db.Clients.Where(c => c.Email == email || c.Phone == phone).First().Id;
            var messageRecord = new Message
            {
                Id = Guid.NewGuid(),
                ClientId = clientid,
                Text = message,
                Date = DateTime.Now
            };
            _db.Messages.Add(messageRecord);
            try
            {
                _db.SaveChanges();  
            }
            catch
            {
                return Redirect("/");
            }
            return View();
		}

        [HttpGet]
        [Route("book")]
        public IActionResult Book()
        {
            return View();
        }

        [HttpPost]
        [Route("book")]
        public IActionResult Book(string firstname, string secondname, string middlename, string email, string phone, DateTime date)
        {
            var clientExists = false;
            foreach (var c in _db.Clients)
            {
                if (c.Email == email || c.Phone == phone)
                {
                    clientExists = true;
                    break;
                }
            }
            if (!clientExists)
            {
                var client = new Client
                {
                    Id = Guid.NewGuid(),
                    Firstname = firstname,
                    Secondname = secondname,
                    Middlename = middlename,
                    Email = email,
                    Phone = phone
                };
                _db.Clients.Add(client);
                try
                {
                    _db.SaveChanges();
                }
                catch
                {
                    return Redirect("/");
                }
            }
            var clientid = _db.Clients.Where(c => c.Email == email).First().Id;
            var book = new Book
            {
                Id = Guid.NewGuid(),
                ClientId = clientid,
                Date = date
            };
            _db.Booking.Add(book);
            try
            {
                _db.SaveChanges();
            }
            catch
            {
                return Redirect("/");
            }
            return View();
        }
    }
}
