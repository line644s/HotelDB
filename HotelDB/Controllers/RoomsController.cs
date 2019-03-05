using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Modellib.Model;

namespace HotelDB.Controllers
{
    public class RoomsController : ApiController
    {
        // GET: api/Rooms
        public IEnumerable<Room> Get()
        {
            return null;
        }

        // GET: api/Rooms/5
        public Room Get(int id)
        {
            return null;
        }

        // POST: api/Rooms
        public void Post([FromBody]Room value)
        {
        }

        // PUT: api/Rooms/5
        public void Put(int id, [FromBody]Room value)
        {
        }

        // DELETE: api/Rooms/5
        public void Delete(int id)
        {
        }
    }
}
