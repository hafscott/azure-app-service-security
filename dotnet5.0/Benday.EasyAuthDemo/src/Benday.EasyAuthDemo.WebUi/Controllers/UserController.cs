using Benday.EasyAuthDemo.Api;
using Benday.EasyAuthDemo.WebUi.Models;

namespace Benday.EasyAuthDemo.WebUi.Controllers
{
    public partial class UserController
    {
        protected override void BeforeReturnFromEdit(int? id, UserEditorViewModel viewModel)
        {
            var claimLogicTypes = WebUiUtilities.ToSelectListItems(
                _LookupService.GetAllByType("System.UserClaim.ClaimLogicTypes"));
            var statusValues = WebUiUtilities.ToSelectListItems(
                _LookupService.GetAllByType("System.Lookup.StatusValues"));

            viewModel.Claims.OnNewTemplateItem = (newItem) =>
            {
                newItem.ClaimLogicType = ApiConstants.ClaimLogicType_Default;
                newItem.UserId = viewModel.Id;
                newItem.Username = viewModel.Username;
                newItem.ClaimLogicTypes = claimLogicTypes;
                newItem.Statuses = statusValues;
            };

            foreach(var item in viewModel.Claims)
            {
                item.ClaimLogicTypes = claimLogicTypes;
                item.Statuses = statusValues;
            }
        }        
    }
}