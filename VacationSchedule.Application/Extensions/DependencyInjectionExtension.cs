using Microsoft.Extensions.DependencyInjection;
using VacationSchedule.Application.Generators.Interfaces;
using VacationSchedule.Application.Generators;
using VacationSchedule.Application.Interfaces;
using VacationSchedule.Application.Services;

namespace VacationSchedule.Application.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            return services
                .AddSingleton<IEmployeeGenerator, EmployeeGenerator>()
                .AddSingleton<IVacationGenerator, VacationGenerator>()
                .AddSingleton<IVacationScheduleBuilder, VacationScheduleBuilder>()
                .AddScoped<IVacationService, VacationService>();
        }
    }
}
