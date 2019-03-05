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
    public class HotelsController : ApiController
    {

        private MangeHotel manger = new MangeHotel();
        // GET: api/Hotels
        public IEnumerable<Hotel> Get()
        {
             return manger.Get();
        }

        // GET: api/Hotels/5
        public Hotel Get(int id)
        {
            return manger.Get(id);
        }

        // POST: api/Hotels
        public bool Post([FromBody]Hotel value)
        {
            return manger.Post(value);
        }

        // PUT: api/Hotels/5
        public bool Put(int id, [FromBody]Hotel value)
        {
            return manger.Put(id, value);
        }

        // DELETE: api/Hotels/5
        public bool Delete(int id)
        {
            return manger.Delete(id);
        }
    }
}
