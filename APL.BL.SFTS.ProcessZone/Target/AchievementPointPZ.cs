using APL.BL.SFTS.DataBridgeZone.ApiMobileModel;
using APL.BL.SFTS.DataBridgeZone.SP_Class;
using APL.BL.SFTS.DataBridgeZone.Target;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.ProcessZone.Target
{
    public class AchievementPointPZ
    {
        public AchievementPointPZ()
        { }

        public List<SP_GET_ACHIEVE_POINT> GetAchievementPoints(decimal PointId, decimal UserId)
        {
            List<SP_GET_ACHIEVE_POINT> mainMenuList = new List<SP_GET_ACHIEVE_POINT>();
            try
            {
                mainMenuList = new AchievementPointDZ().GetAchievementPoints(PointId, UserId);
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

        public Decimal SaveAchievementPoint(AchievementPoint point, decimal UserId)
        {
            decimal result = 0;
            try
            {
                decimal IsEventSaved = 0;
                IsEventSaved = new AchievementPointDZ().SaveAchievementPoint(point, UserId);
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
                return new AchievementPointDZ().DeleteInfo(trainingId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
