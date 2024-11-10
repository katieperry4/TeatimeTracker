namespace TeaCapstone.Services
{
    public interface ITeaRecommendationService
    {
        public string RecommendTea(string userId, int caffeineToday);
    }
}
