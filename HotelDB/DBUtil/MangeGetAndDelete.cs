using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Modellib.Model;

namespace HotelDB.DBUtil
{
    public abstract class MangeGetAndDelete<T> : IMange<T>
    {
        private const string ConnString =
            @"Data Source=line644s-zealand-dbsever.database.windows.net;Initial Catalog=line644s-zealand-db;User ID=line644s;Password=Database123;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private const string GET_ALL = "SELECT * FROM @Tabel";
        private const string GET_ONE = "SELECT * FROM @Tabel WHERE @IdName = @ID";

        public IEnumerable<T> Get( string TabelName)
        {
            List<T> liste = new List<T>();

            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(GET_ALL, conn);
            cmd.Parameters.AddWithValue("@Tabel", TabelName);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                T value = ReadItems(reader);
                liste.Add(value);
            }
            conn.Close();
            return liste;
        }

        private T ReadItems(SqlDataReader reader)
        {
            T facilitet = new T();

            T.Id = reader.GetInt32(0);
            facilitet.Name = reader.GetString(1);

            return facilitet;
        }

        public T Get(int id)
        {
            throw new NotImplementedException();
        }

        public abstract bool Post(T value);


        public abstract bool Put(int id, T value);
        

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}