using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace APL.BL.SFTS.DataBridgeZone
{
    public class ObjectMakerFromOracleSP
    {
        public interface ISpClassEntity : IDisposable
        {
            object MapToEntity(object[] values);
        }

        public static class OracleHelper<T> where T : ISpClassEntity
        {
            static string connStringMainDB = ConfigurationManager.ConnectionStrings["APL_DB_ConnString"].ConnectionString;
            static string connStringLoginDB = ConfigurationManager.ConnectionStrings["APL_DB_ConnStringLogin"].ConnectionString;

            private static Exception GetInnerMostException(Exception ex)
            {
                return ex.InnerException == null ? ex : GetInnerMostException(ex.InnerException);
            }



            public static object GetDataBySP(T obj, string spName, int colCount, params OracleParameter[] para)
            {
                OracleConnection cn = new OracleConnection(connStringMainDB);
                OracleCommand cmd = new OracleCommand(spName);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                foreach (OracleParameter p in para)
                {
                    cmd.Parameters.Add(p);
                }
                cmd.Connection = cn;
                List<T> collection = new List<T>();
                try
                {
                    cmd.Connection.Open();
                    OracleDataReader reader = cmd.ExecuteReader();
                    object[] values = new object[colCount];

                    while (reader.Read())
                    {
                        reader.GetValues(values);
                        collection.Add((T)obj.MapToEntity(values));
                    }
                }
                catch (Exception ex)
                {
                    ex = GetInnerMostException(ex);
                    throw new Exception(ex.Message, ex);
                }
                finally
                {
                    cmd.Connection.Close();
                }
                return collection;
            }


            /// <summary>
            /// Connect to Login Database 
            /// </summary>           
            /// <returns></returns>
            public static object GetDataLoginDBySP(T obj, string spName, int colCount, params OracleParameter[] para)
            {
                OracleConnection cn = new OracleConnection(connStringLoginDB);
                OracleCommand cmd = new OracleCommand(spName);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                foreach (OracleParameter p in para)
                {
                    cmd.Parameters.Add(p);
                }
                cmd.Connection = cn;
                List<T> collection = new List<T>();
                try
                {
                    cmd.Connection.Open();
                    OracleDataReader reader = cmd.ExecuteReader();
                    object[] values = new object[colCount];

                    while (reader.Read())
                    {
                        reader.GetValues(values);
                        collection.Add((T)obj.MapToEntity(values));
                    }
                }
                catch (Exception ex)
                {
                    ex = GetInnerMostException(ex);
                    throw new Exception(ex.Message, ex);
                }
                finally
                {
                    cmd.Connection.Close();
                }
                return collection;
            }

            public static object GetDataWithBlobBySP(T obj, string spName, int colCount, params OracleParameter[] para)
            {
                OracleConnection cn = new OracleConnection(connStringMainDB);
                OracleCommand cmd = new OracleCommand(spName);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                foreach (OracleParameter p in para)
                {
                    cmd.Parameters.Add(p);
                }
                cmd.Connection = cn;
                List<T> collection = new List<T>();
                try
                {
                    cmd.Connection.Open();
                    OracleDataReader reader = cmd.ExecuteReader();
                    object[] values = new object[colCount];

                    while (reader.Read())
                    {
                        reader.GetValues(values);

                        Oracle.ManagedDataAccess.Types.OracleBlob blob = reader.GetOracleBlob(colCount - 1);
                        Byte[] byteArr = new Byte[blob.Length];
                        int returnValue = blob.Read(byteArr, 0, System.Convert.ToInt32(blob.Length));
                        String pictureBase64 = Convert.ToBase64String(byteArr);
                        values[colCount - 1] = (object)pictureBase64;
                        collection.Add((T)obj.MapToEntity(values));
                    }
                }
                catch (Exception ex)
                {
                    ex = GetInnerMostException(ex);
                    throw new Exception(ex.Message, ex);
                }
                finally
                {
                    cmd.Connection.Close();
                }
                return collection;
            }

            public static Decimal InsertDataBySP(string spName, params OracleParameter[] para)
            {
                OracleConnection cn = new OracleConnection(connStringMainDB);
                OracleCommand cmd = new OracleCommand(spName);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                foreach (OracleParameter p in para)
                {
                    cmd.Parameters.Add(p);
                }
                cmd.Connection = cn;
                Decimal insertID = 0;
                try
                {
                    cmd.Connection.Open();
                    OracleDataReader reader = cmd.ExecuteReader();
                    object[] values = new object[1];

                    if (reader.Read())
                    {
                        reader.GetValues(values);
                        if (values != null && values[0].GetType() != typeof(System.DBNull))
                            insertID = Convert.ToDecimal(values[0]);
                    }
                    else
                    {
                        insertID = Convert.ToDecimal(cmd.Parameters[0].Value.ToString());
                    }
                }
                catch (Exception ex)
                {
                    ex = GetInnerMostException(ex);
                    throw new Exception(ex.Message, ex);
                }
                finally
                {
                    cmd.Connection.Close();
                }
                return insertID;
            }


            //Take input parameter for save and return processing string data.
            public static string InsertDataBySPstr(string spName, params OracleParameter[] para)
            {
                OracleConnection cn = new OracleConnection(connStringMainDB);
                OracleCommand cmd = new OracleCommand(spName);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                foreach (OracleParameter p in para)
                {
                    cmd.Parameters.Add(p);
                }
                cmd.Connection = cn;
                string replyMsg = string.Empty;
                try
                {
                    cmd.Connection.Open();
                    OracleDataReader reader = cmd.ExecuteReader();
                    object[] values = new object[1];

                    if (reader.Read())
                    {
                        reader.GetValues(values);
                        if (values != null && values[0].GetType() != typeof(System.DBNull))
                            replyMsg = Convert.ToString(values[0]);
                    }
                    else
                    {
                        replyMsg = Convert.ToString(cmd.Parameters[0].Value.ToString());
                    }
                }
                catch (Exception ex)
                {
                    ex = GetInnerMostException(ex);
                    throw new Exception(ex.Message, ex);
                }
                finally
                {
                    cmd.Connection.Close();
                }
                return replyMsg;
            }

            public static String InsertDataByFun(string spName, params OracleParameter[] para)
            {
                OracleConnection cn = new OracleConnection(connStringMainDB);
                OracleCommand cmd = new OracleCommand(spName);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                foreach (OracleParameter p in para)
                {
                    cmd.Parameters.Add(p);
                }
                cmd.Connection = cn;
                String processMsg = string.Empty;
                try
                {
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    processMsg = Convert.ToString(cmd.Parameters[0].Value);
                }
                catch (Exception ex)
                {
                    ex = GetInnerMostException(ex);
                    throw new Exception(ex.Message, ex);
                }
                finally
                {
                    cmd.Connection.Close();
                }
                return processMsg;
            }
        }

        public static class DataSetAdapter<T>
                                  where T : DataSet, new()
        {
            /// <summary>
            /// Convert the first DataTable from a DataSet to a
            /// strongly-typed data table.
            /// </summary>
            public static T convert(DataSet dataSet)
            {
                if (dataSet == null)
                    return null;
                if (dataSet.Tables.Count == 0)
                    return null;
                DataTable dataTable = dataSet.Tables[0];

                T tds = new T();
                // Map each row of each table in the untyped DataSet to a

                // corresponding item in the strongly typed DataSet


                for (int i = 0; i < dataSet.Tables.Count; i++)
                {
                    foreach (DataRow iDr in dataSet.Tables[i].Rows)
                    {
                        DataRow oDr = tds.Tables[i].NewRow();
                        for (int j = 0; j < dataSet.Tables[i].Columns.Count; j++)
                            try
                            {
                                oDr[j] = iDr[j].ToString();
                            }
                            catch (NoNullAllowedException)
                            {
                                // ignore for now � just in

                                // case no such column in DataSet

                            }
                        tds.Tables[i].Rows.Add(oDr);
                    }
                }
                tds.AcceptChanges();
                return tds;
                //return convert(dataTable);
            }
            /// <summary>
            /// Convert an ordinary DataTable to a strongly-typed
            /// data table.
            /// </summary>
            public static T convert(DataTable dataTable)
            {
                if (dataTable == null)
                    return null;
                T stronglyTyped = new T();
                // add data from the regular DataTable to the
                // strongly typed DataTable.
                //stronglyTyped.Merge(dataTable);
                return stronglyTyped;
            }
        }
    }
}
