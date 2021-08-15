using CarZone.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CarZone.Data
{
	public class AppLogContext : DbContext
	{
		public DbSet<Log> Logs { get; set; }

		public AppLogContext(DbContextOptions<AppLogContext> options)
			: base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			foreach (var entity in modelBuilder.Model.GetEntityTypes())
			{
				entity.SetTableName(entity.ClrType.Name.ToLower()); 

				foreach (var property in entity.GetProperties())
				{
					property.SetColumnName(property.Name.ToLower());
				}
			}

			modelBuilder.ApplyConfiguration(new LogConfiguration());
			base.OnModelCreating(modelBuilder);
		}
	}
}
