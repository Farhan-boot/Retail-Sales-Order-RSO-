using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APL.BL.SFTS.DataBridgeZone;

namespace APL.BL.SFTS.ProcessZone
{
    public class TargetExcelPZ
    {
        public TargetExcelPZ() { }
        public decimal SaveOrUpdateTargetExecl(DateTime p_UPLOAD_DATE, String p_FILE_LOCATION, Decimal p_TARGET_AMOUNT, DateTime p_TO_DATE, Decimal p_UPDATE_BY
            , DateTime p_UPDATE_DATE, Decimal p_ID, Decimal p_CREATE_BY, Decimal p_AMOUNT_TYPEID, Decimal p_PRODUCT_FAMILYID, DateTime p_CREATE_DATE,
            DateTime p_DOWNLOAD_DATE, Decimal p_ISACTIVE, DateTime p_FROM_DATE, Decimal p_CHANNELID, Decimal p_COMMISSIONID, String p_FILE_NAME)
        {
            try
            {
                return new TargetExcelDZ().SaveOrUpdateTargetExecl(p_UPLOAD_DATE, p_FILE_LOCATION, p_TARGET_AMOUNT, p_TO_DATE,
                     p_UPDATE_BY, p_UPDATE_DATE, p_ID, p_CREATE_BY, p_AMOUNT_TYPEID, p_PRODUCT_FAMILYID, p_CREATE_DATE, p_DOWNLOAD_DATE, p_ISACTIVE, p_FROM_DATE, p_CHANNELID, p_COMMISSIONID, p_FILE_NAME);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<SP_GET_TARGET_EXCELFILEcls> GetAllTargetExeclFile(decimal inTargetExcelID, decimal inChannelID, decimal inProductFamilyID, decimal inTargetAmountTypeID, DateTime inFromUploadDate,
            DateTime inToUploadDate, decimal inTargetNameID, decimal inCurrentPage)
        {
            try
            {
                return new TargetExcelDZ().GetAllTargetExeclFile(inTargetExcelID, inChannelID, inProductFamilyID, inTargetAmountTypeID, inFromUploadDate, inToUploadDate, inTargetNameID, inCurrentPage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
