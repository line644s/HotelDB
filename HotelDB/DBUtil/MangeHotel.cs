using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;
using Modellib.Model;

namespace HotelDB.DBUtil
{
    public class MangeHotel : IMange<Hotel>
    {
        private const string ConnString =
            @"Data Source=line644s-zealand-dbsever.database.windows.net;Initial Catalog=line644s-zealand-db;User ID=line644s;Password=Database123;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private const string GET_ALL = "SELECT * FROM DemoHotel";
        private const string GET_ONE = "SELECT * FROM DemoHotel WHERE Hotel_no = @ID";
        private const string INSERT = "INSERT INTO DemoHotel VALUES (@ID, @NAME, @ADDRESS)";
        private const string DELETE = "DELETE FROM DemoHotel WHERE Hotel_no = @ID";
        private const string UPDATE = "UPDATE DemoHotel "+
                                      "SET Hotel_no = @HotelID, Name = @NAME, Address = @ADDRESS " +
                                      "WHERE Hotel_no = @ID";

        // GET: api/Hotels
        public IEnumerable<Hotel> Get()
        {
            List<Hotel> liste = new List<Hotel>();

            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(GET_ALL, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Hotel hotel = ReadHotel(reader);
                liste.Add(hotel);
            }
            conn.Close();
            return liste;
        }

        private Hotel ReadHotel(SqlDataReader reader)
        {
            Hotel hotel = new Hotel();

            hotel.Id = reader.GetInt32(0);
            hotel.Name = reader.GetString(1);
            hotel.Address = reader.GetString(2);

            return hotel;
        }

        // GET: api/Hotels/5
        public Hotel Get(int id)
        {
            Hotel hotel = null;

            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(GET_ONE, conn);
            cmd.Parameters.AddWithValue("@ID", id);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                hotel = ReadHotel(reader);
            }
            conn.Close();
            return hotel;
        }

        // POST: api/Hotels
        public bool Post(Hotel hotel)
        {
            bool retValue = false;
            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(INSERT, conn);
            cmd.Parameters.AddWithValue("@ID", hotel.Id);
            cmd.Parameters.AddWithValue("@NAME", hotel.Name);
            cmd.Parameters.AddWithValue("@ADDRESS", hotel.Address);

            int RowsAffected = cmd.ExecuteNonQuery();

            retValue = RowsAffected == 1 ? true : false;
            conn.Close();
            return retValue;
        }

        // PUT: api/Hotels/5
        public bool Put(int id, Hotel hotel)
        {
            bool retValue = false;
            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(UPDATE, conn);
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@HotelID", hotel.Id);
            cmd.Parameters.AddWithValue("@NAME", hotel.Name);
            cmd.Parameters.AddWithValue("@ADDRESS", hotel.Address);

            int RowsAffected = cmd.ExecuteNonQuery();

            retValue = RowsAffected == 1 ? true : false;
            conn.Close();
            return retValue;
        }

        // DELETE: api/Hotels/5
        public bool Delete(int id)
        {
            bool retValue = false;

            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(DELETE, conn);
            cmd.Parameters.AddWithValue("@ID", id);

            int RowsAffected = cmd.ExecuteNonQuery();

            retValue = RowsAffected == 1 ? true : false;
            conn.Close();
            return retValue;
        }
    }
}