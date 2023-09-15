using VacationSchedule.Application.ViewModels;
using VacationSchedule.Domain;

namespace VacationSchedule.Application.Interfaces
{
    public interface IVacationService
    {
        public Task<IDictionary<Employee, List<Vacation>>> GetVacationSchedule();

        public Task<IDictionary<Employee, List<Vacation>>> 
            GetCrossingVacationsByEmployeePositionAndAge(int employeeId);

        public Task<IDictionary<Employee, List<Vacation>>>
            GetCrossingVacationByFemaleGenderNotMyPosition(int employeeId);

        public Task<IDictionary<Employee, List<Vacation>>>
            GetCrossingVacationByAllPosition(int employeeId);

        public Task<IDictionary<Employee, List<Vacation>>>
            GetVacationsWithoutCrossing(int employeeId);

        public Task CreateVacation(VacationViewModel vacation);
    }
}
