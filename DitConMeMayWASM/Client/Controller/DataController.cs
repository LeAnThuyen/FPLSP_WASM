using DitConMeMayWASM.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS_FPL.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {

        private readonly DBClient _dBClient;
        private List<Users> _lst;
        public DataController()
        {

            _lst = new List<Users>();
        }

        [HttpGet]
        public async Task<List<Users>> Get()
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
