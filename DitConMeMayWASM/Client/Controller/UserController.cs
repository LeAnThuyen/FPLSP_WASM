using DitConMeMayWASM.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS_FPL.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private DBClient _dBClient;
        private List<Users> _lst;
        public UserController(DBClient dBClient)
        {
            _dBClient = dBClient;
            _lst = new List<Users>();
        }

        [HttpGet]
        [Route("apiget")]
        public async Task<List<Users>> GetAll()
        {
            Users users = new Users()
            {

                FullName = "thuyen",
                Class = "IT16302"
            };
            _lst.Add(users);
            return _lst;
        }


    }
}
