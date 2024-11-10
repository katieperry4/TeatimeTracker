using Microsoft.AspNetCore.Mvc;
using TeaCapstone.Models;
using TeaCapstone.Services;


namespace TeaCapstone.Controllers
{
    public class DashboardController : Controller
    {
        private IDbService<TeaType> _teaTypeService;
        private ITeaVarietyService _teaVarietyService;
        private ITeaLogService _teaLogService;
        private IUserService _userService;
        private ITeaRecommendationService _teaRecommendationService;

        public DashboardController(IDbService<TeaType> teaTypeService,
            ITeaVarietyService teaVarietyService,
            ITeaLogService teaLogService,
            IUserService userService,
            ITeaRecommendationService teaRecommendationService)
        {
            _teaTypeService = teaTypeService;
            _teaVarietyService = teaVarietyService;
            _teaLogService = teaLogService;
            _userService = userService;
            _teaRecommendationService = teaRecommendationService;
        }
        public async Task<IActionResult> Index()
        {
            var userId = await _userService.GetUserId(User);
            int totalCups = _teaLogService.GetTotalCups(userId);
            int cupsToday = _teaLogService.GetCupsToday(userId);
            int caffeineToday = _teaLogService.CaffeineToday(userId);
            string recommendedTea = _teaRecommendationService.RecommendTea(userId, caffeineToday);
            ViewBag.UserId = userId;
            ViewBag.TotalCups = totalCups;
            ViewBag.CupsToday = cupsToday;
            ViewBag.CaffeineToday = caffeineToday;
            ViewBag.RecommendedTea = recommendedTea;

            return View();
        }

        public IActionResult Add()
        {
            List<TeaType> allTeaTypes = _teaTypeService.GetAllEntities();
            ViewData["TeaTypes"] = allTeaTypes;
            return View();
        }

        public IActionResult Search()
        {
            return View();
        }

        public List<TeaVariety> GetTeaVarieties(int teaTypeId)
        {
            return _teaVarietyService.GetVarietiesByType(teaTypeId);
        }
    }
}
