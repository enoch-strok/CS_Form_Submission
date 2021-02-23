using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CS_Form_Submission.Models;
using Form.Models;

namespace CS_Form_Submission.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

//_____________________________________/User\___________________________________________________//
            [HttpGet("/user")]
            public IActionResult NewUser()
        {
            // While being hard-coded here, this user instance will eventually come from our DB
            // Here we pass this instance to our View
            return View();
            // If we also need to include the name of our View, we pass our instance as a second argument
            // return View("OtherView", someUser);
        }
//-----------------------------------------------------------------------------------------------//

//_____________________________________/User-Create\___________________________________________________//
[HttpPost("user/create")]
public IActionResult Create(User user)
{
    if(ModelState.IsValid)
    {
        // do somethng!  maybe insert into db?  then we will redirect
        return RedirectToAction("Success");
    }
    else
    {
        // Oh no!  We need to return a ViewResponse to preserve the ModelState, and the errors it now contains!
        return View("NewUser");
    }
}
//-----------------------------------------------------------------------------------------------//

//_____________________________________/Success\___________________________________________________//
        public IActionResult Success()
        {
            return View();
        }
//-----------------------------------------------------------------------------------------------//




    }
}
