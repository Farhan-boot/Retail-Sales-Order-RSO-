using APL.BL.SFTS.DataBridgeZone.ApiMobileModel;
using APL.BL.SFTS.DataBridgeZone.SP_Class;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone.Training
{
    public  class TrainingContentDZ
    {
        public TrainingContentDZ()
        { }

        public List<SP_GET_TRAININICONTENT_WEB> GetTrainingContents(decimal TrainingId, decimal UserId)
        {
            try
            {
                OracleParameter TrainingId_OP = new OracleParameter();
                TrainingId_OP.Direction = System.Data.ParameterDirection.Input;
                TrainingId_OP.OracleDbType = OracleDbType.Decimal;
                TrainingId_OP.Value = TrainingId;

                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = System.Data.ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Decimal;
                UserId_OP.Value = UserId;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_TRAININICONTENT_WEB>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_TRAININICONTENT_WEB>.GetDataBySP(new SP_GET_TRAININICONTENT_WEB(), "SP_GET_TRAININICONTENT_WEB", 7, resultOutCurSor, TrainingId_OP, UserId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Decimal SaveTrainingContent(TrainingContent trainingContent, decimal UserId)
        {
            try
            {
                OracleParameter ActionFlag_OP = new OracleParameter();
                ActionFlag_OP.Direction = System.Data.ParameterDirection.Input;
                ActionFlag_OP.OracleDbType = OracleDbType.Decimal;
                ActionFlag_OP.Value = trainingContent.ActionFlag;

                OracleParameter TrainingId_OP = new OracleParameter();
                TrainingId_OP.Direction = System.Data.ParameterDirection.Input;
                TrainingId_OP.OracleDbType = OracleDbType.Decimal;
                TrainingId_OP.Value = trainingContent.TrainingId;

                OracleParameter ContentName_OP = new OracleParameter();
                ContentName_OP.Direction = System.Data.ParameterDirection.Input;
                ContentName_OP.OracleDbType = OracleDbType.Varchar2;
                ContentName_OP.Value = trainingContent.ContentName;

                OracleParameter TrainingName_OP = new OracleParameter();
                TrainingName_OP.Direction = System.Data.ParameterDirection.Input;
                TrainingName_OP.OracleDbType = OracleDbType.Varchar2;
                TrainingName_OP.Value = trainingContent.TrainingName;

                OracleParameter UploadedDate_OP = new OracleParameter();
                UploadedDate_OP.Direction = System.Data.ParameterDirection.Input;
                UploadedDate_OP.OracleDbType = OracleDbType.Date;
                UploadedDate_OP.Value =Convert.ToDateTime(trainingContent.UploadedDate.Split('/')[2] + "/" + trainingContent.UploadedDate.Split('/')[1] + "/" + trainingContent.UploadedDate.Split('/')[0]).Date ;

                OracleParameter OtherLink_OP = new OracleParameter();
                OtherLink_OP.Direction = System.Data.ParameterDirection.Input;
                OtherLink_OP.OracleDbType = OracleDbType.Varchar2;
                OtherLink_OP.Value = trainingContent.OtherLink;

                OracleParameter UploadedFileLink_OP = new OracleParameter();
                UploadedFileLink_OP.Direction = System.Data.ParameterDirection.Input;
                UploadedFileLink_OP.OracleDbType = OracleDbType.Varchar2;
                UploadedFileLink_OP.Value = trainingContent.UploadedFileLink;


                OracleParameter IsActive_OP = new OracleParameter();
                IsActive_OP.Direction = System.Data.ParameterDirection.Input;
                IsActive_OP.OracleDbType = OracleDbType.Decimal;
                IsActive_OP.Value = trainingContent.IsActive;

                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = System.Data.ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Decimal;
                UserId_OP.Value = UserId;

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;


                return ObjectMakerFromOracleSP.OracleHelper<SP_GET_MENUGROUP_WEB>.InsertDataBySP("SP_SAVE_TRAININICONTENT_WEB", resultOutID, ActionFlag_OP, TrainingId_OP, ContentName_OP, TrainingName_OP, UploadedDate_OP, OtherLink_OP, UploadedFileLink_OP, IsActive_OP, UserId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public decimal DeleteInfo(decimal trainingId)
        {
            try
            {
                OracleParameter trainingId_OP = new OracleParameter();
                trainingId_OP.Direction = System.Data.ParameterDirection.Input;
                trainingId_OP.OracleDbType = OracleDbType.Decimal;
                trainingId_OP.Value = trainingId;

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;


                return ObjectMakerFromOracleSP.OracleHelper<SP_INS_UPD_SURVEY_DETAIL_Q_ANScls>.InsertDataBySP("SP_FF_DELETE_TRAININT_CONTENT", resultOutID, trainingId_OP);             //SP_FF_DELETE_TRAININT_CONTENT
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
