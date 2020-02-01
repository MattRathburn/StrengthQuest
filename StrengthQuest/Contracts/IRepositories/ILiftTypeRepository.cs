using Contracts.IRepositories;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.IRepositories
{
  public interface ILiftTypeRepository : IBaseRepository<LiftType>
  {
    LiftType GetByName(string name);
  }
}
