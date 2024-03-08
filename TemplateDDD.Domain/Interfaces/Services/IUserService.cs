using TemplateDDD.Domain.Entities;
using TemplateDDD.Domain.Views;

namespace TemplateDDD.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<UserView> Get(Guid id);
        Task<IEnumerable<UserView>> GetAll();
        Task<UserView> Post(UserView user);
        Task<UserView> Put(UserView user);
        Task<bool> Delete(Guid id);
    }
}
