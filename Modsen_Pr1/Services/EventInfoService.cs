using LanguageExt.Common;
using Modsen_Pr1.Models;
using Modsen_Pr1.Repositories.Interfaces;

namespace Modsen_Pr1.Services
{
    public class EventInfoService : IEventInfoService
    {
        private readonly IEventInfoRepository _repository;

        public EventInfoService(IEventInfoRepository repository)
        {
            _repository = repository;
        }
        public async Task<Result<EventInformation>> AddAsync(EventInformation entity)
        {
            try
            {
                var addedEntity = await _repository.AddAsync(entity);

                if (addedEntity is null) return new Result<EventInformation>(new ArgumentException());

                return new Result<EventInformation>(addedEntity);
            }
            catch (Exception ex) { return new Result<EventInformation>(ex); }
        }

        public async Task<Result<EventInformation>> DeleteAsync(int id)
        {
            try
            {
                var deletedEntity = await _repository.DeleteAsync(id);

                if (deletedEntity is null) return new Result<EventInformation>(new ArgumentException());

                return new Result<EventInformation>(deletedEntity);
            }
            catch (Exception ex) { return new Result<EventInformation>(ex); }
        }

        public async Task<Result<IEnumerable<EventInformation>>> GetAllAsync()
        {
            try
            {
                var eventInfos = await _repository.GetAllAsync();

                return new Result<IEnumerable<EventInformation>>(eventInfos);
            }
            catch (Exception ex) { return new Result<IEnumerable<EventInformation>>(ex); }
        }

        public async Task<Result<EventInformation>> GetAsync(int id)
        {
            try
            {
                var result = await _repository.GetAsync(id);

                // TODO : replace with custom exception
                if (result is null) return new Result<EventInformation>(new ArgumentException());

                return new Result<EventInformation>(result);
            }
            catch (Exception ex) { return new Result<EventInformation>(ex); }
        }

        public async Task<Result<EventInformation>> UpdateAsync(int id, EventInformation entity)
        {
            try
            {
                var updatedEntity = await _repository.UpdateAsync(id, entity);


                if (updatedEntity is null) return new Result<EventInformation>(new ArgumentException());

                return new Result<EventInformation>(updatedEntity);
            }
            catch (Exception ex) { return new Result<EventInformation>(ex); }
        }
    }
}
