using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using SportEventAppApi.Config;

namespace Infrastructure.Repositories
{
    public class ObjectRepository : IObjectRepository
    {
        private readonly SportEventAppDbContext _context;

        public ObjectRepository(SportEventAppDbContext context)
        {
            _context = context;
        }
        public async Task<ObjectEntity> GetObjectById(int id)
        {
            var result = await _context.Objects.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
    }
    public interface IObjectRepository
    {
        Task<ObjectEntity> GetObjectById(int id);
    }
}
