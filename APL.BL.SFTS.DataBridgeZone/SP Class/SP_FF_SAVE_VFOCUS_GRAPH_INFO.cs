using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone
{
	public class SP_FF_SAVE_VFOCUS_GRAPH_INFO : ObjectMakerFromOracleSP.ISpClassEntity
	{
		[DataMember]
		public int GRAPH_ID { get; set; }
		[DataMember]
		public string GRAPH_CODE { get; set; }
		[DataMember]
		public string GRAPH_NAME { get; set; }
		[DataMember]
		public string DETAIL { get; set; }
		[DataMember]
		public decimal CREATEBY { get; set; }
		[DataMember]
		public decimal LASTMODIFYBY { get; set; }
		[DataMember]
		public string ISDELETE { get; set; }
		[DataMember]
		public string STRMODE { get; set; }
		[DataMember]
		public decimal ERRORCODE { get; set; }

		public void Dispose()
		{
			throw new NotImplementedException();
		}

		public object MapToEntity(object[] values)
		{
			SP_FF_SAVE_VFOCUS_GRAPH_INFO entity = new SP_FF_SAVE_VFOCUS_GRAPH_INFO();

			if (values[0].GetType() != typeof(System.DBNull))
				entity.GRAPH_ID = Convert.ToInt16(values[0]);

			if (values[1].GetType() != typeof(System.DBNull))
				entity.GRAPH_CODE = values[1].ToString();
			if (values[2].GetType() != typeof(System.DBNull))
				entity.GRAPH_NAME = values[2].ToString();
			if (values[3].GetType() != typeof(System.DBNull))
				entity.DETAIL = values[3].ToString();
			return entity;
		}
	}




	public class VFOCUS_KPI_INFO : ObjectMakerFromOracleSP.ISpClassEntity
	{
		[DataMember]
		public int KPI_KEY { get; set; }
		[DataMember]
		public string KPI_NAME { get; set; }
		[DataMember]
		public string STATUS { get; set; }
		[DataMember]
		public string DETAILS { get; set; }
		[DataMember]
		public string KPI_MAP { get; set; }


		public void Dispose()
		{
			throw new NotImplementedException();
		}

		public object MapToEntity(object[] values)
		{
			VFOCUS_KPI_INFO entity = new VFOCUS_KPI_INFO();

			if (values[0].GetType() != typeof(System.DBNull))
				entity.KPI_KEY = Convert.ToInt16(values[0]);

			if (values[1].GetType() != typeof(System.DBNull))
				entity.KPI_NAME = values[1].ToString();

			if (values[2].GetType() != typeof(System.DBNull))
				entity.STATUS = (Convert.ToInt16(values[2].ToString()) > 0) ? "Y" : "N";

			if (values[3].GetType() != typeof(System.DBNull))
				entity.DETAILS = values[3].ToString();

			return entity;
		}
	}




	public class VFOCUS_GRAPH_VS_KPI : ObjectMakerFromOracleSP.ISpClassEntity
	{
		[DataMember]
		public int GRAPH_ID { get; set; }
		[DataMember]
		public string GRAPH_CODE { get; set; }
		[DataMember]
		public string GRAPH_NAME { get; set; }
		[DataMember]
		public int KPI_KEY { get; set; }
		[DataMember]
		public string KPI_NAME { get; set; }
		[DataMember]
		public string KPI_DETAILS { get; set; }


		public void Dispose()
		{
			throw new NotImplementedException();
		}

		public object MapToEntity(object[] values)
		{
			VFOCUS_GRAPH_VS_KPI entity = new VFOCUS_GRAPH_VS_KPI();

			if (values[0].GetType() != typeof(System.DBNull))
				entity.GRAPH_ID = Convert.ToInt16(values[0]);

			if (values[1].GetType() != typeof(System.DBNull))
				entity.GRAPH_CODE = values[1].ToString();

			if (values[2].GetType() != typeof(System.DBNull))
				entity.GRAPH_NAME = values[2].ToString();

			if (values[3].GetType() != typeof(System.DBNull))
				entity.KPI_KEY = Convert.ToInt16(values[3]);

			if (values[4].GetType() != typeof(System.DBNull))
				entity.KPI_NAME = values[4].ToString();

			if (values[5].GetType() != typeof(System.DBNull))
				entity.KPI_DETAILS = values[5].ToString();


			return entity;
		}
	}






	public class VFOCUS_KPI_DASHBOARD : ObjectMakerFromOracleSP.ISpClassEntity
	{
		
		

		[DataMember] public string KPI1_KEY { get; set; }
		[DataMember] public string KPI1_NAME { get; set; }
		[DataMember] public string GRAPH1_ID { get; set; }
		[DataMember] public string GRAPH1_CODE { get; set; }
		[DataMember] public string GRAPH1_NAME { get; set; }
		[DataMember] public string KPI2_KEY { get; set; }
		[DataMember] public string KPI2_NAME { get; set; }
		[DataMember] public string GRAPH2_ID { get; set; }
		[DataMember] public string GRAPH2_CODE { get; set; }
		[DataMember] public string GRAPH2_NAME { get; set; }
		[DataMember] public string KPI3_KEY { get; set; }
		[DataMember] public string KPI3_NAME { get; set; }
		[DataMember] public string GRAPH3_ID { get; set; }
		[DataMember] public string GRAPH3_CODE { get; set; }
		[DataMember] public string GRAPH3_NAME { get; set; }

		
		public void Dispose()
		{
			throw new NotImplementedException();
		}

		public object MapToEntity(object[] values)
		{
			VFOCUS_KPI_DASHBOARD entity = new VFOCUS_KPI_DASHBOARD();
						
			
			if (values[1].GetType() != typeof(System.DBNull))
				entity.KPI1_KEY = values[1].ToString();

			if (values[2].GetType() != typeof(System.DBNull))
				entity.KPI1_NAME = values[2].ToString();

			if (values[3].GetType() != typeof(System.DBNull))
				entity.GRAPH1_ID = values[3].ToString();

			if (values[4].GetType() != typeof(System.DBNull))
				entity.GRAPH1_CODE = values[4].ToString();

			if (values[5].GetType() != typeof(System.DBNull))
				entity.GRAPH1_NAME = values[5].ToString();


			if (values[6].GetType() != typeof(System.DBNull))
				entity.KPI2_KEY = values[6].ToString();

			if (values[7].GetType() != typeof(System.DBNull))
				entity.KPI2_NAME = values[7].ToString();

			if (values[8].GetType() != typeof(System.DBNull))
				entity.GRAPH2_ID = values[8].ToString();

			if (values[9].GetType() != typeof(System.DBNull))
				entity.GRAPH2_CODE = values[9].ToString();

			if (values[10].GetType() != typeof(System.DBNull))
				entity.GRAPH2_NAME = values[10].ToString();


			if (values[11].GetType() != typeof(System.DBNull))
				entity.KPI3_KEY = values[11].ToString();

			if (values[12].GetType() != typeof(System.DBNull))
				entity.KPI3_NAME = values[12].ToString();

			if (values[13].GetType() != typeof(System.DBNull))
				entity.GRAPH3_ID = values[13].ToString();

			if (values[14].GetType() != typeof(System.DBNull))
				entity.GRAPH3_CODE = values[14].ToString();

			if (values[15].GetType() != typeof(System.DBNull))
				entity.GRAPH3_NAME = values[15].ToString();




			return entity;
		}
	}




	public class VFOCUS_ASS_UNASS_GRAPH : ObjectMakerFromOracleSP.ISpClassEntity
	{

		[DataMember]
		public int GRAPH_ID { get; set; }
		[DataMember]
		public string GRAPH_CODE { get; set; }
		[DataMember]
		public bool ISASSIGN { get; set; }
		
		public void Dispose()
		{
			throw new NotImplementedException();
		}

		public object MapToEntity(object[] values)
		{
			VFOCUS_ASS_UNASS_GRAPH entity = new VFOCUS_ASS_UNASS_GRAPH();

			if (values[0].GetType() != typeof(System.DBNull))
				entity.GRAPH_ID = Convert.ToInt16(values[0]);

			if (values[1].GetType() != typeof(System.DBNull))
				entity.GRAPH_CODE = values[1].ToString();

			if (values[2].GetType() != typeof(System.DBNull))
				entity.ISASSIGN = values[2].ToString() == "1" ? true : false;
					

			return entity;
		}
	}





	public class VFOCUS_DENO : ObjectMakerFromOracleSP.ISpClassEntity
	{

		[DataMember]
		public int DENO_ID { get; set; }
		[DataMember]
		public int RECH_DENO { get; set; }
		[DataMember]
		public string PACK_NAME { get; set; }
		[DataMember]
		public string RECH_TYPE { get; set; }
		[DataMember]
		public string LASTUPDATEBY { get; set; }
		[DataMember]
		public bool ISASSIGN { get; set; }

		public void Dispose()
		{
			throw new NotImplementedException();
		}

		public object MapToEntity(object[] values)
		{
			VFOCUS_DENO entity = new VFOCUS_DENO();

			if (values[0].GetType() != typeof(System.DBNull))
				entity.DENO_ID = Convert.ToInt16(values[0]);

			if (values[1].GetType() != typeof(System.DBNull))
				entity.RECH_DENO = Convert.ToInt16(values[1]);

			if (values[2].GetType() != typeof(System.DBNull))
				entity.PACK_NAME = values[2].ToString();

			if (values[3].GetType() != typeof(System.DBNull))
				entity.RECH_TYPE = values[3].ToString();

			if (values[4].GetType() != typeof(System.DBNull))
				entity.LASTUPDATEBY = values[4].ToString();


			if (values[5].GetType() != typeof(System.DBNull))
				entity.ISASSIGN = values[5].ToString() == "1" ? true : false;


			return entity;
		}
	}



}
