using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;


namespace APL.BL.SFTS.ShelterZone
{
    public class EnumCollection
    {
        public EnumCollection()
        {
        }

        public enum PageCategory
        {
            Admin = 1,
            General_Setup

        }
        public enum Sex
        {
            Male = 1,
            Female = 2
        }


        public enum ListItemType
        {
            Distributor = 1,
            Route = 2,
            RSO = 3,
            Retailer = 4,
            None = 10
        }

        public enum BooleanString
        {
            True = 1,
            False = 2
        }

        public enum OperationName
        {
            AddNewData = 1,
            UpdateData = 2,
            DeleteData = 3,
            CancelData = 4
        }

        public enum ButtonDisplayText
        {
            Save = 1,
            Update = 2,
            Delete = 3,
            Cancel = 4
        }

        public enum ActiveInactiveEnum
        {
            Inactive = 0,
            Active = 1
        }
        public enum PendingApproveEnum
        {
            Pending = 0,
            Approve = 1
        }
        public enum OperationNameEnum
        {
            Banglalink = 1,
            GrameenPhone = 2,
            Airtel = 3,
            Robi = 4,
            Teletalk = 5
        }

        public enum NoticeTypeEnum
        {
            Notification = 1,
            Out_Of_Stock = 2,
            Survey = 3,
            SalesCallSummary = 4
        }

        public enum TargetAmountTypeEnum
        {
            Communicated = 1,
            Revised = 2
            //Budgeted = 3,
            //FinalBudgeted = 4
        }
    }

    public class EnumHelper
    {
        public EnumHelper()
        { }

        public static ListItemCollection EnumToList<T>()
        {
            ListItemCollection lists = new ListItemCollection();
            foreach (string item in Enum.GetNames(typeof(T)))
            {
                int value = (int)Enum.Parse(typeof(T), item);
                item.Replace('_', ' ');
                ListItem listItem = new ListItem(item.Replace('_', ' '), value.ToString());

                lists.Add(listItem);

            }
            return lists;
        }

        public static IList<ListItem> EnumToListWithSelect<T>()
        {
            IList<ListItem> lists = new List<ListItem>();
            lists.Add(new ListItem { Text = "Select", Value = "0" });
            foreach (string item in Enum.GetNames(typeof(T)))
            {
                int valueEnum = (int)Enum.Parse(typeof(T), item);
                item.Replace('_', ' ');
                lists.Add(new ListItem { Text = item.Replace('_', ' '), Value = valueEnum.ToString() });
            }
            return lists;
        }

        public static string EnumToString<T>(int value)
        {
            ListItemCollection lists = EnumToList<T>();
            return lists.FindByValue(value.ToString()).Text;
        }
        public static string EnumToString<T>(T value)
        {
            ListItemCollection lists = EnumToList<T>();
            return lists.FindByValue(value.ToString()).Text;
        }

        public static string EnumToString<T1>(long p)
        {
            throw new NotImplementedException();
        }
    }

}
