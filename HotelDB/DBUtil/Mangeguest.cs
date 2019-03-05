using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Modellib.Model;

namespace HotelDB.DBUtil
{
    public class MangeGuest : IMange<Guest>
    {
        private const string ConnString =
            @"Data Source=line644s-zealand-dbsever.database.windows.net;Initial Catalog=line644s-zealand-db;User ID=line644s;Password=Database123;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private const string GET_ALL = "SELECT * FROM DemoGuest";
        private const string GET_ONE = "SELECT * FROM DemoGuest WHERE Guest_No = @ID";
        private const string INSERT = "INSERT INTO DemoGuest VALUES (@ID, @NAME, @ADDRESS)";
        private const string DELETE = "DELETE FROM DemoGuest WHERE Guest_No = @ID";

        private const string UPDATE = "UPDATE DemoGuest " +
                                      "SET Guest_No = @GuestID, Name = @NAME, Address = @ADDRESS " +
                                      "WHERE Guest_No = @ID";

        public IEnumerable<Guest> Get()
        {
            List<Guest> liste = new List<Guest>();

            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(GET_ALL, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Guest guest = ReadGuest(reader);
                liste.Add(guest);
            }

            conn.Close();
            return liste;
        }

        private Guest ReadGuest(SqlDataReader reader)
        {
            Guest guest = new Guest();

            guest.Id = reader.GetInt32(0);
            guest.Name = reader.GetString(1);
            guest.Address = reader.GetString(2);

            return guest;
        }


        public Guest Get(int id)
        {
            Guest guest = null;

            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(GET_ONE, conn);
            cmd.Parameters.AddWithValue("@ID", id);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                guest = ReadGuest(reader);
            }

            conn.Close();
            return guest;
        }


        public bool Post(Guest guest)
        {
            bool retValue = false;
            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(INSERT, conn);
            cmd.Parameters.AddWithValue("@ID", guest.Id);
            cmd.Parameters.AddWithValue("@NAME", guest.Name);
            cmd.Parameters.AddWithValue("@ADDRESS", guest.Address);

            int RowsAffected = cmd.ExecuteNonQuery();

            retValue = RowsAffected == 1 ? true : false;
            conn.Close();
            return retValue;
        }


        public bool Put(int id, Guest guest)
        {
            bool retValue = false;
            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(UPDATE, conn);
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@GuestID", guest.Id);
            cmd.Parameters.AddWithValue("@NAME", guest.Name);
            cmd.Parameters.AddWithValue("@ADDRESS", guest.Address);

            int RowsAffected = cmd.ExecuteNonQuery();

            retValue = RowsAffected == 1 ? true : false;
            conn.Close();
            return retValue;
        }


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