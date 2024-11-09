using Microsoft.EntityFrameworkCore;
using TeaCapstone.Data;
using TeaCapstone.Models;

namespace TeaCapstone.Services
{
    public class TeaVarietyService : IDbService<TeaVariety>
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
            return (TeaVariety)_dbContext.TeaVariety.Where(t => t.Id == id);
        }

        public int GetIdByName(string name)
        {
            TeaVariety teaVariety = (TeaVariety)_dbContext.TeaVariety.Where(t => t.Name == name);

            return teaVariety.Id;
        }
    }
}
