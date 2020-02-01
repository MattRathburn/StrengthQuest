using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.IRepositories
{
  public interface ILiftSequenceRepository : IUserBaseRepository<LiftSequence> 
  {
    IEnumerable<LiftSequence> Get(string id, string uid);
  }
}
