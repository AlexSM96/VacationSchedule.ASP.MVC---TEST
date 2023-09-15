namespace VacationSchedule.Application.Common.Exceptions
{
    public class NotFoudException : Exception
    {
        public NotFoudException(object key, string name)
            : base($"Entity \"{name}\" ({key}) not found") { }
    }
}
