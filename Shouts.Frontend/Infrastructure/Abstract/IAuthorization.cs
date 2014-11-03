using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shouts.Frontend.Infrastructure.Abstract
{
    public interface IAuthorization
    {
        bool Login(string id, string password);
        void Logoff();
    }
}
