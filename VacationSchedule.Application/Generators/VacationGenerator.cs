using System.Data;
using VacationSchedule.Application.Generators.Interfaces;
using VacationSchedule.Domain;

namespace VacationSchedule.Application.Generators
{
    public class VacationGenerator : IVacationGenerator
    {
        private readonly Random _random = new();

        public List<Vacation> GenerateVacations(List<Employee> employees, int countVacation)
        {
            var result = new List<Vacation>();
            foreach (var employee in employees)
            {
                result.AddRange(GenerateVacations(countVacation, employee));
            }

            return result;
        }

        private List<Vacation> GenerateVacations(int countVacation, Employee employee)
        {
            var startDate = GenerateStartDate();
            var minDate = startDate;
            return Enumerable.Range(1, countVacation).Select(i => new Vacation
            {
                Start = GetStartVacationDate(i, ref startDate),
                End = GetEndVacationDate(i, startDate),
                Employee = employee
            })
            .ToList();
        }

        private DateTime GetStartVacationDate(int cauntVacation, ref DateTime startDate)
        {
            return cauntVacation == 1 ? startDate 
                : startDate = GetEndVacationDate(cauntVacation, startDate).AddDays(14);
        }

        private DateTime GenerateStartDate() => 
            new DateTime(DateTime.Now.Year, GenerateMonth(), GenerateDay());

        private int GenerateMonth() => _random.Next(1, 13);

        private int GenerateDay() => _random.Next(1, 29);

        private DateTime GetEndVacationDate(int index, DateTime start)
        {
            return index switch
            {
                1 => start.AddDays(14),
                _ => start.AddDays(7)
            };
        }
    }
}
