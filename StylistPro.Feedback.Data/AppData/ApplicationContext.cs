using Microsoft.EntityFrameworkCore;
using StylistPro.Feedback.Domain.Entities;

namespace StylistPro.Feedback.Data.AppData
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<FeedbackEntity> Feedback {  get; set; }
    }
}
