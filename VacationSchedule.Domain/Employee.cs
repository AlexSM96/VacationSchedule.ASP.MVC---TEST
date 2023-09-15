using VacationSchedule.Domain.Enums;

namespace VacationSchedule.Domain
{
    public class Employee
    { 
        public int Id { get; set; }

        public string Name { get; set; }

        public Gender Gender { get; set; }

        public Position Position { get; set; }

        public byte Age { get; set; }
    }
}
