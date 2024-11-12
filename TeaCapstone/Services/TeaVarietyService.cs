using Microsoft.EntityFrameworkCore;
using TeaCapstone.Data;
using TeaCapstone.Models;

namespace TeaCapstone.Services
{
    public class TeaVarietyService : ITeaVarietyService
    {
        private readonly ApplicationDbContext _dbContext;

        public TeaVarietyService(ApplicationDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }
        public List<TeaVariety> GetAllEntities()
        {
            return _dbContext.TeaVariety.ToList();
        }

        public TeaVariety GetById(int id)
        {
            
            return _dbContext.TeaVariety.Where(t => t.Id == id).FirstOrDefault();


        }

        public int GetIdByName(string name)
        {
            TeaVariety teaVariety = (TeaVariety)_dbContext.TeaVariety.Where(t => t.Name == name).FirstOrDefault();

            return teaVariety.Id;
        }

        public List<TeaVariety> GetVarietiesByType(int typeId)
        {
            return _dbContext.TeaVariety.Where(t => t.TeaTypeId == typeId).ToList();
        }
    }
}
