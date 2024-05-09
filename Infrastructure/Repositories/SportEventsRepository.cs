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

        public async Task<IEnumerable<SportEventEntity>> GetAllSportEvents()
        {
            var result = await _context.SportEvents.AsNoTracking().Include(x=>x.Object).ToListAsync();
            return result;
        }

        public async Task<SportEventEntity> GetSportEventById(int id)
        {
            var result = await _context.SportEvents.FirstOrDefaultAsync(x=>x.Id == id);
            return result;
        }
    }
    public interface ISportEventsRepository
    {
        Task<IEnumerable<SportEventEntity>> GetAllSportEvents();
        Task<SportEventEntity> GetSportEventById(int id);
        Task<bool> CreateSportEvent(SportEventEntity entity);
    }
}
