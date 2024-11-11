using Microsoft.EntityFrameworkCore;
using TeaCapstone.Data;
using TeaCapstone.Models;

namespace TeaCapstone.Services
{
    public class TeaLogService : ITeaLogService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ITeaVarietyService _teaVarietyService;

        public TeaLogService(ApplicationDbContext dbcontext, ITeaVarietyService teaVarietyService)
        {
            _dbContext = dbcontext;
            _teaVarietyService = teaVarietyService;
        }
        public List<TeaLog> GetAllEntities()
        {
            return _dbContext.TeaLog.ToList();
        }

        public TeaLog GetById(int id)
        {
            return (TeaLog)_dbContext.TeaLog.Where(t => t.Id == id).FirstOrDefault();
        }

        //note: this is by user ID
        public List<TeaLog> GetAllById(string id)
        {
            return _dbContext.TeaLog.Where(t => t.UserId == id).ToList();
        }

        public void AddTeaLog(TeaLog tealog)
        {
         
            _dbContext.TeaLog.Add(tealog);
           _dbContext.SaveChanges();
        }

        public  void DeleteTeaLog(TeaLog tealog)
        {
            _dbContext.TeaLog.Remove(tealog);
            _dbContext.SaveChanges();
        }

        public bool UpdateTeaLog(int id, TeaLog tealog)
        {
            TeaLog oldLog = _dbContext.TeaLog.Find(id);

            if (oldLog == null)
            {
                return false;
            }

            oldLog.TeaVariety = tealog.TeaVariety;
            oldLog.TeaVarietyId = tealog.TeaVarietyId;
            oldLog.Time = tealog.Time;

            _dbContext.SaveChanges();

            return true;
        }

        public int GetTotalCups(string userId)
        {
            return _dbContext.TeaLog.Where(t => t.UserId == userId).Count();
        }

        public int GetCupsToday(string userId)
        {
            return _dbContext.TeaLog.Where(t => t.UserId == userId && t.Time == DateTime.Today).Count();
        }

        public int CaffeineToday(string userId)
        {
            List<TeaLog> todaysLogs = _dbContext.TeaLog.Where(t => t.Time == DateTime.Today && t.UserId == userId).ToList();
            int caffeineToday = 0;
            foreach (TeaLog log in todaysLogs)
            {
                TeaVariety currentTeaVariety = _teaVarietyService.GetById(log.TeaVarietyId);
                if (currentTeaVariety.CaffeineContent > 0)
                {
                    caffeineToday += log.TeaVariety.CaffeineContent;
                }
                else
                {
                    continue;
                }
            }

            return caffeineToday;
        }

        public List<TeaLog> GetCupsByDate(DateTime date)
        {
            return _dbContext.TeaLog.Where(t => t.Time.Date == date.Date).ToList();
        }
    }
}
