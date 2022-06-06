using LanguageExt.Common;
using Modsen_Pr1.Models;

namespace Modsen_Pr1.Services
{
    public interface IEventInfoService
    {
        Task<Result<IEnumerable<EventInformation>>> GetAllAsync();
        Task<Result<EventInformation>> GetAsync(int id);
        Task<Result<EventInformation>> AddAsync(EventInformation entity);
        Task<Result<EventInformation>> UpdateAsync(int id, EventInformation entity);
        Task<Result<EventInformation>> DeleteAsync(int id);
    }
}
