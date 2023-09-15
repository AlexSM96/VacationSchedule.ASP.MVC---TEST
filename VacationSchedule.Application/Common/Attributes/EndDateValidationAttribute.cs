using System.ComponentModel.DataAnnotations;

namespace VacationSchedule.Application.Common.Attributes
{
    public class EndDateValidationAttribute : ValidationAttribute
    {
        private readonly string _startDatePropertyName;
        private readonly int _maxDays;

        public EndDateValidationAttribute(string startDatePropertyName, int maxDays)
            => (_startDatePropertyName, _maxDays) = (startDatePropertyName, maxDays);

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var endDate = (DateTime)value;
            var startDate = (DateTime)validationContext.ObjectType
                ?.GetProperty(_startDatePropertyName)
                ?.GetValue(validationContext.ObjectInstance, null)!;
            var totalDays = (endDate - startDate).TotalDays;

            if (totalDays > _maxDays)
            {
                return new ValidationResult
                    ($"Максимальное количество дней от начала отпуска: {_maxDays}");
            }

            return ValidationResult.Success;
        }
    }
}
