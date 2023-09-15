using VacationSchedule.Domain;

namespace VacationSchedule.Application.Generators.Interfaces
{
    public interface IVacationGenerator
    {
        public List<Vacation> GenerateVacations(List<Employee> employees,
            int countVacation);
    }
}
