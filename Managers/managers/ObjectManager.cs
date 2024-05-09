using ApplicationCore.Models;

namespace Managers.managers
{
    public class ObjectManager : IObjectManager
    {
        public Task<ObjectClass> GetObjectById(int id)
        {
            throw new NotImplementedException();
        }
    }
    public interface IObjectManager
    {
        Task<ObjectClass> GetObjectById(int id);
    }
}
