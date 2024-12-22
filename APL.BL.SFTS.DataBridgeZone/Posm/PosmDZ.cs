using APL.BL.SFTS.DataBridgeZone.SP_Class;
using APL.BL.SFTS.Models.ApiMobile;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone.POSM
{
    public class PosmDZ
    {
        readonly string connStringMainDB = ConfigurationManager.ConnectionStrings["APL_DB_ConnString"].ConnectionString;

      
        //Md.Aawlad Hossain dev.

        public Decimal SaveIssuePosm(decimal Id, DateTime ISSUE_DATE, decimal STAFF_USERID, decimal RETAILERID,
                               decimal CATEGORYID, decimal PRODUCTID, decimal QTY, string ITOPUP_NUMBER, char strmode)
        {
            try
            {
                OracleParameter Id_OP = new OracleParameter();
                Id_OP.Direction = System.Data.ParameterDirection.Input;
                Id_OP.OracleDbType = OracleDbType.Decimal;
                Id_OP.Value = Id;

                OracleParameter ISSUE_DATE_OP = new OracleParameter();
                ISSUE_DATE_OP.Direction = System.Data.ParameterDirection.Input;
                ISSUE_DATE_OP.OracleDbType = OracleDbType.Date;
                ISSUE_DATE_OP.Value = ISSUE_DATE;

                OracleParameter STAFF_USERID_OP = new OracleParameter();
                STAFF_USERID_OP.Direction = System.Data.ParameterDirection.Input;
                STAFF_USERID_OP.OracleDbType = OracleDbType.Decimal;
                STAFF_USERID_OP.Value = STAFF_USERID;

                OracleParameter RETAILERID_OP = new OracleParameter();
                RETAILERID_OP.Direction = System.Data.ParameterDirection.Input;
                RETAILERID_OP.OracleDbType = OracleDbType.Decimal;
                RETAILERID_OP.Value = RETAILERID;

                OracleParameter CATEGORYID_OP = new OracleParameter();
                CATEGORYID_OP.Direction = System.Data.ParameterDirection.Input;
                CATEGORYID_OP.OracleDbType = OracleDbType.Decimal;
                CATEGORYID_OP.Value = CATEGORYID;

                OracleParameter PRODUCTID_OP = new OracleParameter();
                PRODUCTID_OP.Direction = System.Data.ParameterDirection.Input;
                PRODUCTID_OP.OracleDbType = OracleDbType.Decimal;
                PRODUCTID_OP.Value = PRODUCTID;

                OracleParameter QTY_OP = new OracleParameter();
                QTY_OP.Direction = System.Data.ParameterDirection.Input;
                QTY_OP.OracleDbType = OracleDbType.Decimal;
                QTY_OP.Value = QTY; 

				 OracleParameter errCode_OP = new OracleParameter();
                errCode_OP.Direction = System.Data.ParameterDirection.Output;
                errCode_OP.OracleDbType = OracleDbType.Decimal;
                errCode_OP.Value = errCode_OP;


				OracleParameter ITOPUP_NUMBER_OP = new OracleParameter();
				ITOPUP_NUMBER_OP.Direction = System.Data.ParameterDirection.Input;
				ITOPUP_NUMBER_OP.OracleDbType = OracleDbType.Varchar2;
				ITOPUP_NUMBER_OP.Value = ITOPUP_NUMBER;

				OracleParameter strmode_OP = new OracleParameter();
                strmode_OP.Direction = System.Data.ParameterDirection.Input;
                strmode_OP.OracleDbType = OracleDbType.Char;
                strmode_OP.Value = strmode;

                return ObjectMakerFromOracleSP.OracleHelper<GET_SAVE_RESULT>.InsertDataBySP("SP_FF_INS_ISSUEPOSM", Id_OP, ISSUE_DATE_OP, STAFF_USERID_OP, RETAILERID_OP, CATEGORYID_OP, PRODUCTID_OP, QTY_OP, ITOPUP_NUMBER_OP, strmode_OP, errCode_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Get_issue_request> GetIssueRequest(decimal STAFF_USERID, decimal RETAILERID)
        {
            try
            {
                OracleParameter MTOID_OP = new OracleParameter();
                MTOID_OP.Direction = System.Data.ParameterDirection.Input;
                MTOID_OP.OracleDbType = OracleDbType.Decimal;
                MTOID_OP.Value = STAFF_USERID;

                OracleParameter RETAILERID_OP = new OracleParameter();
                RETAILERID_OP.Direction = System.Data.ParameterDirection.Input;
                RETAILERID_OP.OracleDbType = OracleDbType.Decimal;
                RETAILERID_OP.Value = RETAILERID;


                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<Get_issue_request>)ObjectMakerFromOracleSP.OracleHelper<Get_issue_request>.GetDataBySP(new Get_issue_request(), "SP_FF_GET_ISSUEREQUEST", 10, MTOID_OP, RETAILERID_OP, resultOutCurSor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // for drop down
        public List<SP_GET_PRODUCTCATEGORY> GetProductCategory()
        {
            try
            {

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_PRODUCTCATEGORY>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_PRODUCTCATEGORY>.GetDataBySP(new SP_GET_PRODUCTCATEGORY(), "SP_FF_GET_ProductCategory", 8, resultOutCurSor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<GET_SP_PRODUCTLIST> GetProductList(decimal ProductCategory)
        {
            try
            {
                OracleParameter PCID_OP = new OracleParameter();
                PCID_OP.Direction = System.Data.ParameterDirection.Input;
                PCID_OP.OracleDbType = OracleDbType.Decimal;
                PCID_OP.Value = ProductCategory;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<GET_SP_PRODUCTLIST>)ObjectMakerFromOracleSP.OracleHelper<GET_SP_PRODUCTLIST>.GetDataBySP(new GET_SP_PRODUCTLIST(), "SP_FF_GET_ProductList", 8, resultOutCurSor, PCID_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


		public List<SP_FF_GET_Top5POSMP_PRODUCT> GetTop5IssueProduct()
		{
			try
			{


				OracleParameter resultOutCurSor = new OracleParameter();
				resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
				resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

				return (List<SP_FF_GET_Top5POSMP_PRODUCT>)ObjectMakerFromOracleSP.OracleHelper<SP_FF_GET_Top5POSMP_PRODUCT>.GetDataBySP(new SP_FF_GET_Top5POSMP_PRODUCT(), "SP_FF_GET_Top5POSMP_PRODUCT", 8, resultOutCurSor);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


	}
}
