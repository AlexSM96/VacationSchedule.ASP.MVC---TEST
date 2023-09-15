using System.ComponentModel.DataAnnotations;

namespace VacationSchedule.Application.Extensions
{
    public static class GetDislayNameExtension
    {
        public static string GetDisplayName(this Enum value)
        {
            var field = value
                .GetType()
                .GetField(value.ToString());

            var attributes = field
                ?.GetCustomAttributes(typeof(DisplayAttribute), false) 
                as DisplayAttribute[];

            return attributes is not null && attributes.Any()  
                ? attributes[0].Name! : value.ToString();
        }
    }
}
