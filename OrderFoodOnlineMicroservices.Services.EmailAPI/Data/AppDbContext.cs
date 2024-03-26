using Microsoft.EntityFrameworkCore;
using OrderFoodOnlineMicroservices.Services.EmailAPI.Models;

namespace OrderFoodOnlineMicroservices.Services.EmailAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<EmailLogger> EmailLoggers { get; set; }

       
    }
}
