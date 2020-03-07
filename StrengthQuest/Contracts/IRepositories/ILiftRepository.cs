using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.IRepositories
{
    public interface ILiftRepository : IUserBaseRepository<Lift>
    {
        Lift Get(string id, string uid);
        IEnumerable<Lift> GetLiftsByUserId(string uid);
    }
}
