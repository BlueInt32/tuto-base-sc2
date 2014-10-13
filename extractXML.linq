<Query Kind="Program">
  <Connection>
    <ID>5e232768-a21d-4fac-8da8-2bad170b650c</ID>
    <Persist>true</Persist>
    <Driver>EntityFrameworkDbContext</Driver>
    <CustomAssemblyPath>D:\Prog\Git\Sc2TutsBase\TutoBase.Infrastructure\bin\Release\TutoBase.Infrastructure.dll</CustomAssemblyPath>
    <CustomTypeName>TutoBase.Infrastructure.TutoBaseContext</CustomTypeName>
    <AppConfigPath>D:\Prog\Git\Sc2TutsBase\TutoBase.Api\Web.config</AppConfigPath>
  </Connection>
  <Reference Relative="TutoBase.Core\bin\Release\TutoBase.Core.dll">D:\Prog\Git\Sc2TutsBase\TutoBase.Core\bin\Release\TutoBase.Core.dll</Reference>
  <Namespace>TutoBase.Core</Namespace>
  <Namespace>System.Xml.Serialization</Namespace>
</Query>

void Main()
{
	string path = @"D:\Prog\Git\Sc2TutsBase\Sc2TutsBase\tutslist.xml";
	var list = TutsListSerializer.LoadTutsFromFile(path);
	
	
	foreach (var tuto in list)
	{
		tuto.Dump();
		AttachRelationshipsToTuto(tuto);
		Tutos.Add(tuto);
	}
	SaveChanges();
}

public void AttachRelationshipsToTuto(Tuto tuto)
{
	List<Race> racesToAddManually = new List<Race>(tuto.Races);
	tuto.Races.Clear();
	racesToAddManually.ForEach(r => tuto.Races.Add(GetRaceByName(r)));
	
	List<Race> againstsToAddManually = new List<Race>(tuto.Againsts);
	tuto.Againsts.Clear();
	againstsToAddManually.ForEach(r => tuto.Againsts.Add(GetRaceByName(r)));
	
	List<League> leaguesToAddManually = new List<League>(tuto.Leagues);
	tuto.Leagues.Clear();
	leaguesToAddManually.ForEach(l => tuto.Leagues.Add(GetLeagueByName(l)));
	
	Caster c = new Caster { Name = tuto.Caster.Name};
	tuto.Caster = null;
	tuto.Caster = GetCasterByName(c);

	TutoType t = new TutoType { Name = tuto.TutoType.Name};
	tuto.TutoType = null;
	tuto.TutoType = GetTutoTypeByName(t);
	
	VideoProvider v = new VideoProvider { Name = tuto.VideoProvider.Name};
	tuto.VideoProvider = null;
	tuto.VideoProvider = GetVideoProviderByName(v);
	
}
public Race GetRaceByName(Race inputRace)
{
	var race = Races.FirstOrDefault(r => r.Name == inputRace.Name);
	return race;
}

public League GetLeagueByName(League inputLeague)
{
	var league = Leagues.FirstOrDefault(r => r.Name == inputLeague.Name);
	return league;
}

public Caster GetCasterByName(Caster inputCaster)
{
	var caster = Casters.FirstOrDefault(r => r.Name == inputCaster.Name);
	return caster;
}

public TutoType GetTutoTypeByName(TutoType input)
{
	var obj = TutoTypes.FirstOrDefault(r => r.Name == input.Name);
	return obj;
}

public VideoProvider GetVideoProviderByName(VideoProvider input)
{
	var obj = VideoProviders.FirstOrDefault(r => r.Name == input.Name);
	return obj;
}

public Race GetRaceByName(DbSet<Race> dbSet, string raceName)
{
	return dbSet.FirstOrDefault(r => r.Name == raceName);
}

public class TutsListSerializer
{
	public static List<Tuto> LoadTutsFromFile(string path)
	{
		List<Tuto> resultList = new List<Tuto>();
		XmlSerializer xs = new XmlSerializer(typeof(List<Tuto>));
		
		XmlReader xd = XmlReader.Create(path);
			resultList = xs.Deserialize(xd) as List<Tuto>;
			xd.Close();
		return resultList;
	}
//	
//	public static void AddOrUpdateInstructor(Tuto tuto, string raceName)
//   {
//       Race race = Races.SingleOrDefault(i => i.Name == raceName);
//       if (inst == null)
//           crs.Instructors.Add(context.Instructors.Single(i => i.LastName == instructorName));
//   }

}




public interface IListSerialisable
{
}