using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pusher.Data.Configs;
using Pusher.Data.DomainModels;

namespace Pusher.Data
{
    public class PusherDb : IdentityDbContext<IdentityUser>
    {
       
        public PusherDb(DbContextOptions<PusherDb> options)
            : base(options)
        {
              
        }
        public DbSet<UserDetail> UserDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new UserDetailConfig());


        }
    }
}
