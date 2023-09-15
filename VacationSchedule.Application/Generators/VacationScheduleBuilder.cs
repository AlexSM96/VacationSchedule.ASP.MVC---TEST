using VacationSchedule.Application.Generators.Interfaces;
using VacationSchedule.Domain;

namespace VacationSchedule.Application.Generators
{
    public class VacationScheduleBuilder : IVacationScheduleBuilder
    {
        private readonly IVacationGenerator _vacation;
        private readonly IEmployeeGenerator _employee;

        public VacationScheduleBuilder(IVacationGenerator vacationGenerator,
            IEmployeeGenerator employeeGenerator)
        {
            _employee = employeeGenerator;
            _vacation = vacationGenerator;
            VacationsSchedule = CreateVacationSchedule();
        }

        public List<Vacation> VacationsSchedule { get; set; }

        private List<Vacation> CreateVacationSchedule()
        {
            var employees = _employee
                .GenerateEmployees(100);

            var vacations = _vacation
                .GenerateVacations(employees, 3);

            return vacations;
        }
    }
}
