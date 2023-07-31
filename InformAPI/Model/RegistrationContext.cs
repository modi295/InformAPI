using Microsoft.EntityFrameworkCore;

namespace InformAPI.Model
{
    public class RegistrationContext:DbContext

    {
        public RegistrationContext(DbContextOptions<RegistrationContext> options) : base(options)
        {

        }
        public  DbSet<Registration> Registrations { get; set; }
        public DbSet<Login> Logins { get; set; }
    }
}
