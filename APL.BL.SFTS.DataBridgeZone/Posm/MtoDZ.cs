using APL.BL.SFTS.DataBridgeZone.SP_Class;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone.RSO
{
   
    public class MtoDZ
    {
        readonly string connStringMainDB = ConfigurationManager.ConnectionStrings["APL_DB_ConnString"].ConnectionString;


        //Md.Aawlad Hossain dev.

       
        public List<Get_RouteList_Fr_MTO> RouteListForMTO(decimal MTOID)
        {
            try
            {
                OracleParameter MTOID_OP = new OracleParameter();
                MTOID_OP.Direction = System.Data.ParameterDirection.Input;
                MTOID_OP.OracleDbType = OracleDbType.Decimal;
                MTOID_OP.Value = MTOID;

                

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<Get_RouteList_Fr_MTO>)ObjectMakerFromOracleSP.OracleHelper<Get_RouteList_Fr_MTO>.GetDataBySP(new Get_RouteList_Fr_MTO(), "SP_FF_GET_MTO_ROUTE", 5, MTOID_OP, resultOutCurSor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<GET_RETAILER_FOR_MTO> RetailerListForMTO(decimal MTOID, decimal routeID, decimal sso, decimal lso)
        {
            try
            {
                OracleParameter MTOID_OP = new OracleParameter();
                MTOID_OP.Direction = System.Data.ParameterDirection.Input;
                MTOID_OP.OracleDbType = OracleDbType.Decimal;
                MTOID_OP.Value = MTOID;

				OracleParameter route_OP = new OracleParameter();
				route_OP.Direction = System.Data.ParameterDirection.Input;
				route_OP.OracleDbType = OracleDbType.Decimal;
				route_OP.Value = routeID;

				OracleParameter SSO_OP = new OracleParameter();
				SSO_OP.Direction = System.Data.ParameterDirection.Input;
				SSO_OP.OracleDbType = OracleDbType.Decimal;
				SSO_OP.Value = sso;

				OracleParameter LSO_OP = new OracleParameter();
				LSO_OP.Direction = System.Data.ParameterDirection.Input;
				LSO_OP.OracleDbType = OracleDbType.Decimal;
				LSO_OP.Value = lso;



				OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<GET_RETAILER_FOR_MTO>)ObjectMakerFromOracleSP.OracleHelper<GET_RETAILER_FOR_MTO>.GetDataBySP(new GET_RETAILER_FOR_MTO(), "SP_FF_GET_MTO_RETAILER", 13, MTOID_OP, route_OP, SSO_OP, LSO_OP, resultOutCurSor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    }
