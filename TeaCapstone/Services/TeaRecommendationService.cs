using TeaCapstone.Models;

namespace TeaCapstone.Services
{
    public class TeaRecommendationService : ITeaRecommendationService
    {
        private ITeaLogService _teaLogService;
        private IDbService<TeaVariety> _teaVarietyService;

        public TeaRecommendationService(ITeaLogService teaLogService, IDbService<TeaVariety> teaVarietyService) 
        {
            _teaLogService = teaLogService;
            _teaVarietyService = teaVarietyService;
        
        }
        public string RecommendTea(string userId, int caffeineToday)
        {
            List<TeaVariety> allTeas = _teaVarietyService.GetAllEntities();
            //checks caffeine intake, if it's over 300 or after 2pm, recommends only herbal teas
            if (caffeineToday > 300 || DateTime.Now.Hour >= 14)
            {
                List<TeaVariety> herbalTeas = allTeas.Where(t => t.CaffeineContent == 0).ToList();
                var rand = new Random();
                int randomIndex = rand.Next(0, herbalTeas.Count -1);
                return herbalTeas[randomIndex].Name;
            }
            else
            {
                var rand = new Random();
                int randomIndex = rand.Next(0, allTeas.Count - 1);
                return allTeas[randomIndex].Name;
            }
        }
    }
}
