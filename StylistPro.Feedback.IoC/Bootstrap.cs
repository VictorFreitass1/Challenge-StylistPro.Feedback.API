using StylistPro.Feedback.Application.Services;
using StylistPro.Feedback.Data.AppData;
using StylistPro.Feedback.Data.Repositories;
using StylistPro.Feedback.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace StylistPro.Feedback.IoC
{
    public class Bootstrap
    {
        public static void Start(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(x => {
                x.UseOracle(configuration["ConnectionStrings:Oracle"]);
            });

            services.AddTransient<IFeedbackRepository, FeedbackRepository>();
            services.AddTransient<IFeedbackApplicationService, FeedbackApplicationService>();

        }
    }
}
