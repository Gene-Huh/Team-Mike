using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ProductApproval.Controllers
{
    public class UsersController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}