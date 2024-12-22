using APL.BL.SFTS.DataBridgeZone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.ProcessZone.VFocus
{
	public class ApplicationLogPZ
	{

		public Decimal INSERT_APPLICATION_ACCESSLOG(decimal USERID, string APPLICATION_NAME, string MODULE_NAME, string ACTIVITY_NAME, string CHANGED_VALUE, string USER_IP, string _ACTIONTYPE)
		{
			try
			{
				return new ApplicationLogDZ().INSERT_APPLICATION_ACCESSLOG(USERID, APPLICATION_NAME, MODULE_NAME, ACTIVITY_NAME, CHANGED_VALUE, USER_IP, _ACTIONTYPE);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
