using System.ComponentModel.DataAnnotations;

namespace VacationSchedule.Domain.Enums
{
    public enum Position
    {
        [Display(Name = "Главный исполнительный директор")]
        ChiefExecutiveOfficer = 0,

        [Display(Name = "Главный технический директор")]
        ChiefTechnicalOfficer = 1,

        [Display(Name = "Директор по маркетингу")]
        MarketingDirector = 2,

        [Display(Name = "HR директор")]
        HRDirector = 3,

        [Display(Name = "Менеджер проекта")]
        ProjectManager = 4,

        [Display(Name = "Бухгалтер")]
        Accountant = 5,

        [Display(Name = "Администратор")]
        Receptionist = 6,

        [Display(Name = "Супервайзер")]
        Supervisor = 7,

        [Display(Name = "Менеджер по продажам")]
        SalesManager = 8,

        [Display(Name = "Уборщик")]    
        Cleaner = 9,
    }
}
