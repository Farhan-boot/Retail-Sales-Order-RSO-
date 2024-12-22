using APL.BL.SFTS.DataBridgeZone.ApiMobileModel;
using APL.BL.SFTS.DataBridgeZone.SP_Class;
 using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.DataBridgeZone.Target
{
    public  class AchievementPointDZ
    {
        public AchievementPointDZ()
        { }

        public List<SP_GET_ACHIEVE_POINT> GetAchievementPoints(decimal PointId, decimal UserId)
        {
            try
            {
                OracleParameter PointId_OP = new OracleParameter();
                PointId_OP.Direction = System.Data.ParameterDirection.Input;
                PointId_OP.OracleDbType = OracleDbType.Decimal;
                PointId_OP.Value = PointId;

                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = System.Data.ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Decimal;
                UserId_OP.Value = UserId;

                OracleParameter resultOutCurSor = new OracleParameter();
                resultOutCurSor.Direction = System.Data.ParameterDirection.Output;
                resultOutCurSor.OracleDbType = OracleDbType.RefCursor;

                return (List<SP_GET_ACHIEVE_POINT>)ObjectMakerFromOracleSP.OracleHelper<SP_GET_ACHIEVE_POINT>.GetDataBySP(new SP_GET_ACHIEVE_POINT(), "SP_GET_ACHIEVE_POINT", 5, resultOutCurSor, PointId_OP, UserId_OP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Decimal SaveAchievementPoint(AchievementPoint point, decimal UserId)
        {
            try
            {
                OracleParameter ActionFlag_OP = new OracleParameter();
                ActionFlag_OP.Direction = System.Data.ParameterDirection.Input;
                ActionFlag_OP.OracleDbType = OracleDbType.Decimal;
                ActionFlag_OP.Value = point.ActionFlag;

                OracleParameter PointId_OP = new OracleParameter();
                PointId_OP.Direction = System.Data.ParameterDirection.Input;
                PointId_OP.OracleDbType = OracleDbType.Decimal;
                PointId_OP.Value = point.PointId;

                OracleParameter PointName_OP = new OracleParameter();
                PointName_OP.Direction = System.Data.ParameterDirection.Input;
                PointName_OP.OracleDbType = OracleDbType.NVarchar2;
                PointName_OP.Value = point.PointName;

                OracleParameter PointCode_OP = new OracleParameter();
                PointCode_OP.Direction = System.Data.ParameterDirection.Input;
                PointCode_OP.OracleDbType = OracleDbType.NVarchar2;
                PointCode_OP.Value = point.PointCode;

                OracleParameter PointScore_OP = new OracleParameter();
                PointScore_OP.Direction = System.Data.ParameterDirection.Input;
                PointScore_OP.OracleDbType = OracleDbType.Decimal;
                PointScore_OP.Value = point.PointScore;

                OracleParameter IsActive_OP = new OracleParameter();
                IsActive_OP.Direction = System.Data.ParameterDirection.Input;
                IsActive_OP.OracleDbType = OracleDbType.Decimal;
                IsActive_OP.Value = point.IsActive;

                OracleParameter UserId_OP = new OracleParameter();
                UserId_OP.Direction = System.Data.ParameterDirection.Input;
                UserId_OP.OracleDbType = OracleDbType.Decimal;
                UserId_OP.Value = UserId;

                OracleParameter resultOutID = new OracleParameter();
                resultOutID.Direction = System.Data.ParameterDirection.Output;
                resultOutID.OracleDbType = OracleDbType.Decimal;


                return ObjectMakerFromOracleSP.OracleHelper<SP_GET_ACHIEVE_POINT>.InsertDataBySP("SP_SAVE_ACHIEVE_POINT", resultOutID, ActionFlag_OP, PointId_OP, PointName_OP, PointCode_OP,PointScore_OP, IsActive_OP, UserId_OP);
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


                return ObjectMakerFromOracleSP.OracleHelper<SP_INS_UPD_SURVEY_DETAIL_Q_ANScls>.InsertDataBySP("SP_FF_DELETE_ACHIVE_POINT", resultOutID, trainingId_OP);            
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
