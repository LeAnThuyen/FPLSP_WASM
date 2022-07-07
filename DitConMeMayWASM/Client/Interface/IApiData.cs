using DitConMeMayWASM.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DitConMeMayWASM.Interface
{
    public interface IApiData
    {
        Task<List<Users>> GetUsers();
    }
}
