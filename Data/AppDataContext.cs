using HMSApi.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HMSApi.Data
{
    public class AppDataContext : IdentityDbContext<AppUser, IdentityRole, string>
    {
        public AppDataContext(DbContextOptions options) : base(options)
        {

        }
    }
}
