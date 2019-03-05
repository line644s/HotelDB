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
    public class GuestsController : ApiController
    {
        private MangeGuest manger = new MangeGuest();
        // GET: api/Guest
        public IEnumerable<Guest> Get()
        {
            return manger.Get();
        }

        // GET: api/Guest/5
        public Guest Get(int id)
        {
            return manger.Get(id);
        }

        // POST: api/Guest
        public bool Post([FromBody]Guest value)
        {
            return manger.Post(value);
        }

        // PUT: api/Guest/5
        public bool Put(int id, [FromBody]Guest value)
        {
            return manger.Put(id, value);
        }

        // DELETE: api/Guest/5
        public bool Delete(int id)
        {
            return manger.Delete(id);
        }
    }
}
