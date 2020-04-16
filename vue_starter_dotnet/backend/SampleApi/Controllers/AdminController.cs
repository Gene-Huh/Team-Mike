using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApproval.DAL;
using ProductApproval.Models;
using ProductApproval.Password_and_Authentication_Helpers;

namespace ProductApproval.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private IUsersDAO userDAO;
        private ITokenGenerator tokenGenerator;

        public AdminController(ITokenGenerator tokenGenerator, IUsersDAO userDao)
        {
            this.tokenGenerator = tokenGenerator;
            this.userDAO = userDao;
        }





    }
}
