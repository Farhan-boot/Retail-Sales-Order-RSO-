using APL.BL.SFTS.DataBridgeZone;
using APL.BL.SFTS.DataBridgeZone.POSM;
using APL.BL.SFTS.DataBridgeZone.Sales;
using APL.BL.SFTS.DataBridgeZone.SP_Class;
using APL.BL.SFTS.Models.ApiMobile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.ProcessZone.Posm
{
    public class PosmPZ
    {
        public decimal SaveIssuePosm(decimal Id, DateTime ISSUE_DATE, decimal STAFF_USERID, decimal RETAILERID,
                               decimal CATEGORYID, decimal PRODUCTID, decimal QTY, String ITOPUP_NUMBER, char strmode)
        {
            try
            {
                return new PosmDZ().SaveIssuePosm(Id, ISSUE_DATE, STAFF_USERID, RETAILERID, CATEGORYID, PRODUCTID, QTY, ITOPUP_NUMBER, strmode);
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
                return new PosmDZ().GetIssueRequest(STAFF_USERID, RETAILERID);
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
                return new PosmDZ().GetProductCategory();
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
                return new PosmDZ().GetProductList(ProductCategory);
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
				return new PosmDZ().GetTop5IssueProduct();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

	}
}
