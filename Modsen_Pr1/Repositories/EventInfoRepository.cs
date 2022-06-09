using Microsoft.EntityFrameworkCore;
using Modsen_Pr1.Models;
using Modsen_Pr1.Repositories.Interfaces;

namespace Modsen_Pr1.Repositories
{
    public class EventInfoRepository : IEventInfoRepository
    {
		protected readonly AppContext _context;
		
		public EventInfoRepository(AppContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<EventInformation>> GetAllAsync() => await _context.EventInformations.ToListAsync();
		public async Task<EventInformation?> GetAsync(int id) => await _context.EventInformations.SingleOrDefaultAsync(e => e.Id == id);

		public async Task<EventInformation?> AddAsync(EventInformation entity)
        {
			var eventInfo = (await _context.EventInformations.AddAsync(entity)).Entity;
			var resSave = await _context.SaveChangesAsync() > 0;

			if (!resSave) return null;

			return eventInfo;
		} 

		public async Task<EventInformation?> UpdateAsync(int id, EventInformation entity)
		{
			var eventInfo = await _context.EventInformations.FirstOrDefaultAsync(u => u.Id == id); 

			if (eventInfo is null) return null;
			//_context.Update(entity);
			
			eventInfo.Location = entity.Location;
			eventInfo.EventDescription = entity.EventDescription;
			eventInfo.EventName = entity.EventName;
			eventInfo.Organizer = entity.Organizer;

			_context.Entry(eventInfo).State = EntityState.Modified;

			var resSave = await _context.SaveChangesAsync() > 0;

			if (!resSave) return null;

			return eventInfo;
		}

		public async Task<EventInformation?> DeleteAsync(int id)
		{
			var eventInfo = await _context.EventInformations.FirstOrDefaultAsync(u => u.Id == id); ;

			if (eventInfo is null) return null;
			_context.Remove(eventInfo);
			var resSave = await _context.SaveChangesAsync() > 0;

			if (!resSave) return null;

			return eventInfo;
		}
	}
}
