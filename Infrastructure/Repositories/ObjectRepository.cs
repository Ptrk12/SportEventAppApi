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

        public async Task<bool> CreateObject(ObjectEntity entity)
        {
            try
            {
                await _context.Objects.AddAsync(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteObject(int id)
        {
            try
            {
                var entity = await _context.Objects.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

                if (entity != null)
                {
                    _context.Objects.Remove(entity);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<ObjectEntity>> GetAllObjects()
        {
            var result = await _context.Objects.ToListAsync();
            return result;
        }

        public async Task<ObjectEntity> GetObjectById(int id)
        {
            var result = await _context.Objects.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<bool> Updateobject(int id, ObjectEntity entity)
        {
            try
            {
                _context.Update(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
    public interface IObjectRepository
    {
        Task<ObjectEntity> GetObjectById(int id);
        Task<IEnumerable<ObjectEntity>> GetAllObjects();
        Task<bool> CreateObject(ObjectEntity entity);
        Task<bool> DeleteObject(int id);
        Task<bool> Updateobject(int id, ObjectEntity entity);
    }
}
