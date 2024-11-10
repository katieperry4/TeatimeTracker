using TeaCapstone.Models;

namespace TeaCapstone.Services
{
    public interface ITeaLogService : IDbService<TeaLog>
    {

        public List<TeaLog> GetAllById(string userId);
        public void AddTeaLog(TeaLog log);
        public void DeleteTeaLog(TeaLog log);

        public bool UpdateTeaLog(int id, TeaLog log);

        public int GetTotalCups(string userId);
        public int GetCupsToday(string userId);
        public int CaffeineToday(string userId);

        public List<TeaLog> GetCupsByDate(DateTime date);
    }
}
