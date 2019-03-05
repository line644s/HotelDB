using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modellib.Model;

namespace HotelDB.DBUtil
{
    public class MangeRoom : IMange<Room>
    {
        private const string ConnString =
            @"Data Source=line644s-zealand-dbsever.database.windows.net;Initial Catalog=line644s-zealand-db;User ID=line644s;Password=Database123;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private const string GET_ALL = "SELECT * FROM DemoRoom";
        private const string GET_ONE = "SELECT * FROM DemoRoom WHERE Guest_No = @ID";
        private const string INSERT = "INSERT INTO DemoRoom VALUES (@ID, @NAME, @ADDRESS)";
        private const string DELETE = "DELETE FROM DemoRoom WHERE Guest_No = @ID";
        private const string UPDATE = "UPDATE DemoRoom " +
                                      "SET Guest_No = @GuestID, Name = @NAME, Address = @ADDRESS " +
                                      "WHERE Guest_No = @ID";

        public IEnumerable<Room> Get()
        {
            throw new NotImplementedException();
        }

        public Room Get(int id)
        {
            throw new NotImplementedException();
        }

        public bool Post(Room value)
        {
            throw new NotImplementedException();
        }

        public bool Put(int id, Room value)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}