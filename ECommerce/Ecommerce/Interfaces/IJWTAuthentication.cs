using Ecommerce.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Interfaces
{
    public interface IJWTAuthentication
    {
        Tokens Authenticate(Users users);
    }
}
