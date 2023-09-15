using VacationSchedule.Application.Common.Attributes;

namespace VacationSchedule.Application.ViewModels
{
    public class VacationViewModel
    {
        public DateTime Start { get; set; }

        [EndDateValidation("Start", 14)]
        public DateTime End { get; set; }

        public int EmployeeId { get; set; }
    }
}
