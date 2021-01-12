using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace BackLog.Authorization
{
	public class BackLogAuthorizationProvider : AuthorizationProvider
	{
		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			context.CreatePermission(PermissionNames.Pages_MothlyClosingDate, L("MothlyClosingDate"));
			context.CreatePermission(PermissionNames.Pages_EditProjectBackLog, L("EditProjectBacklog")).CreateChildPermission(PermissionNames.Pages_EditProjectBackLog_EditAndDone, L("EditandDone")).CreateChildPermission(PermissionNames.Pages_EditProjectBackLog_Reject, L("Reject")).CreateChildPermission(PermissionNames.Pages_EditProjectBackLog_BackLog, L("Backlog")).CreateChildPermission(PermissionNames.Pages_EditProjectBackLog_Pipeline, L("Pipeline")).CreateChildPermission(PermissionNames.Pages_EditProjectBackLog_ToExcel, L("ToExcel")).CreateChildPermission(PermissionNames.Pages_EditProjectBackLog_Variance, L("Variance"));
			context.CreatePermission(PermissionNames.Pages_BackLogSummary, L("BacklogSummary"));
            context.CreatePermission(PermissionNames.Pages_Client, L("Client")).CreateChildPermission(PermissionNames.Pages_Client_CreateAndSearch, L("CreateAndSearch"));
			context.CreatePermission(PermissionNames.Pages_Project, L("Project")).CreateChildPermission(PermissionNames.Pages_Project_DMAndBRM, L("DMAndBRM"));
			context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
			context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_BacklogReport, L("BacklogReport"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
		}

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, BackLogConsts.LocalizationSourceName);
		}
	}
}
