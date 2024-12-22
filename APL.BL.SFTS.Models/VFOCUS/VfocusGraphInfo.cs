using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.Models.VFOCUS
{
    public class VfocusGraphInfo
    {
        public int GraphId { get; set; }
        public string GraphCode { get; set; }
        public string GraphName { get; set; }
        public string Detail { get; set; }
        public int CreatedBy { get; set; }
		public int updateBy { get; set; }
		public string StrMode { get; set; }
		public string isdelete { get; set; }
	}

	public class VfocusGraphKPI
	{
		public int GRAPH_ID { get; set; }		
		public int KPI_KEY { get; set; }
		public int CreatedBy { get; set; }
	}
	

	public class VfocusGraphKPIMAP
	{
		public List<AssingGraph> AssingGraph { get; set; }
		public List<UnassignGraph> UnassignGraph { get; set; }
	}


	public class AssingGraph
	{
		public int GRAPH_ID { get; set; }
		public string GRAPH_CODE { get; set; }
		public bool ISASSIGN { get; set; }
		[JsonProperty("$$hashKey")]
		public string HashKey { get; set; }
	}

	public class UnassignGraph
	{
		public int GRAPH_ID { get; set; }
		public string GRAPH_CODE { get; set; }
		public bool ISASSIGN { get; set; }
		[JsonProperty("$$hashKey")]
		public string HashKey { get; set; }
	}

	public class VfocusKPIDASHBOARD
	{
		public int ID { get; set; }
		public int KPI_KEY1 { get; set; }
		public int GRAPH_ID1 { get; set; }
		public int KPI_KEY2 { get; set; }
		public int GRAPH_ID2 { get; set; }
		public int KPI_KEY3 { get; set; }
		public int GRAPH_ID3 { get; set; }
		public int LASTUPDATE_BY { get; set; }
		public int CreatedBy { get; set; }

	}



	public class DENOLIST
	{
		public int DENO_ID { get; set; }
		public int RECH_DENO { get; set; }
		public string PACK_NAME { get; set; }
		public string RECH_TYPE { get; set; }
		public int LASTUPDATEBY { get; set; }
		public bool ISASSIGN { get; set; }
		[JsonProperty("$$hashKey")]
		public string HashKey { get; set; }
		
	}


	public class AssingDENO
	{
		public int DENO_ID { get; set; }
		public int RECH_DENO { get; set; }
		public string PACK_NAME { get; set; }
		public string RECH_TYPE { get; set; }
		public object LASTUPDATEBY { get; set; }
		public bool ISASSIGN { get; set; }
		[JsonProperty("$$hashKey")]
		public string HashKey { get; set; }
	}

	public class UnassingDENO
	{
		public int DENO_ID { get; set; }
		public int RECH_DENO { get; set; }
		public string PACK_NAME { get; set; }
		public string RECH_TYPE { get; set; }
		public object LASTUPDATEBY { get; set; }
		public bool ISASSIGN { get; set; }
		[JsonProperty("$$hashKey")]
		public string HashKey { get; set; }
	}

	public class VfocusDENOLIST
	{
		public int LASTUPDATEBY { get; set; }
		public List<AssingDENO> AssingDENO { get; set; }
		public List<UnassingDENO> UnassingDENO { get; set; }
	}



	public class ViewableFileinfo
	{
		public decimal fileID { get; set; }
		public int uploadBy { get; set; }
		public int fileCategory { get; set; }
		public string fileName { get; set; }
		public string fileLink { get; set; }
		public int fileFormat { get; set; }
		public string fileDetail { get; set; }
		public int IsActive { get; set; }
		public string STRMODE { get; set; }
		 
	}

	public class FILE_UPLOAD_ID
	{
		public decimal Id { get; set; }
	}







}
