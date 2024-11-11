using TeaCapstone.Models;

namespace TeaCapstone.Services
{
    public interface IReportsService
    {
        public  Task<List<CupsPerDayModel>> GetCupsPerDayReport(string userId);

        public Task<List<FavTypeModel>> GetFavTypeReport(string userId);

        public Task<List<CaffeinePerDay>> GetCaffeinePerDay(string userId);
    }
}
