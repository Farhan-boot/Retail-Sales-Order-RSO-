using APL.BL.SFTS.DataBridgeZone.ApiMobileModel;
using APL.BL.SFTS.DataBridgeZone.SP_Class;
using APL.BL.SFTS.DataBridgeZone.Training;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.ProcessZone.Training
{
    public class TrainingContentPZ
    {
        public TrainingContentPZ()
        { }

        public List<SP_GET_TRAININICONTENT_WEB> GetTrainingContents(decimal TrainingId, decimal UserId)
        {
            List<SP_GET_TRAININICONTENT_WEB> mainMenuList = new List<SP_GET_TRAININICONTENT_WEB>();
            try
            {
                mainMenuList = new TrainingContentDZ().GetTrainingContents(TrainingId, UserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return mainMenuList;
        }
        public Decimal SaveTrainingContent(TrainingContent trainingContent, decimal UserId)
        {
            decimal result = 0;
            try
            {
                decimal IsEventSaved = 0;
                IsEventSaved = new TrainingContentDZ().SaveTrainingContent(trainingContent, UserId);
                result = IsEventSaved;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
        public decimal DeleteInfo(decimal trainingId)
        {
            try
            {
                return new TrainingContentDZ().DeleteInfo(trainingId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
