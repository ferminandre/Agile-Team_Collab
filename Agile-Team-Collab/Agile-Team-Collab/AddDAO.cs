using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Agile_Team_Collab
{
    public class AddDAO : IDisposable
    {
        SqlConnection _conn = null;

        public AddDAO()
        {
            try
            {
                _conn = new SqlConnection(@"Data Source = (localdb)\mssqllocaldb; Initial Catalog = Barangbaru; Integrated Security = true;");
                _conn.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Simpan(List<Add> add)
        {
            bool result = false;
            int rowAffected = 0;
            SqlTransaction trans = null;
            try
            {
                trans = _conn.BeginTransaction();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = _conn;
                    cmd.Transaction = trans;
                    foreach (var item in add)
                    {
                        cmd.CommandText = @"Insert Into Barang Values (@Code, @Name, @Price)";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@Code", item.Code);
                        cmd.Parameters.AddWithValue("@Name", item.Name);
                        cmd.Parameters.AddWithValue("@Price", item.Price);
                        rowAffected = cmd.ExecuteNonQuery();
                    }
                    
                }
                
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                throw ex;
            }
            finally
            {
                if (trans != null) trans.Dispose();
            }
            return result;
        }

        public void Dispose()
        {
            if (_conn != null) _conn.Close();
        }
    }
}
