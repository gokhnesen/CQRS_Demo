using Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Security.JWT
{
    public  interface ITokenHelper
    {
        AccessToken CreateToken(User user,IList<OperationClaim> operationClaims);
        RefreshToken CreateRefreshToken(User user, string ipAddress);
    }
}
