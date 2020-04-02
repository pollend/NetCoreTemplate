
using Microsoft.AspNetCore.Session;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace app.EntityManager
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        private readonly ISessionStore _session;
        private readonly IConfiguration _configuration;
        public DbContext(DbContextOptions<DbContext> options, ISessionStore session, IConfiguration configuration) : base(options)
        {
            _session = session;
            _configuration = configuration;
        }
    }
}
