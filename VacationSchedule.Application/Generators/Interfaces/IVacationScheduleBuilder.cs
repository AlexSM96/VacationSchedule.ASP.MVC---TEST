using VacationSchedule.Domain;

namespace VacationSchedule.Application.Generators.Interfaces
{
    public interface IVacationScheduleBuilder
    {
        public List<Vacation> VacationsSchedule { get; }
    }
}
