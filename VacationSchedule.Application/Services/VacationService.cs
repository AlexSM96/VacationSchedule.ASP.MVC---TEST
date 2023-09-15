using VacationSchedule.Application.Common.Exceptions;
using VacationSchedule.Application.Generators.Interfaces;
using VacationSchedule.Application.Interfaces;
using VacationSchedule.Application.ViewModels;
using VacationSchedule.Domain;
using VacationSchedule.Domain.Enums;

namespace VacationSchedule.Application.Services
{
    public class VacationService : IVacationService
    {
        private readonly IVacationScheduleBuilder _factory;

        public VacationService(IVacationScheduleBuilder factory) =>     
            _factory = factory;
        
        public async Task CreateVacation(VacationViewModel vacation)
        {
            var employee = _factory.VacationsSchedule
                .Select(x => x.Employee)
                .FirstOrDefault(x => x.Id == vacation.EmployeeId);

            if(employee is null) 
            {
                throw new NotFoudException(vacation.EmployeeId, nameof(Employee));
            }

            var newVacation = new Vacation
            {
                Start = vacation.Start,
                End = vacation.End,
                Employee = employee
            };

            _factory.VacationsSchedule.Add(newVacation);
        }

        public async Task<IDictionary<Employee, List<Vacation>>> GetVacationSchedule()
        {
            var vacations = _factory.VacationsSchedule
                .GroupBy(x => x.Employee)
                .ToDictionary(x => x.Key, x => x.ToList());

            return await Task.FromResult(vacations);
        }

        public async Task<IDictionary<Employee, List<Vacation>>> GetCrossingVacationsByEmployeePositionAndAge
            (int employeeId)
        {
            var employeeVacations = GetCurrentEmployeeVacations(employeeId);

            var crossingVacations = GetCrossingVacations(employeeVacations)
                .Where(x => x.Employee.Age < 30
                    && x.Employee.Position == employeeVacations.Key.Position)
                .GroupBy(x => x.Employee)
                .ToDictionary(x => x.Key, x => x.ToList());


            return await Task.FromResult(crossingVacations);
        }

        public async Task<IDictionary<Employee, List<Vacation>>> GetCrossingVacationByFemaleGenderNotMyPosition
            (int employeeId)
        {
            var employeeVacations = GetCurrentEmployeeVacations(employeeId);

            var crossingVacation = GetCrossingVacations(employeeVacations)
                .Where(x => x.Employee.Position != employeeVacations.Key.Position
                    && x.Employee.Gender == Gender.Female
                    && x.Employee.Age > 30
                    && x.Employee.Age < 50)
                .GroupBy(x => x.Employee)
                .ToDictionary(x => x.Key, x => x.ToList());

            return await Task.FromResult(crossingVacation);
        }

        public async Task<IDictionary<Employee, List<Vacation>>> GetCrossingVacationByAllPosition
            (int employeeId)
        {
            var employeeVacations = GetCurrentEmployeeVacations(employeeId);

            var crossingVacations = GetCrossingVacations(employeeVacations)
                .Where(x => x.Employee.Age > 50)
                .GroupBy(x => x.Employee)
                .ToDictionary(x => x.Key, x => x.ToList());

            return await Task.FromResult(crossingVacations);
        }

        public async Task<IDictionary<Employee, List<Vacation>>> GetVacationsWithoutCrossing
            (int employeeId)
        {
            var vacations = _factory.VacationsSchedule
                .ToList();

            var nonOverlappingVacation = GetNonCrossingVacations(vacations)
                .GroupBy(x => x.Employee)
                .ToDictionary(x => x.Key, x => x.ToList());

            return await Task.FromResult(nonOverlappingVacation);
        }

        private KeyValuePair<Employee, List<Vacation>> GetCurrentEmployeeVacations
            (int employeeId)
        {
            var employeeVacations = _factory.VacationsSchedule
                            .GroupBy(x => x.Employee)
                            .ToDictionary(x => x.Key, x => x.ToList())
                            .FirstOrDefault(x => x.Key.Id == employeeId);

            if (employeeVacations.Key == null)
            {
                throw new NotFoudException(employeeId, nameof(Employee));
            }

            return employeeVacations;
        }

        private List<Vacation> GetCrossingVacations(KeyValuePair<Employee, 
            List<Vacation>> currentEmployeeVacation)
        {
            var crossingVacation = new List<Vacation>();
            foreach (var vacation in _factory.VacationsSchedule)
            {
                if (vacation.Employee.Id != currentEmployeeVacation.Key.Id)
                {
                    bool isOverlapping = CheckOverlapping(currentEmployeeVacation.Value, vacation);
                    if (isOverlapping)
                    {
                        crossingVacation.Add(vacation);
                    }
                }
            }

            return crossingVacation.Distinct().ToList();
        }

        private List<Vacation> GetNonCrossingVacations(List<Vacation> vacations)
        {
            var nonCrossingVacations = new List<Vacation>();

            foreach (var vacation in vacations)
            {
                bool isOverlapping = CheckOverlapping(nonCrossingVacations, vacation);
                if (!isOverlapping)
                {
                    nonCrossingVacations.Add(vacation);
                }
            }

            return nonCrossingVacations;
        }

        private static bool CheckOverlapping(List<Vacation> nonOverlappingVacations, 
            Vacation vacation)
        {
            bool isOverlapping = false;

            foreach (var existingVacation in nonOverlappingVacations)
            {
                if (vacation.Start <= existingVacation.End
                    && vacation.End >= existingVacation.Start)
                {
                    isOverlapping = true;
                    break;
                }
            }

            return isOverlapping;
        }
    }
}
