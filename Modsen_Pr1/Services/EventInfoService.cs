using LanguageExt.Common;
using Modsen_Pr1.Models;
using Modsen_Pr1.Repositories.Interfaces;

namespace Modsen_Pr1.Services
{
    public class EventInfoService : IEventInfoService
    {
        private readonly IEventInfoRepository _repository;
        private readonly IAuthenticationService _authenticationService;

        public EventInfoService(IEventInfoRepository repository, IAuthenticationService authenticationService)
        {
            _repository = repository;
            _authenticationService = authenticationService;
        }
        public async Task<Result<EventInformation>> AddAsync(EventInformation entity)
        {
            var user = _authenticationService.CurrentUser;

            if (user is null) return new Result<EventInformation>(new BadHttpRequestException("User not found"));

            try
            {
                if (entity.UserId == 0) entity.UserId = user.Id;

                var addedEntity = await _repository.AddAsync(entity);

                if (addedEntity is null) return new Result<EventInformation>(new ArgumentException());

                return new Result<EventInformation>(addedEntity);
            }
            catch (Exception ex) { return new Result<EventInformation>(ex); }
        }

        public async Task<Result<EventInformation>> DeleteAsync(int id)
        {
            var user = _authenticationService.CurrentUser;

            if (user is null) return new Result<EventInformation>(new BadHttpRequestException("User not found"));

            try
            {
                var currentEntity = await _repository.GetAsync(id);

                if (currentEntity is null || currentEntity.UserId != user.Id) return new Result<EventInformation>(new ArgumentOutOfRangeException("Wrong UserId"));

                var deletedEntity = await _repository.DeleteAsync(id);

                if (deletedEntity is null) return new Result<EventInformation>(new ArgumentException());

                return new Result<EventInformation>(deletedEntity);
            }
            catch (Exception ex) { return new Result<EventInformation>(ex); }
        }

        public async Task<Result<IEnumerable<EventInformation>>> GetAllAsync()
        {
            var user = _authenticationService.CurrentUser;

            if (user is null) return new Result<IEnumerable<EventInformation>>(new BadHttpRequestException("User not found"));

            try
            {
                var eventInfos = await _repository.GetAllAsync();

                return new Result<IEnumerable<EventInformation>>(eventInfos.Where(x => x.UserId == user.Id));
            }
            catch (Exception ex) { return new Result<IEnumerable<EventInformation>>(ex); }
        }

        public async Task<Result<EventInformation>> GetAsync(int id)
        {
            var user = _authenticationService.CurrentUser;

            if (user is null) return new Result<EventInformation>(new BadHttpRequestException("User not found"));

            try
            {
                var result = await _repository.GetAsync(id);

                if (result is null || result.UserId != user.Id) return new Result<EventInformation>(new ArgumentException());

                return new Result<EventInformation>(result);
            }
            catch (Exception ex) { return new Result<EventInformation>(ex); }
        }

        public async Task<Result<EventInformation>> UpdateAsync(int id, EventInformation entity)
        {
            var user = _authenticationService.CurrentUser;

            if (user is null) return new Result<EventInformation>(new BadHttpRequestException("User not found"));

            try
            {
                var currentEntity = await _repository.GetAsync(id);
                
                if (currentEntity is null || currentEntity.UserId != user.Id) return new Result<EventInformation>(new ArgumentOutOfRangeException("Wrong UserId"));

                entity.UserId = user.Id;
                
                var updatedEntity = await _repository.UpdateAsync(id, entity);


                if (updatedEntity is null) return new Result<EventInformation>(new ArgumentException());

                return new Result<EventInformation>(updatedEntity);
            }
            catch (Exception ex) { return new Result<EventInformation>(ex); }
        }
    }
}
