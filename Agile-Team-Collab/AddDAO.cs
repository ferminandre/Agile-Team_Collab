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
                Console.WriteLine(_conn.State.ToString());
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

        public List<Add> GetCode()
        {
            List<Add> list = new List<Add>();

            //string connString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = DBMoneyManager; Integrated Security = True;";
            try
            {


                string sqlstring = @"select * from Barang where Code = @Code";
                
                SqlCommand cmd = new SqlCommand(sqlstring, _conn);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@code", null);
                Console.WriteLine(_conn.State.ToString());
                SqlDataReader reader = cmd.ExecuteReader();
                

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Add l = new Add();
                        string code = reader["Code"].ToString();
                        string name = reader["Name"].ToString();
                        int price = Int32.Parse(reader["Price"].ToString());
                        list.Add(l);
                    }
                }
                reader.Close();
                cmd.Dispose();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (_conn != null) _conn.Close();
            }

            return list;
        }

        public Barang SearchItemBarang(string kode)
        {
            Barang barang = null;
            try
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = _conn;
                    cmd.CommandText = @"select * from barang where code = @code";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@code", kode);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            barang = new Barang { Code = reader["code"].ToString(), Name = reader["name"].ToString(), Price = Convert.ToDecimal(reader["price"]) };
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return barang;
        }

        public void Dispose()
        {
            if (_conn != null) _conn.Close();
        }
    }
}
