using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Icy_Olympus.Services
{
    public interface IRegister
    {
        Task<string> RegisterWithEmailPassword(string email, string password);
    }
}
