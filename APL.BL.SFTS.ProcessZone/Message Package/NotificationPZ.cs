using APL.BL.SFTS.DataBridgeZone;
using APL.BL.SFTS.DataBridgeZone.SP_Class;
using APL.BL.SFTS.ShelterZone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace APL.BL.SFTS.ProcessZone
{
	public class NotificationPZ
	{
		public NotificationPZ()
		{
		}


		/// <summary>
		/// Save or upate current offer if id is zero then save data other update by parameter values.
		/// </summary>      
		/// <returns>if save or update properly return Table ID or zero fail save or update info </returns>
		/// 
		public decimal SaveUpdateNotification(decimal Id, decimal _TYPE, string StartDate, string EndDate,
											 string _TITLE, string _DISCRIPTION, string _ISACTIVE, decimal _CREATE_BY, decimal _MODIFY_BY
											, byte[] _IMG, string _FILE, string _STRMODE, List<GET_ID> NotificationList)
		{
			decimal result = 0;
			try
			{
				result = new NotificationDZ().SaveUpdateNotification(Id, _TYPE, StartDate, EndDate, _TITLE, _DISCRIPTION, _ISACTIVE, _CREATE_BY, _MODIFY_BY, _IMG, _FILE, _STRMODE);

				/*result = new NotificationDZ().DeleteExistingCurrentOfferDist(OfferId);
				if (NotificationList.Count > 0)
				{
					foreach (var currentOfferDist in NotificationList)
					{
						new NotificationDZ().SaveUpdateCurrentOfferDistributor(OfferId, currentOfferDist.Id);
					}
				}*/

			}
			catch (Exception ex)
			{
				throw ex;
			}

			return result;
		}


		public List<SP_GET_NOTIFICATIONS> GetNotification(decimal APPID, decimal UserId, decimal RETAILERID, decimal Id, decimal TYPE, string FROMDATE, string TODATE)
		{
			try
			{
				return new NotificationDZ().GetNotification(APPID, UserId, RETAILERID, Id, TYPE, FROMDATE, TODATE);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}




	}
}
