using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AutoStop.Models;
using AtilerCourseWork.Configuration;
using Microsoft.AspNetCore.Identity;

namespace AutoStop.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<Travels> Travels { get; set; }
        public DbSet<BlackList> BlackList { get; set; }
        public DbSet<CarCategories> CarCategories { get; set; }
        public DbSet<Cars> Cars { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<CategoriesCar> Categories { get; set; }
        public DbSet<PointArrive> PointArrives { get; set; }
        public DbSet<PointSend> PointSends { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new PositionConfiguration());
            modelBuilder.ApplyConfiguration(new WorkerConfiguration());
            modelBuilder.ApplyConfiguration(new WorkerPositionConfiguration());

            modelBuilder.Entity<IdentityUser>().ToTable("auth_data");
            modelBuilder.Entity<IdentityRole>().ToTable("positions");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("acc_position");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("acc_token");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("acc_claim");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("acc_user_claim");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("acc_login");
            modelBuilder.Entity<Travels>().ToTable("travels");
            modelBuilder.Entity<Cars>().ToTable("cars");
            modelBuilder.Entity<Accounts>().ToTable("accounts");
            modelBuilder.Entity<BusyPlaces>().ToTable("busy_places");
            modelBuilder.Entity<CarCategories>().ToTable("car_categories");
            modelBuilder.Entity<CategoriesCar>().ToTable("categories");
            modelBuilder.Entity<Comments>().ToTable("comments");
            modelBuilder.Entity<PointArrive>().ToTable("point_arrive");
            modelBuilder.Entity<PointSend>().ToTable("point_send");

            modelBuilder.Entity<BusyPlaces>()
                .HasOne<Accounts>(a => a.Accounts)
                .WithMany(p => p.BusyPlaces)
                .HasForeignKey(k => k.AccountId);

            modelBuilder.Entity<BusyPlaces>()
                .HasOne<Travels>(a => a.Traverl)
                .WithMany(p => p.BusyPlaces)
                .HasForeignKey(k => k.TravelId);

            modelBuilder.Entity<Travels>()
                .HasOne<Accounts>(a => a.Creater)
                .WithMany(a => a.Travels)
                .HasForeignKey(k => k.CreaterId);

            modelBuilder.Entity<Travels>()
                .HasOne<PointSend>(s => s.PointSend)
                .WithMany(a => a.Travels)
                .HasForeignKey(s => s.PointSendId);

            modelBuilder.Entity<Travels>()
                .HasOne<PointArrive>(s => s.PointArrive)
                .WithMany(a => a.Travels)
                .HasForeignKey(s => s.PointArriveId);

            modelBuilder.Entity<BlackList>()
                .HasOne<Accounts>(a => a.Accounts)
                .WithOne(b => b.BlackList)
                .HasForeignKey<Accounts>(k => k.BlackListId);

            modelBuilder.Entity<Cars>()
                .HasOne<Accounts>(d => d.Drivers)
                .WithMany(c => c.Cars)
                .HasForeignKey(k => k.DriverId);


            modelBuilder.Entity<CarCategories>()
                .HasOne<Cars>(c => c.Car)
                .WithMany(c => c.CarCategories)
                .HasForeignKey(k => k.CarId);

            modelBuilder.Entity<CarCategories>()
                .HasOne<CategoriesCar>(c => c.Category)
                .WithMany(c => c.CarCategories)
                .HasForeignKey(k => k.CategoriesId);

            modelBuilder.Entity<Comments>()
                .HasOne<Travels>(a => a.Travels)
                .WithMany(c => c.Comments)
                .HasForeignKey(k => k.TravelsId);

            modelBuilder.Entity<Comments>()
                .HasOne<Accounts>(c => c.Accounts)
                .WithMany(c => c.Comments)
                .HasForeignKey(k => k.AccountsId);


        }

        public DbSet<AutoStop.Models.BusyPlaces> BusyPlaces { get; set; }
    }
}