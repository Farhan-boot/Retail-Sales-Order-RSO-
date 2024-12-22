using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.Models.SFTS
{
	public class vmNotification
	{
		public Decimal notificationID { get; set; }

		public Decimal TYPEID { get; set; }

		public String FROM_DATE { get; set; }

		public String TO_DATE { get; set; }

		public String TITLE { get; set; }

		public String DISCRIPTION { get; set; }

		public String ISACTIVE { get; set; }

		public Decimal CREATE_BY { get; set; }

		public Decimal MODIFY_BY { get; set; }

		//public NOTIFICATION_IMG  { get; set; }

		public String IMAGE_LINK { get; set; }

		public Decimal RETAILERID { get; set; }


	}
}
