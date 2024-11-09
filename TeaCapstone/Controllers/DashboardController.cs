using Microsoft.AspNetCore.Mvc;
using TeaCapstone.Models;
using TeaCapstone.Services;


namespace TeaCapstone.Controllers
{
    public class DashboardController : Controller
    {
        private IDbService<TeaType> _teaTypeService;
        private IDbService<TeaVariety> _teaVarietyService;
        private IDbService<TeaLog> _teaLogService;
        private IUserService _userService;

        

        public DashboardController(IDbService<TeaType> teaTypeService, 
            IDbService<TeaVariety> teaVarietyService, 
            IDbService<TeaLog> teaLogService,
            IUserService userService)
        {
            _teaTypeService = teaTypeService;
            _teaVarietyService = teaVarietyService;
            _teaLogService = teaLogService;
            _userService = userService;
        }
        public async Task<IActionResult> Index()
        {
            var userId = await _userService.GetUserId(User);
            ViewBag.UserId = userId;
            return View();
        }
    }
}
