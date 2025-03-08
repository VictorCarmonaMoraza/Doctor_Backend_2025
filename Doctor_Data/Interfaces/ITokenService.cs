
using Doctor_Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctor_Data.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
