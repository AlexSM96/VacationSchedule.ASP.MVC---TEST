using VacationSchedule.Domain;

namespace VacationSchedule.Application.Generators.Interfaces
{
    public interface IEmployeeGenerator
    {
        public List<Employee> GenerateEmployees(int count);

    }
}
