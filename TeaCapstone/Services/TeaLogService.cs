using Microsoft.EntityFrameworkCore;
using TeaCapstone.Data;
using TeaCapstone.Models;

namespace TeaCapstone.Services
{
    public class TeaLogService : IDbService<TeaLog>
    {
        private readonly ApplicationDbContext _dbContext;

        public TeaLogService(ApplicationDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }
        public List<TeaLog> GetAllEntities()
        {
            return _dbContext.TeaLog.ToList();
        }

        public TeaLog GetById(int id)
        {
            return (TeaLog)_dbContext.TeaLog.Where(t => t.Id == id);
        }

        public List<TeaLog> GetAllById(string id)
        {
            return _dbContext.TeaLog.Where(t => t.UserId == id).ToList();
        }

        public void AddTeaLog(TeaLog tealog)
        {
         
            _dbContext.TeaLog.Add(tealog);
           
        }

        public  void DeleteTeaLog(TeaLog tealog)
        {
             _dbContext.TeaLog.Remove(tealog);
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
    }
}
