using DitConMeMayWASM.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace DitConMeMayWASM.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private List<Users> lst;
        [HttpGet]
        public async Task<IEnumerable<Users>> GetAllCustomersAsync()
        {
            //for testing purpose

            Users user = new Users()
            {
                Class = "IT1212",
                FullName = "AnhThuyen"
            };
            Users user2 = new Users()
            {
                Class = "IT112",
                FullName = "Fucking"
            };
            lst.Add(user);
            lst.Add(user2);
            var list = (from s in lst select new Users { Class = s.Class, FullName = s.FullName }).ToList();
            return list;

            //return await _service.GetAllCustomersAsync();
        }
    }
}
