using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TutoBase.Core;
using TutoBase.Infrastructure;

namespace TutoBase.Api.Controllers
{
    public class TutoController : ApiController
    {
	    public TutoController()
	    {
		    
	    }
	    private ITutoRepository _db;
	    public TutoController(ITutoRepository db)
	    {
			_db = db;
	    }

        public IEnumerable<Tuto> Get()
        {
			return _db.GetTutos();
        }

		public Tuto Get(int id)
        {
	        return _db.GetTuto(id);
        }

		public void Post([FromBody]Tuto value)
		{
			_db.Add(value);
		}

		public void Put(int id, [FromBody]Tuto value)
        {
	        _db.Edit(value);
        }

        public void Delete(int id)
        {
	        _db.Remove(id);
        }
    }
}
