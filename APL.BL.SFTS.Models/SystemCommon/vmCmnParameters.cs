using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL.BL.SFTS.Models.SystemCommon
{
	public class vmCmnParameters
	{
		public int pageNumber { get; set; }
		public int pageSize { get; set; }
		public int? IsPaging { get; set; }
		public long Id { get; set; }
		public int loggeduser { get; set; }
		public int loggedCompany { get; set; }
		public int? selectedCompany { get; set; }
		public int MenuId { get; set; }
		public int MenuGroupId { get; set; }
		public bool? IsTrue { get; set; }
		public int? UserType { get; set; }
		public DateTime? FromDate { get; set; }
		public DateTime? ToDate { get; set; }
		public long id { get; set; }
		public string label { get; set; }

		//Necessary Id
		public decimal DistributorID { get; set; }
		public decimal RouteID { get; set; }
		public decimal SurveyQuestionId { get; set; }
		public decimal SurveyAnswerId { get; set; }
		public decimal SurveyId { get; set; }
		public decimal TargetItemId { get; set; }
		public decimal TargetPeriodId { get; set; }
		public decimal QuestionnaireId { get; set; }
		public decimal QuestionId { get; set; }
		public decimal VisitTypeId { get; set; }
		public decimal CenterTypeId { get; set; }
		public decimal RoleId { get; set; }
		public decimal CurrentOfferId { get; set; }
		public decimal PictureId { get; set; }
		public decimal CommissionId { get; set; }
		public decimal ChannelTypeId { get; set; }
		public decimal EntityTypeId { get; set; }
		public decimal RegionId { get; set; }
		public decimal MonthId { get; set; }
		public decimal TargetId { get; set; }
		public decimal RetailerModifyId { get; set; }
		public decimal TerritoryId { get; set; }
		public decimal RetailerId { get; set; }
		public decimal RsoId { get; set; }
		public decimal UploadCode { get; set; }
		public DateTime Date { get; set; }
		public decimal Version { get; set; }
		public decimal TargetFor { get; set; }
		public decimal StaffTypeId { get; set; }
		public string TargetForCode { get; set; }
		public decimal VisitId { get; set; }
		public decimal AmbmId { get; set; }
		public string Comments { get; set; }
		public decimal ZoneId { get; set; }
		public decimal MarketUpdateId { get; set; }
		public decimal RetailerBestPracticeId { get; set; }
		public decimal BestPracticesRsoId { get; set; }
		public decimal ComplainId { get; set; }
		public decimal ComplainTypeId { get; set; }
		public string PermissionCode { get; set; }
		public decimal UserId { get; set; }
		public decimal ClusterId { get; set; }
		public decimal IsRegionalUser { get; set; }
		public decimal IsZonalUser { get; set; }
		public decimal EventId { get; set; }
		public decimal StatusId { get; set; }
		public decimal MarketUpdateTypeId { get; set; }
		public decimal VisitFeedbackStatusId { get; set; }
		public decimal TradeMaterialId { get; set; }
		public decimal MessageId { get; set; }

		public decimal GraphID { get; set; }
		public decimal KPIID { get; set; }
		public decimal EV_Limit_Id { get; set; }
		public decimal Notice_Id { get; set; }
		public decimal NoticeType_Id { get; set; }
		public decimal Mapping_Id { get; set; }
		public decimal MappingFor { get; set; }
		public decimal TrainingId { get; set; }
		public decimal CriticalBalanceId { get; set; }
		public decimal PointId { get; set; }
		public decimal NoticeForId { get; set; }
		public string FDateStr { get; set; }

	}

	public class fileCmnParameters
	{
		public AuthToken HeaderToken { get; set; }
	}

	public class AuthToken
	{
		public string AuthorizedToken { get; set; }
	}

	public class RSOEarningParameters
	{
		public decimal uploadId { get; set; }
		public decimal monthID { get; set; }
		public decimal periodtypeID { get; set; }
		public decimal periodID { get; set; }
		public decimal typeID { get; set; }
	}

}
