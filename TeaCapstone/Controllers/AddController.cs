using Microsoft.AspNetCore.Mvc;
using TeaCapstone.Models;
using TeaCapstone.Services;

namespace TeaCapstone.Controllers
{
    public class AddController : Controller
    {
        private IDbService<TeaType> _teaTypeService;
        private ITeaVarietyService _teaVarietyService;
        private ITeaLogService _teaLogService;
        private IUserService _userService;

        public AddController(IDbService<TeaType> teaTypeService,
            ITeaVarietyService teaVarietyService,
            ITeaLogService teaLogService,
            IUserService userService)
        {
            _teaTypeService = teaTypeService;
            _teaVarietyService = teaVarietyService;
            _teaLogService = teaLogService;
            _userService = userService;
        }
        public  IActionResult Index()
        {
            List<TeaType> allTeaTypes = _teaTypeService.GetAllEntities();
            ViewData["TeaTypes"] = allTeaTypes;
            return View();
        }

        public List<TeaVariety> GetTeaVarieties(int teaTypeId)
        {
            return _teaVarietyService.GetVarietiesByType(teaTypeId);
        }
    }
}
