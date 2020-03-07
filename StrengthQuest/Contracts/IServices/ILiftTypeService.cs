using Entities.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Contracts.IServices
{
    public interface ILiftTypeService : IBaseService<LiftType>
    {
        SelectList GetAllToSelectList();
    }
}
