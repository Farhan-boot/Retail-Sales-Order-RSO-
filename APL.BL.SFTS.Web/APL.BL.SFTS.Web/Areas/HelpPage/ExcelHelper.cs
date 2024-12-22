
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;
using System.Configuration;

namespace APL.BL.SFTS.Web.Areas.HelpPage
{
	static public class ExcelHelper
	{
		static public DataTable ReadExcelSheet(string FilePath, string Extension, string isHDR)
		{
			string conStr = "";
			DataTable dt = new DataTable();
			switch (Extension)
			{
				case ".xls": //Excel 97-03
					conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"]
							 .ConnectionString;
					break;
				case ".xlsx": //Excel 07
					conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"]
							  .ConnectionString;
					break;
			}


			try
			{
			
				conStr = String.Format(conStr, FilePath, isHDR);
				OleDbConnection connExcel = new OleDbConnection(conStr);
				OleDbCommand cmdExcel = new OleDbCommand();
				OleDbDataAdapter oda = new OleDbDataAdapter();
				
				cmdExcel.Connection = connExcel;

				//Get the name of First Sheet
				connExcel.Open();
				DataTable dtExcelSchema;
				dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
				string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
				connExcel.Close();

				//Read Data from First Sheet
				connExcel.Open();
				cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";
				oda.SelectCommand = cmdExcel;
				oda.Fill(dt);
				connExcel.Close();
			}
			catch (Exception ex)
			{
				WriteServiceLog(ex.Message.ToString());

			}
			

			return dt;



		}



		 


		public static void WriteServiceLog(string logMessage)
		{
			TextWriter w;
			w = OpenServiceLogFile();
			w.Write($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
			w.Write(" :");
			w.Write($" {logMessage}");
			w.WriteLine(";");
			w.Close();
		}


		private static System.IO.TextWriter OpenServiceLogFile()
		{
			String strlogFileLocation;

			strlogFileLocation = System.Configuration.ConfigurationManager.AppSettings.Get("LogFileLocation");
			// ConfigurationSettings.AppSettings.Get("LogFileLocation");

			if (!System.IO.Directory.Exists(strlogFileLocation))
			{
				System.IO.Directory.CreateDirectory(strlogFileLocation);
			}

			string filepath = strlogFileLocation + "\\Servicelog_" + DateTime.Now.ToString("dd_MMM_yyyy") + ".txt";

			if (!File.Exists(filepath))
			{
				// Create a file to write to.   
				return File.CreateText(filepath);
			}
			else
			{
				return File.AppendText(filepath);
			}
		}


	}
}