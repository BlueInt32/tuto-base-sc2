	using System;
using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity;
	using System.Linq;
using System.Text;
using System.Threading.Tasks;
	using TutoBase.Core;

namespace TutoBase.Infrastructure
{
    public class TutoBaseContext : DbContext
    {
	    public TutoBaseContext()
	    {
			Configuration.ProxyCreationEnabled = false;
			Configuration.LazyLoadingEnabled = false;
	    }

	    public DbSet<Tuto> Tutos { get; set; }
	    public DbSet<Race> Races { get; set; }
	    public DbSet<Caster> Casters { get; set; }
	    public DbSet<League> Leagues { get; set; }
	    public DbSet<TutoType> TutoTypes { get; set; }
	    public DbSet<VideoProvider> VideoProviders { get; set; }

	    protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Tuto>().HasMany(t => t.Againsts).WithMany(r => r.TutosAsPlayerRace)
				.Map(t => t.ToTable("TutosAgainsts"));
			modelBuilder.Entity<Tuto>().HasMany(t => t.Races).WithMany(r => r.TutosAsAgainstRace)
				.Map(t => t.ToTable("TutosRaces"));
			modelBuilder.Entity<Tuto>().HasMany(t => t.Leagues).WithMany(l => l.Tutos);

			modelBuilder.Entity<Caster>().HasMany(c => c.Tutos);
			base.OnModelCreating(modelBuilder);
		}
    }
}
