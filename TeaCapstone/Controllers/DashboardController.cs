using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeaCapstone.Models;
using TeaCapstone.Services;


namespace TeaCapstone.Controllers
{
    [Authorize]
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

        [HttpGet]
        [Route("Dashboard/Edit/{logId}")]
        public async Task<IActionResult> Edit(int logId)
        {
            string currentUserId = await _userService.GetUserId(User);
            TeaLog currentLog = _teaLogService.GetById(logId);
            if (currentUserId != currentLog.UserId)
            {
                return RedirectToAction("Index");
            }

            List<TeaType> allTeaTypes = _teaTypeService.GetAllEntities();
            ViewData["TeaTypes"] = allTeaTypes;

            ViewBag.LogId = logId;
            int currentVarietyId = currentLog.TeaVarietyId;
            DateTime date = currentLog.Time;
            TeaVariety currentVariety = _teaVarietyService.GetById(currentVarietyId);
            int currentTypeId = currentVariety.TeaTypeId;
            TeaType currentType = _teaTypeService.GetById(currentTypeId);


            ViewBag.CurrentVariety = currentVariety.Id;
            ViewBag.CurrentVarietyName = currentVariety.Name;
            ViewBag.CurrentType = currentType.Id;
            ViewBag.Date = date.ToString("yyyy-MM-dd");


            return View();
        }

        public IActionResult DeleteLog(int logId)
        {
            try
            {
                TeaLog currentLog = _teaLogService.GetById(logId);
                _teaLogService.DeleteTeaLog(currentLog);
                
                return RedirectToAction("Index");

            }
            catch
            {
                TempData["DeleteFail"] = "There was an error deleting the log";
                return RedirectToAction("Edit", new {id = logId});
            }
        }

        public List<TeaVariety> GetTeaVarieties(int teaTypeId)
        {
            return _teaVarietyService.GetVarietiesByType(teaTypeId);
        }

        [HttpPost]
        public async Task<IActionResult> AddTeaLog(AddTeaLogViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = await _userService.GetUserId(User);
                var currentUser = await _userService.GetCurrentUser(User);
                TeaVariety currentVariety = _teaVarietyService.GetById(model.VarietyId);
                var tealog = new TeaLog
                {
                    UserId = userId,
                    TeaVarietyId = model.VarietyId,
                    Time = model.Date,
                    TeaVariety = currentVariety,
                    IdentityUser = currentUser
                };
                _teaLogService.AddTeaLog(tealog);
                return RedirectToAction("Index");

            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateLog(AddTeaLogViewModel model, int logId)
        {
            if (ModelState.IsValid)
            {
                var userId = await _userService.GetUserId(User);
                var currentUser = await _userService.GetCurrentUser(User);
                TeaVariety currentVariety = _teaVarietyService.GetById(model.VarietyId);
                var tealog = new TeaLog
                {
                    UserId = userId,
                    TeaVarietyId = model.VarietyId,
                    Time = model.Date,
                    TeaVariety = currentVariety,
                    IdentityUser = currentUser
                };
                _teaLogService.UpdateTeaLog(logId, tealog);
                return RedirectToAction("Search");
            }
            return View(model);
        }


        public IActionResult GetLogsByDate(DateTime date)
        {

            List<TeaLog> logs = _teaLogService.GetCupsByDate(date);
            List<SearchModel> searchModels = new List<SearchModel>();
            foreach (var log in logs)
            {
                TeaVariety variety = _teaVarietyService.GetById(log.TeaVarietyId);
                SearchModel searchModel = new SearchModel
                {
                    Date = date,
                    LogId = log.Id,
                    Variety = variety.Name
                };
                searchModels.Add(searchModel);
            }
            return PartialView("_LogsTablePartial", searchModels);
        }

    }
}
