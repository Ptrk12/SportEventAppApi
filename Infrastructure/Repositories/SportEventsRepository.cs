using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using SportEventAppApi.Config;
using System.Text;
using System.Text.Json;

namespace Infrastructure.Repositories
{
    public class SportEventsRepository : ISportEventsRepository
    {
        private readonly SportEventAppDbContext _context;

        public SportEventsRepository(SportEventAppDbContext context)
        {
              _context = context;
        }

        public async Task<(bool Result, SportEventEntity? resultEntity)> CreateSportEvent(SportEventEntity entity)
        {
            try
            {
                await _context.SportEvents.AddAsync(entity);
                await _context.SaveChangesAsync();
                return (true,entity);
            }
            catch (Exception ex)
            {
                return (false,null);
            }
        }

        public async Task<bool> CreateAssignedPeopleRecord(EventAssignersEntity entity)
        {
            try
            {
                await _context.EventAssigners.AddAsync(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
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

        public async Task<int> GetAssignedPeopleToEventCount(int sportEventId)
        {
            var result = 0;
            var entity = await _context.EventAssigners.FirstOrDefaultAsync(x => x.EventId == sportEventId);
            if(entity != null)
            {
                using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(entity.AssignedPeople)))
                {
                    var jsonDb = await JsonSerializer.DeserializeAsync<string[]>(stream);
                    result = jsonDb.Length;
                }
            }

            return result;
        }

        public async Task<bool> AssignOrRemoveFromEvent(int eventId, string assignersJson)
        {
            try
            {
                var result = false;
                var foundEntity = await _context.EventAssigners.FirstOrDefaultAsync(x => x.EventId == eventId);

                if (foundEntity != null)
                {
                    foundEntity.AssignedPeople = assignersJson;
                    await _context.SaveChangesAsync();
                    result = true;
                }

                return result;
            }
            catch(Exception ex) 
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

        public async Task<string?> GetAssignersInEvent(int sportEventId)
        {
            var result = (await _context.EventAssigners.AsNoTracking().FirstOrDefaultAsync(x => x.EventId == sportEventId)).AssignedPeople;
            return result;
        }

        public async Task<SportEventEntity> GetSportEventById(int id)
        {
            var result = await _context.SportEvents.AsNoTracking().Include(x => x.Object).FirstOrDefaultAsync(x=>x.Id == id);
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
        Task<string?> GetAssignersInEvent(int sportEventId);
        Task<int> GetAssignedPeopleToEventCount(int sportEventId);
        Task<bool> CreateAssignedPeopleRecord(EventAssignersEntity entity);
        Task<IEnumerable<SportEventEntity>> GetAllSportEvents();
        Task<SportEventEntity> GetSportEventById(int id);
        Task<(bool Result, SportEventEntity? resultEntity)> CreateSportEvent(SportEventEntity entity);
        Task<bool> UpdateSportEvent(int id, SportEventEntity entity);
        Task<bool> DeleteSportEvent(int id);
        Task<IEnumerable<SportEventEntity>> GetAllSportEventsInObject(int objectId);
        Task<bool> AssignOrRemoveFromEvent(int eventId, string assignersJson);
    }
}
