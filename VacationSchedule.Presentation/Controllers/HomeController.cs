using Microsoft.AspNetCore.Mvc;
using VacationSchedule.Application.Interfaces;
using VacationSchedule.Application.ViewModels;

namespace VacationSchedule.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly IVacationService _vacationService;

        public HomeController(IVacationService vacationService) =>
            _vacationService = vacationService;


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var vacation = await _vacationService
                .GetVacationSchedule();

            return View(vacation);
        }

        [HttpGet]
        public IActionResult GetCrossingVacation() => PartialView();

        [HttpGet]
        public async Task<IActionResult> GetCrossingVacationsByEmployeePositionAndAge
            (int employeeId)
        {
            var vacations = await _vacationService
                .GetCrossingVacationsByEmployeePositionAndAge(employeeId);

            return PartialView("GetCrossingVacation", vacations);
        }

        [HttpGet]
        public async Task<IActionResult> GetCrossingVacationsByFemaleGenderNotMyPosition
            (int employeeId)
        {
            var vacations = await _vacationService
                .GetCrossingVacationByFemaleGenderNotMyPosition(employeeId);

            return PartialView("GetCrossingVacation", vacations);
        }

        [HttpGet]
        public async Task<IActionResult> GetCrossingVacationsByAllPosition(int employeeId)
        {
            var vacations = await _vacationService
                .GetCrossingVacationByAllPosition(employeeId);

            return PartialView("GetCrossingVacation", vacations);
        }

        [HttpGet]
        public async Task<IActionResult> GetVacationsWithoutCrossing(int employeeId)
        {
            var vacation = await _vacationService
                .GetVacationsWithoutCrossing(employeeId);

            return PartialView("GetCrossingVacation", vacation);
        }

        [HttpGet]
        public IActionResult AddVacation(int employeeId) =>
            PartialView(new VacationViewModel { EmployeeId = employeeId });

        [HttpPost]
        public async Task<IActionResult> AddVacation(VacationViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _vacationService.CreateVacation(model);
                return PartialView("AddVacation");
            }

            return PartialView("AddVacation", model);
        }
    }
}