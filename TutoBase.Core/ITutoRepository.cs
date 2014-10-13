using System.Collections.Generic;
using TutoBase.Core;

namespace TutoBase.Core
{
	public interface ITutoRepository
	{
		IEnumerable<Tuto> GetTutos();
		Tuto GetTuto(int id);
		void Add(Tuto t);
		void Edit(Tuto t);
		void Remove(int id);
		void Dispose();

	}
}