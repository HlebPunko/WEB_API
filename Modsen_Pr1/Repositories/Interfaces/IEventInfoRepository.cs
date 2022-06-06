using Modsen_Pr1.Models;

namespace Modsen_Pr1.Repositories.Interfaces
{
    public interface IEventInfoRepository
    {
        Task<IEnumerable<EventInformation>> GetAllAsync();
        Task<EventInformation?> GetAsync(int id);
        Task<EventInformation?> AddAsync(EventInformation entity);
        Task<EventInformation?> UpdateAsync(int id, EventInformation entity);
        Task<EventInformation?> DeleteAsync(int id);
    }
}
