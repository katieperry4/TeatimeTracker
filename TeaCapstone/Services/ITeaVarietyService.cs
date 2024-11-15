using TeaCapstone.Models;

namespace TeaCapstone.Services
{
    public interface ITeaVarietyService : IDbService<TeaVariety>
    {

        public List<TeaVariety> GetVarietiesByType(int typeId);
        public int GetIdByName(string name);
    }
}
