using Microsoft.EntityFrameworkCore;
using TeaCapstone.Data;
using TeaCapstone.Models;

namespace TeaCapstone.Services
{
    public class ReportsService : IReportsService
    {
        private ApplicationDbContext _dbContext;

        public ReportsService(ApplicationDbContext dbContext) 
        {
            _dbContext = dbContext;
         }

        public async Task<List<CaffeinePerDay>> GetCaffeinePerDay(string userId)
        {
            var query = from tealog in _dbContext.TeaLog
                        where tealog.UserId == userId
                        join teaVariety in _dbContext.TeaVariety on tealog.TeaVarietyId equals teaVariety.Id
                        group new { tealog, teaVariety } by tealog.Time into dateGroup
                        orderby dateGroup.Key
                        select new CaffeinePerDay
                        {
                            Date = dateGroup.Key,
                            CaffeineTotal = dateGroup.Sum(x => x.teaVariety.CaffeineContent)
                        };
            return await query.ToListAsync();
        }

        public async Task<List<CupsPerDayModel>> GetCupsPerDayReport(string userId)
        {
            //query db to get date, a count of the cups for that date
            var query = from teaLog in _dbContext.TeaLog
                        where teaLog.UserId == userId
                        group teaLog by teaLog.Time.Date into teaGroup
                        select new CupsPerDayModel
                        {
                            Date = teaGroup.Key,
                            CupsTotal = teaGroup.Count()
                        };
            return await query.ToListAsync();
        }

        public async Task<List<FavTypeModel>> GetFavTypeReport(string userId)
        {
            var query = from teaLog in _dbContext.TeaLog
                        where teaLog.UserId == userId
                        join teaVariety in _dbContext.TeaVariety on teaLog.TeaVarietyId equals teaVariety.Id
                        group teaLog by new { teaLog.TeaVarietyId, teaVariety.Name } into teaGroup
                        orderby teaGroup.Count() descending
                        select new FavTypeModel
                        {
                            Name = teaGroup.Key.Name,
                            TotalCups = teaGroup.Count()
                        };
            return await query.ToListAsync();
        }
    }
}
