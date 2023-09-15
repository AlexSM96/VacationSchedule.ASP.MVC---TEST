using System.ComponentModel.DataAnnotations;

namespace VacationSchedule.Domain.Enums
{
    public enum Gender
    {
        [Display(Name = "Женщина")]
        Female = 0,

        [Display(Name = "Мужчина")]
        Male = 1
    }
}
