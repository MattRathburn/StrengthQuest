using Entities.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Contracts.IServices
{
    public interface ILiftNameService : IBaseService<LiftName>
    {
        SelectList GetAllToSelectList();
    }
}
