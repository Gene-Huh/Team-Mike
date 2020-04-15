using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApproval.DAL;
using ProductApproval.Models;
using ProductApproval.Password_and_Authentication_Helpers;
using static ProductApproval.Password_and_Authentication_Helpers.HashProvider;
using Microsoft.Extensions.Configuration;

namespace ProductApproval.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUsersDAO dao;
        private ITokenGenerator tokenGenerator;

        public UsersController(IUsersDAO dataAccessLayer, ITokenGenerator tokenGenerator)
        {
            dao = dataAccessLayer;
            this.tokenGenerator = tokenGenerator;
        }

        [HttpGet]
        public IList<User> GetUsers()
        {
            return dao.GetAllUsers();
        }

        [HttpPut("edit/{username}")]
        public ActionResult EditUser(string username, [FromBody]User user)
        {
            if(user.Username != null)
            {
                user = dao.UpdateUser(user);
            }
            return Ok();
        }

        [HttpPost("add", Name = "AddUser")]
        public string AddUser(User user)
        {
            string success = user.Username + " successfully added.";
            string failed = "Username not valid.";
            int response = 0;

            User dbCheck = dao.CheckUser(user);
            if (dbCheck.Username != user.Username)
            {
                response = dao.AddUser(user);
            }
            
            return (response==1)?success:failed;
        }

        [HttpDelete("delete/{username}", Name = "DeleteUser")]
        public int DeleteUser(string username)
        {
            if (username != null)
            {
                return dao.DeleteUser(username);
            }
            return 0;
        }
    }
}