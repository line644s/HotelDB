using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HotelDB.DBUtil;
using Modellib.Model;

namespace HotelDB.Controllers
{
    public class FacilitetsController : ApiController
    {
        MangeFaciliteter manger = new MangeFaciliteter();
        // GET: api/Facilitets
        public IEnumerable<Facilitet> Get()
        {
            return manger.Get();
        }

        // GET: api/Facilitets/5
        public Facilitet Get(int id)
        {
            return manger.Get(id);
        }

        // POST: api/Facilitets
        public bool Post([FromBody]Facilitet value)
        {
            return manger.Post(value);
        }

        // PUT: api/Facilitets/5
        public bool Put(int id, [FromBody]Facilitet value)
        {
            return manger.Put(id, value);
        }

        // DELETE: api/Facilitets/5
        public bool Delete(int id)
        {
            return manger.Delete(id);
        }
    }
}
