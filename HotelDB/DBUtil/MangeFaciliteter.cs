using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Modellib.Model;

namespace HotelDB.DBUtil
{
    public class MangeFaciliteter : IMange<Facilitet>
    {
        private const string ConnString =
            @"Data Source=line644s-zealand-dbsever.database.windows.net;Initial Catalog=line644s-zealand-db;User ID=line644s;Password=Database123;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private const string GET_ALL = "SELECT * FROM DemoFaciliteter";
        private const string GET_ONE = "SELECT * FROM DemoFaciliteter WHERE Faciliteter_Id = @ID";
        private const string INSERT = "INSERT INTO DemoFaciliteter VALUES (@ID, @NAME)";
        private const string DELETE = "DELETE FROM DemoFaciliteter WHERE Faciliteter_Id = @ID";
        private const string UPDATE = "UPDATE DemoFaciliteter " +
                                      "SET Faciliteter_Id = @FacilitetID, Name = @NAME " +
                                      "WHERE Faciliteter_Id = @ID";
        public IEnumerable<Facilitet> Get()
        {
            List<Facilitet> liste = new List<Facilitet>();

            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(GET_ALL, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Facilitet facilitet = ReadFaciliteter(reader);
                liste.Add(facilitet);
            }
            conn.Close();
            return liste;
        }

        public Facilitet Get(int id)
        {
            Facilitet facilitet = new Facilitet();

            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(GET_ONE, conn);
            cmd.Parameters.AddWithValue("@ID", id);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                facilitet = ReadFaciliteter(reader);
            }

            conn.Close();
            return facilitet;
        }

        private Facilitet ReadFaciliteter(SqlDataReader reader)
        {
            Facilitet facilitet = new Facilitet();

            facilitet.Id = reader.GetInt32(0);
            facilitet.Name = reader.GetString(1);

            return facilitet;
        }

        public bool Post(Facilitet facilitet)
        {
            bool retValue = false;
            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(INSERT, conn);
            cmd.Parameters.AddWithValue("@ID", facilitet.Id);
            cmd.Parameters.AddWithValue("@NAME", facilitet.Name);
            

            int rowsAffected = cmd.ExecuteNonQuery();

            retValue = rowsAffected == 1 ? true : false;
            conn.Close();
            return retValue;
        }

        public bool Put(int id, Facilitet facilitet)
        {
            bool retValue = false;
            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(UPDATE, conn);
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@FacilitetID", facilitet.Id);
            cmd.Parameters.AddWithValue("@NAME", facilitet.Name);

            int rowsAffected = cmd.ExecuteNonQuery();

            retValue = rowsAffected == 1 ? true : false;
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

            int rowsAffected = cmd.ExecuteNonQuery();

            retValue = rowsAffected == 1 ? true : false;

            conn.Close();
            return retValue;
        }
    }
}