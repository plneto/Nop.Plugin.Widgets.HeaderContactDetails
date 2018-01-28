using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Plugin.Widgets.HeaderContactDetails.Models;
using Nop.Services.Configuration;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.Widgets.HeaderContactDetails.Components
{
    [ViewComponent(Name = "WidgetsHeaderContactDetails")]
    public class WidgetsHeaderContactDetailsViewComponent : NopViewComponent
    {
        private readonly IStoreContext _storeContext;
        private readonly ISettingService _settingService;

        public WidgetsHeaderContactDetailsViewComponent(
            IStoreContext storeContext, 
            ISettingService settingService)
        {
            this._storeContext = storeContext;
            this._settingService = settingService;
        }

        public IViewComponentResult Invoke(string widgetZone, object additionalData)
        {
            var headerContactDetailsSettings = _settingService.LoadSetting<HeaderContactDetailsSettings>(_storeContext.CurrentStore.Id);

            var model = new PublicInfoModel
            {
                PhoneNumberUrl = headerContactDetailsSettings.PhoneNumberUrl,
                PhoneNumberDisplayText = headerContactDetailsSettings.PhoneNumberDisplayText,
                WhatsAppNumberUrl = headerContactDetailsSettings.WhatsAppNumberUrl,
                WhatsAppNumberDisplayText = headerContactDetailsSettings.WhatsAppNumberDisplayText,
                EmailAddressUrl = headerContactDetailsSettings.EmailAddressUrl,
                EmailAddressDisplayText = headerContactDetailsSettings.EmailAddressDisplayText
            };
            
            return View("~/Plugins/Widgets.HeaderContactDetails/Views/PublicInfo.cshtml", model);
        }
    }
}
