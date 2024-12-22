using APL.BL.SFTS.DataBridgeZone;
using APL.BL.SFTS.DataBridgeZone.Target;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.ProcessZone.Target
{
    public class TargetItemPZ
    {
        public TargetItemPZ()
        {
        }

        public List<SP_GET_ENTITY_TYPE> GetEntityTypes(decimal EntityTypeId)
        {
            try
            {
                List<SP_GET_ENTITY_TYPE> EntityTypes = new List<SP_GET_ENTITY_TYPE>() {
                    new SP_GET_ENTITY_TYPE() { ENTITY_TYPE_ID = 1, ENTITY_TYPE_NAME = "STAFF" },
                    new SP_GET_ENTITY_TYPE() { ENTITY_TYPE_ID = 2, ENTITY_TYPE_NAME = "DISTRIBUTORS"},
                    new SP_GET_ENTITY_TYPE() { ENTITY_TYPE_ID = 3, ENTITY_TYPE_NAME = "CENTER/SHOP"}
                };
                
                if(EntityTypeId > 0) { EntityTypes = EntityTypes.Where(x => x.ENTITY_TYPE_ID == EntityTypeId).ToList(); };
                     
                return EntityTypes;
            }
            catch (Exception)
            {
                throw;
            }
        }




        public decimal SaveUpdateTargetItem(decimal TargetItemId, string Code, string Name, decimal IsActive, string UnitName)
        {
            try
            {
                return new TargetItemDZ().SaveUpdateTargetItem(TargetItemId, Code, Name, IsActive, UnitName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public decimal SaveUpdateTargetItemApplyTo(decimal TargetItemApplyToId, decimal TargetItemId, decimal ChannelTypeId, decimal TargetEntityType, decimal? StaffTypeId, decimal? CenterTypeId, decimal DistributorIsSumOfStaff, decimal StaffIsSumOfCenter, decimal IsActive)
        {
            try
            {
                return new TargetItemDZ().SaveUpdateTargetItemApplyTo(TargetItemApplyToId, TargetItemId, ChannelTypeId, TargetEntityType, StaffTypeId, CenterTypeId, DistributorIsSumOfStaff, StaffIsSumOfCenter, IsActive);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GET_TARGET_ITEM> GetTargetItems(decimal TargetItemId,decimal UserId)
        {
            try
            {
                return new TargetItemDZ().GetTargetItems(TargetItemId, UserId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<GET_TARGET_ITEM_APPLY_TO> GetTargetItemApplyTo(decimal TargetItemApplyId,decimal TargetItemId)
        {
            try
            {
                  return new TargetItemDZ().GetTargetItemApplyTo(TargetItemApplyId, TargetItemId);

            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
