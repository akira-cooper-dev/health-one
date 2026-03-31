using Infra.Data.Models;
using Infra.Data.Models.User;
using Infra.Data.Models.Workout;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data
{
    public class PostgresDbContext : DbContext
    {
        public PostgresDbContext(DbContextOptions<PostgresDbContext> options) : base(options)
        {

        }

        public DbSet<User> User { get; set; }
        public DbSet<UserHealthProfile> UserHealthProfile { get; set; }
        public DbSet<UserExercise> UserExercise { get; set; }
        public DbSet<Exercise> Exercise { get; set; }
        public DbSet<Workout> Workout { get; set; }
        public DbSet<WorkoutSchedule> WorkoutSchedule { get; set; }
    }
}
