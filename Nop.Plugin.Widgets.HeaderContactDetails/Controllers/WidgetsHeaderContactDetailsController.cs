using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Plugin.Widgets.HeaderContactDetails.Models;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Security;
using Nop.Services.Stores;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;

namespace Nop.Plugin.Widgets.HeaderContactDetails.Controllers
{
    [Area(AreaNames.Admin)]
    public class WidgetsHeaderContactDetailsController : BasePluginController
    {
        private readonly IWorkContext _workContext;
        private readonly IStoreService _storeService;
        private readonly IPermissionService _permissionService;
        private readonly ISettingService _settingService;
        private readonly ILocalizationService _localizationService;

        public WidgetsHeaderContactDetailsController(IWorkContext workContext,
            IStoreService storeService,
            IPermissionService permissionService, 
            ISettingService settingService,
            ICacheManager cacheManager,
            ILocalizationService localizationService)
        {
            this._workContext = workContext;
            this._storeService = storeService;
            this._permissionService = permissionService;
            this._settingService = settingService;
            this._localizationService = localizationService;
        }

        public IActionResult Configure()
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageWidgets))
                return AccessDeniedView();

            //load settings for a chosen store scope
            var storeScope = this.GetActiveStoreScopeConfiguration(_storeService, _workContext);
            var headerContactDetailsSettings = _settingService.LoadSetting<HeaderContactDetailsSettings>(storeScope);
            var model = new ConfigurationModel
            {
                PhoneNumberUrl = headerContactDetailsSettings.PhoneNumberUrl,
                PhoneNumberDisplayText = headerContactDetailsSettings.PhoneNumberDisplayText,
                WhatsAppNumberUrl = headerContactDetailsSettings.WhatsAppNumberUrl,
                WhatsAppNumberDisplayText = headerContactDetailsSettings.WhatsAppNumberDisplayText,
                EmailAddressUrl = headerContactDetailsSettings.EmailAddressUrl,
                EmailAddressDisplayText = headerContactDetailsSettings.EmailAddressDisplayText,
                ActiveStoreScopeConfiguration = storeScope
            };

            if (storeScope > 0)
            {
                model.PhoneNumberUrl_OverrideForStore = _settingService.SettingExists(headerContactDetailsSettings, x => x.PhoneNumberUrl, storeScope);
                model.PhoneNumberDisplayText_OverrideForStore = _settingService.SettingExists(headerContactDetailsSettings, x => x.PhoneNumberDisplayText, storeScope);
                model.WhatsAppNumberUrl_OverrideForStore = _settingService.SettingExists(headerContactDetailsSettings, x => x.WhatsAppNumberUrl, storeScope);
                model.WhatsAppNumberDisplayText_OverrideForStore = _settingService.SettingExists(headerContactDetailsSettings, x => x.WhatsAppNumberDisplayText, storeScope);
                model.EmailAddressUrl_OverrideForStore = _settingService.SettingExists(headerContactDetailsSettings, x => x.EmailAddressUrl, storeScope);
                model.EmailAddressDisplayText_OverrideForStore = _settingService.SettingExists(headerContactDetailsSettings, x => x.EmailAddressDisplayText, storeScope);
            }

            return View("~/Plugins/Widgets.HeaderContactDetails/Views/Configure.cshtml", model);
        }

        [HttpPost]
        public IActionResult Configure(ConfigurationModel model)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageWidgets))
                return AccessDeniedView();

            //load settings for a chosen store scope
            var storeScope = this.GetActiveStoreScopeConfiguration(_storeService, _workContext);
            var headerContactDetailsSettings = _settingService.LoadSetting<HeaderContactDetailsSettings>(storeScope);

            headerContactDetailsSettings.PhoneNumberUrl = model.PhoneNumberUrl;
            headerContactDetailsSettings.PhoneNumberDisplayText = model.PhoneNumberDisplayText;
            headerContactDetailsSettings.WhatsAppNumberUrl = model.WhatsAppNumberUrl;
            headerContactDetailsSettings.WhatsAppNumberDisplayText = model.WhatsAppNumberDisplayText;
            headerContactDetailsSettings.EmailAddressUrl = model.EmailAddressUrl;
            headerContactDetailsSettings.EmailAddressDisplayText = model.EmailAddressDisplayText;

            /* We do not clear cache after each setting update.
             * This behavior can increase performance because cached settings will not be cleared 
             * and loaded from database after each update */
            _settingService.SaveSettingOverridablePerStore(headerContactDetailsSettings, x => x.PhoneNumberUrl, model.PhoneNumberUrl_OverrideForStore, storeScope, false);
            _settingService.SaveSettingOverridablePerStore(headerContactDetailsSettings, x => x.PhoneNumberDisplayText, model.PhoneNumberDisplayText_OverrideForStore, storeScope, false);
            _settingService.SaveSettingOverridablePerStore(headerContactDetailsSettings, x => x.WhatsAppNumberUrl, model.WhatsAppNumberUrl_OverrideForStore, storeScope, false);
            _settingService.SaveSettingOverridablePerStore(headerContactDetailsSettings, x => x.WhatsAppNumberDisplayText, model.WhatsAppNumberDisplayText_OverrideForStore, storeScope, false);
            _settingService.SaveSettingOverridablePerStore(headerContactDetailsSettings, x => x.EmailAddressUrl, model.EmailAddressUrl_OverrideForStore, storeScope, false);
            _settingService.SaveSettingOverridablePerStore(headerContactDetailsSettings, x => x.EmailAddressDisplayText, model.EmailAddressDisplayText_OverrideForStore, storeScope, false);
            
            //now clear settings cache
            _settingService.ClearCache();

            SuccessNotification(_localizationService.GetResource("Admin.Plugins.Saved"));
            return Configure();
        }
    }
}