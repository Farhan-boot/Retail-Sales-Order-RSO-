using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace APL.BL.SFTS.ShelterZone
{
    public class DbResult<T> where T : DbConnection
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public DataSet oDataSet { get; set; }

        ConfigFileManager config = ConfigFileManager.GetInstance();

        public DbResult(string _ConnectionString, CommandType _CommandType, string _CommandText)
        {
            this.IsSuccess = false;
            this.Message = string.Empty;
            oDataSet = new DataSet();

            if (typeof(T) == typeof(SqlConnection))
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(_ConnectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.Connection = conn;
                            cmd.CommandTimeout = int.Parse(config.GetValue("CommandTimeout"));
                            cmd.CommandType = _CommandType;
                            cmd.CommandText = _CommandText;
                            cmd.Parameters.Clear();
                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            adapter.Fill(this.oDataSet);
                            adapter.Dispose();
                            cmd.Dispose();
                        }
                        conn.Close();
                    }
                    this.IsSuccess = true;
                }
                catch (Exception ex)
                {
                    this.IsSuccess = false;
                    this.Message = ex.Message;
                }
            }
        }
        public DbResult(string _ConnectionString, CommandType _CommandType, string _CommandText, DbParameter[] _DbParameters)
        {
            this.IsSuccess = false;
            this.Message = string.Empty;
            oDataSet = new DataSet();

            if (typeof(T) == typeof(SqlConnection))
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(_ConnectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.Connection = conn;
                            cmd.CommandTimeout = int.Parse(config.GetValue("CommandTimeout"));
                            cmd.CommandType = _CommandType;
                            cmd.CommandText = _CommandText;
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddRange((SqlParameter[])_DbParameters);
                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            adapter.Fill(this.oDataSet);
                            adapter.Dispose();
                            cmd.Dispose();
                        }
                        conn.Close();
                    }
                    this.IsSuccess = true;
                }
                catch (Exception ex)
                {
                    this.IsSuccess = false;
                    this.Message = ex.Message;
                }
            }
        }

       
    }
}
