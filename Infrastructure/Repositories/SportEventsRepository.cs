using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using SportEventAppApi.Config;

namespace Infrastructure.Repositories
{
    public class SportEventsRepository : ISportEventsRepository
    {
        private readonly SportEventAppDbContext _context;

        public SportEventsRepository(SportEventAppDbContext context)
        {
              _context = context;
        }

        public async Task<bool> CreateSportEvent(SportEventEntity entity)
        {
            try
            {
                await _context.SportEvents.AddAsync(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteSportEvent(int id)
        {
            try
            {
                var entity = await _context.SportEvents.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

                if(entity != null)
                {
                    _context.SportEvents.Remove(entity);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<SportEventEntity>> GetAllSportEvents()
        {
            var result = await _context.SportEvents.AsNoTracking().Include(x=>x.Object).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<SportEventEntity>> GetAllSportEventsInObject(int objectId)
        {
            var result = await _context.SportEvents.AsNoTracking().Where(x=>x.ObjectId == objectId).Include(x => x.Object).ToListAsync();
            return result;
        }

        public async Task<SportEventEntity> GetSportEventById(int id)
        {
            var result = await _context.SportEvents.FirstOrDefaultAsync(x=>x.Id == id);
            return result;
        }

        public async Task<bool> UpdateSportEvent(int id, SportEventEntity entity)
        {
            try
            {
                _context.ChangeTracker.Clear();
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
    public interface ISportEventsRepository
    {
        Task<IEnumerable<SportEventEntity>> GetAllSportEvents();
        Task<SportEventEntity> GetSportEventById(int id);
        Task<bool> CreateSportEvent(SportEventEntity entity);
        Task<bool> UpdateSportEvent(int id, SportEventEntity entity);
        Task<bool> DeleteSportEvent(int id);
        Task<IEnumerable<SportEventEntity>> GetAllSportEventsInObject(int objectId);
    }
}
