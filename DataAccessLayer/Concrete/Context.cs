using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=.\SQLEXPRESS;database=DbNewOopCoreAgniculture1;Integrated security=true;");
        }
        
        public DbSet<Team> teams { get; set; }
        public DbSet<Address> addresses { get; set; }
        public DbSet<Announcement> announcements { get; set; }
        public DbSet<Contact> contacts { get; set; }
        public DbSet<Service> services { get; set; }
        public DbSet<Image> images { get; set; }
        public DbSet<AboutUs> aboutUs { get; set; }
        public DbSet<SocialMedia> socialMedias { get; set; }
        public DbSet<Category> categories { get; set; } 
        public DbSet<Product> products { get; set; }
        public DbSet<Gender> genders { get; set; }
       
    }
}
