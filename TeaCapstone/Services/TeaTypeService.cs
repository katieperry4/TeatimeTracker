using Microsoft.EntityFrameworkCore;
using TeaCapstone.Data;
using TeaCapstone.Models;

namespace TeaCapstone.Services
{
    public class TeaTypeService : IDbService<TeaType>
    {

        private readonly ApplicationDbContext _dbContext;

        public TeaTypeService(ApplicationDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }
        public List<TeaType> GetAllEntities()
        {
            return _dbContext.TeaType.ToList();
        }

        public TeaType GetById(int id)
        {
            return (TeaType)_dbContext.TeaType.Where(t => t.Id == id).FirstOrDefault();
        }

        public int GetIdByName(string name)
        {
            TeaType teaType = (TeaType)_dbContext.TeaType.Where(t => t.Name == name).FirstOrDefault();

            return teaType.Id;
        }
    }
}
