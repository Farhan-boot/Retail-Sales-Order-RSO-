using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone
{
    public class TargetExcelDZ
    {
        public TargetExcelDZ()
        {

        }

        public decimal SaveOrUpdateTargetExecl(DateTime p_UPLOAD_DATE, String p_FILE_LOCATION, Decimal p_TARGET_AMOUNT, DateTime p_TO_DATE, Decimal p_UPDATE_BY
            , DateTime p_UPDATE_DATE, Decimal p_ID, Decimal p_CREATE_BY, Decimal p_AMOUNT_TYPEID, Decimal p_PRODUCT_FAMILYID, DateTime p_CREATE_DATE,
            DateTime p_DOWNLOAD_DATE, Decimal p_ISACTIVE, DateTime p_FROM_DATE, Decimal p_CHANNELID, Decimal p_COMMISSIONID, String p_FILE_NAME)
        {
            try
            {
                OracleParameter p_UPLOAD_DATE_OP = new OracleParameter();
                p_UPLOAD_DATE_OP.Direction = System.Data.ParameterDirection.Input;
                p_UPLOAD_DATE_OP.OracleDbType = OracleDbType.Date;
                p_UPLOAD_DATE_OP.Value = p_UPLOAD_DATE;

                OracleParameter p_FILE_LOCATION_OP = new OracleParameter();
                p_FILE_LOCATION_OP.Direction = System.Data.ParameterDirection.Input;
                p_FILE_LOCATION_OP.OracleDbType = OracleDbType.Varchar2;
                p_FILE_LOCATION_OP.Value = p_FILE_LOCATION;

                OracleParameter p_TARGET_AMOUNT_OP = new OracleParameter();
                p_TARGET_AMOUNT_OP.Direction = System.Data.ParameterDirection.Input;
                p_TARGET_AMOUNT_OP.OracleDbType = OracleDbType.Decimal;
                p_TARGET_AMOUNT_OP.Value = p_TARGET_AMOUNT;

                OracleParameter p_TO_DATE_OP = new OracleParameter();
                p_TO_DATE_OP.Direction = System.Data.ParameterDirection.Input;
                p_TO_DATE_OP.OracleDbType = OracleDbType.Date;
                p_TO_DATE_OP.Value = p_TO_DATE;

                OracleParameter p_UPDATE_BY_OP = new OracleParameter();
                p_UPDATE_BY_OP.Direction = System.Data.ParameterDirection.Input;
                p_UPDATE_BY_OP.OracleDbType = OracleDbType.Decimal;
                p_UPDATE_BY_OP.Value = p_UPDATE_BY;

                OracleParameter p_UPDATE_DATE_OP = new OracleParameter();
                p_UPDATE_DATE_OP.Direction = System.Data.ParameterDirection.Input;
                p_UPDATE_DATE_OP.OracleDbType = OracleDbType.Date;
                p_UPDATE_DATE_OP.Value = p_UPDATE_DATE;

                OracleParameter p_ID_OP = new OracleParameter();
                p_ID_OP.Direction = System.Data.ParameterDirection.Input;
                p_ID_OP.OracleDbType = OracleDbType.Decimal;
                p_ID_OP.Value = p_ID;

                OracleParameter p_CREATE_BY_OP = new OracleParameter();
                p_CREATE_BY_OP.Direction = System.Data.ParameterDirection.Input;
                p_CREATE_BY_OP.OracleDbType = OracleDbType.Decimal;
                p_CREATE_BY_OP.Value = p_CREATE_BY;

                OracleParameter p_AMOUNT_TYPEID_OP = new OracleParameter();
                p_AMOUNT_TYPEID_OP.Direction = System.Data.ParameterDirection.Input;
                p_AMOUNT_TYPEID_OP.OracleDbType = OracleDbType.Decimal;
                p_AMOUNT_TYPEID_OP.Value = p_AMOUNT_TYPEID;

                OracleParameter p_PRODUCT_FAMILYID_OP = new OracleParameter();
                p_PRODUCT_FAMILYID_OP.Direction = System.Data.ParameterDirection.Input;
                p_PRODUCT_FAMILYID_OP.OracleDbType = OracleDbType.Decimal;
                p_PRODUCT_FAMILYID_OP.Value = p_PRODUCT_FAMILYID;

                OracleParameter p_CREATE_DATE_OP = new OracleParameter();
                p_CREATE_DATE_OP.Direction = System.Data.ParameterDirection.Input;
                p_CREATE_DATE_OP.OracleDbType = OracleDbType.Date;
                p_CREATE_DATE_OP.Value = p_CREATE_DATE;

                OracleParameter p_DOWNLOAD_DATE_OP = new OracleParameter();
                p_DOWNLOAD_DATE_OP.Direction = System.Data.ParameterDirection.Input;
                p_DOWNLOAD_DATE_OP.OracleDbType = OracleDbType.Date;
                p_DOWNLOAD_DATE_OP.Value = p_DOWNLOAD_DATE;

                OracleParameter p_ISACTIVE_OP = new OracleParameter();
                p_ISACTIVE_OP.Direction = System.Data.ParameterDirection.Input;
                p_ISACTIVE_OP.OracleDbType = OracleDbType.Decimal;
                p_ISACTIVE_OP.Value = p_ISACTIVE;

                OracleParameter p_FROM_DATE_OP = new OracleParameter();
                p_FROM_DATE_OP.Direction = System.Data.ParameterDirection.Input;
                p_FROM_DATE_OP.OracleDbType = OracleDbType.Date;
                p_FROM_DATE_OP.Value = p_FROM_DATE;

                OracleParameter p_CHANNELID_OP = new OracleParameter();
                p_CHANNELID_OP.Direction = System.Data.ParameterDirection.Input;
                p_CHANNELID_OP.OracleDbType = OracleDbType.Decimal;
                p_CHANNELID_OP.Value = p_CHANNELID;

                OracleParameter p_COMMISSIONID_OP = new OracleParameter();
                p_COMMISSIONID_OP.Direction = System.Data.ParameterDirection.Input;
                p_COMMISSIONID_OP.OracleDbType = OracleDbType.Decimal;
                p_COMMISSIONID_OP.Value = p_COMMISSIONID;

                OracleParameter p_FILE_NAME_OP = new OracleParameter();
                p_FILE_NAME_OP.Direction = System.Data.ParameterDirection.Input;
                p_FILE_NAME_OP.OracleDbType = OracleDbType.NVarchar2;
                p_FILE_NAME_OP.Value = p_FILE_NAME;

                OracleParameter OutTargetExeclIdOP = new OracleParameter();
                OutTargetExeclIdOP.Direction = System.Data.ParameterDirection.Output;
                OutTargetExeclIdOP.OracleDbType = OracleDbType.Decimal;

                return ObjectMakerFromOracleSP.OracleHelper<SP_IU_TARGET_EXCELFILEcls>.InsertDataBySP(
                   "SP_IU_TARGET_EXCELFILE", OutTargetExeclIdOP, p_UPLOAD_DATE_OP, p_FILE_LOCATION_OP, p_TARGET_AMOUNT_OP, p_TO_DATE_OP, p_UPDATE_BY_OP, p_UPDATE_DATE_OP,
                   p_ID_OP, p_CREATE_BY_OP, p_AMOUNT_TYPEID_OP, p_PRODUCT_FAMILYID_OP, p_CREATE_DATE_OP, p_DOWNLOAD_DATE_OP, p_ISACTIVE_OP, p_FROM_DATE_OP, p_CHANNELID_OP, p_COMMISSIONID_OP, p_FILE_NAME_OP);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GET_TARGET_EXCELFILEcls> GetAllTargetExeclFile(decimal inTargetExcelID, decimal inChannelID, decimal inProductFamilyID, decimal inTargetAmountTypeID, DateTime inFromUploadDate,
            DateTime inToUploadDate, decimal inTargetNameID, decimal inCurrentPage)
        {
            try
            {
                OracleParameter targetExcelID_OP = new OracleParameter();
                targetExcelID_OP.Direction = System.Data.ParameterDirection.Input;
                targetExcelID_OP.OracleDbType = OracleDbType.Decimal;
                targetExcelID_OP.Value = inTargetExcelID;

                OracleParameter inChannelID_OP = new OracleParameter();
                inChannelID_OP.Direction = System.Data.ParameterDirection.Input;
                inChannelID_OP.OracleDbType = OracleDbType.Decimal;
                inChannelID_OP.Value = inChannelID;

                OracleParameter inProductFamilyID_OP = new OracleParameter();
                inProductFamilyID_OP.Direction = System.Data.ParameterDirection.Input;
                inProductFamilyID_OP.OracleDbType = OracleDbType.Decimal;
                inProductFamilyID_OP.Value = inProductFamilyID;

                OracleParameter inTargetAmountTypeID_OP = new OracleParameter();
                inTargetAmountTypeID_OP.Direction = System.Data.ParameterDirection.Input;
                inTargetAmountTypeID_OP.OracleDbType = OracleDbType.Decimal;
                inTargetAmountTypeID_OP.Value = inTargetAmountTypeID;

                OracleParameter inFromUploadDateOP = new OracleParameter();
                inFromUploadDateOP.Direction = System.Data.ParameterDirection.Input;
                inFromUploadDateOP.OracleDbType = OracleDbType.NVarchar2;
                inFromUploadDateOP.Value = inFromUploadDate == DateTime.MinValue ? string.Empty : inFromUploadDate.ToString("dd-MMM-yyyy");

                OracleParameter inToUploadDateOP = new OracleParameter();
                inToUploadDateOP.Direction = System.Data.ParameterDirection.Input;
                inToUploadDateOP.OracleDbType = OracleDbType.NVarchar2;
                inToUploadDateOP.Value = inToUploadDate == DateTime.MinValue ? string.Empty : inToUploadDate.ToString("dd-MMM-yyyy"); ;

                OracleParameter inTargetNameID_OP = new OracleParameter();
                inTargetNameID_OP.Direction = System.Data.ParameterDirection.Input;
                inTargetNameID_OP.OracleDbType = OracleDbType.Decimal;
                inTargetNameID_OP.Value = inTargetNameID;

                OracleParameter inCurrentPage_OP = new OracleParameter();
                inCurrentPage_OP.Direction = System.Data.ParameterDirection.Input;
                inCurrentPage_OP.OracleDbType = OracleDbType.Decimal;
                inCurrentPage_OP.Value = inCurrentPage;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_TARGET_EXCELFILEcls>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_TARGET_EXCELFILEcls>.GetDataBySP(new SP_GET_TARGET_EXCELFILEcls(), "SP_GET_TARGET_EXCELFILE", 21, resultOutCurSor, targetExcelID_OP, inChannelID_OP, inProductFamilyID_OP ,  inTargetAmountTypeID_OP,  inFromUploadDateOP,
                 inToUploadDateOP,  inTargetNameID_OP,  inCurrentPage_OP);

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}