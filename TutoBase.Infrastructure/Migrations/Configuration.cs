using System.Data.Entity.Migrations;
using TutoBase.Core;

namespace TutoBase.Infrastructure
{

    internal sealed class Configuration : DbMigrationsConfiguration<TutoBaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(TutoBaseContext context)
        {
			

	        context.Leagues.Add(new League { Name = "Bronze", Token = "b"});
			context.Leagues.Add(new League { Name = "Silver", Token = "s" });
			context.Leagues.Add(new League { Name = "Gold", Token = "g" });
			context.Leagues.Add(new League { Name = "Platinum", Token = "p" }); 
			context.Leagues.Add(new League { Name = "Diamond", Token = "d" });
			context.Leagues.Add(new League { Name = "Master", Token = "m" });

	        context.Races.Add(new Race { Name = "Terran", Token = "t" });
			context.Races.Add(new Race { Name = "Protoss", Token = "p" });
			context.Races.Add(new Race { Name = "Zerg", Token = "z" });

	        context.Casters.Add(new Caster { Name = "Makoz", Token = "m"});
			context.Casters.Add(new Caster { Name = "Anoss", Token = "a" });
			context.Casters.Add(new Caster { Name = "Tod", Token = "t" });
			context.Casters.Add(new Caster { Name = "StraightEdge", Token = "s" });
			context.Casters.Add(new Caster { Name = "NeverDie", Token = "n" });

	        context.TutoTypes.Add(new TutoType {Name = "OnMonteEnMaster", Token = "o"});
			context.TutoTypes.Add(new TutoType { Name = "BuildOrder", Token = "b" });
			context.TutoTypes.Add(new TutoType { Name = "Concepts", Token = "c" });

	        context.VideoProviders.Add(new VideoProvider {Name = "Youtube", Token = "y"});
			context.VideoProviders.Add(new VideoProvider { Name = "Dailymotion", Token = "d" });

	        context.SaveChanges();

	        //context.
        }
    }
}
