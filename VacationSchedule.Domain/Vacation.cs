namespace VacationSchedule.Domain
{
    public class Vacation
    {
        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public Employee Employee { get; set; }
    }
}
