
using Microsoft.AspNetCore.Session;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace app.EntityManager
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        private IConfiguration _configuration;
        public DbContext(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(this._configuration.GetConnectionString("db"));

            base.OnConfiguring(optionsBuilder);
        }
    }
}
