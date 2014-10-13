using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutoBase.Core;

namespace TutoBase.Infrastructure
{
	public class TutoRepository : ITutoRepository
	{
		TutoBaseContext db = new TutoBaseContext();

		public IEnumerable<Tuto> GetTutos()
		{
			return db.Tutos
				.Include("Leagues")
				.Include("Againsts")
				.Include("Races")
				.Include("TutoType")
				.Include("Caster");
		}

		public Tuto GetTuto(int id)
		{
			return db.Tutos.FirstOrDefault(t => t.Id == id);
		}

		public void Add(Tuto t)
		{
			db.Tutos.Add(t);
			db.SaveChanges();
		}

		public void Edit(Tuto t)
		{

			db.Entry(t).State = EntityState.Modified;
			db.SaveChanges();

		}

		public void Remove(int id)
		{
			Tuto movie = db.Tutos.Find(id);
			db.Tutos.Remove(movie);
			db.SaveChanges();

		}

		public void Dispose()
		{
			db.Dispose();
		}
	}
}
