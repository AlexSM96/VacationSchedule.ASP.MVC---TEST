using System.Text;
using VacationSchedule.Application.Generators.Interfaces;
using VacationSchedule.Domain;
using VacationSchedule.Domain.Enums;

namespace VacationSchedule.Application.Generators
{
    public class EmployeeGenerator : IEmployeeGenerator
    {
        private static Random _random = new Random();

        private static List<string> _firstName = new List<string>
        {
            "Алексей", "Дмитрий", "Сергей", "Александр", 
            "Ольга", "Мария", "Елена", "Анна",
        };

        private static List<string> _lastName = new List<string>
        {
            "Сидоров", "Смирнов", "Кузнецов", "Васильев",
            "Попова", "Лебедева", "Козлова", "Новикова"
        };

        private static List<string> _patronymic = new List<string>
        {
            "Алексеевич", "Михайлович", "Владимирович", "Андреевич",
            "Олеговна", "Дмитриевна", "Сергеевна", "Александровна"
        };
        
        private string GenerateName() => new StringBuilder()
            .AppendLine(_lastName[_random.Next(_firstName.Count)])
            .AppendLine(_firstName[_random.Next(_firstName.Count)])
            .AppendLine(_patronymic[_random.Next(_firstName.Count)])
            .ToString();

        private byte GenerateAge() => (byte)new Random().Next(18, 65);

        private Gender GenerateGender() => (Gender)_random.Next(0, 2);

        private Position GeneratePosition() => (Position)_random.Next(0, 10);

        public List<Employee> GenerateEmployees(int count)
        {
            return Enumerable.Range(1, count).Select(index => new Employee
            {
                Id = index,
                Name = GenerateName(),
                Age = GenerateAge(),
                Gender = GenerateGender(),
                Position = GeneratePosition(),
            })
            .ToList();
        }
    }
}
