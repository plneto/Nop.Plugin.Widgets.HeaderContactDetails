using System.Collections.Generic;
using Nop.Core;
using Nop.Core.Plugins;
using Nop.Services.Cms;
using Nop.Services.Configuration;
using Nop.Services.Localization;

namespace Nop.Plugin.Widgets.HeaderContactDetails
{
    public class HeaderContactDetailsPlugin : BasePlugin, IWidgetPlugin
    {
        private readonly IWebHelper _webHelper;
        private readonly ISettingService _settingService;

        public HeaderContactDetailsPlugin(
            IWebHelper webHelper,
            ISettingService settingService)
        {
            _webHelper = webHelper;
            _settingService = settingService;
        }

        /// <summary>
        /// Gets widget zones where this widget should be rendered
        /// </summary>
        /// <returns>Widget zones</returns>
        public IList<string> GetWidgetZones()
        {
            return new List<string> { "header_selectors" };
        }

        /// <summary>
        /// Gets a view component for displaying plugin in public store
        /// </summary>
        /// <param name="widgetZone">Name of the widget zone</param>
        /// <param name="viewComponentName">View component name</param>
        public void GetPublicViewComponent(string widgetZone, out string viewComponentName)
        {
            viewComponentName = "WidgetsHeaderContactDetails";
        }

        /// <summary>
        /// Gets a configuration page URL
        /// </summary>
        public override string GetConfigurationPageUrl()
        {
            return _webHelper.GetStoreLocation() + "Admin/WidgetsHeaderContactDetails/Configure";
        }

        /// <summary>
        /// Install plugin
        /// </summary>
        public override void Install()
        {
            var settings = new HeaderContactDetailsSettings
            {
                PhoneNumberUrl = "tel:10099991111",
                PhoneNumberDisplayText = "(100) 9999-1111",
                WhatsAppNumberUrl = "https://api.whatsapp.com/send?phone=110077773333",
                WhatsAppNumberDisplayText = "(100) 7777-3333",
                EmailAddressUrl = "mailto:email@test.com",
                EmailAddressDisplayText = "email@test.com"
            };

            _settingService.SaveSetting(settings);


            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.HeaderContactDetails.ContactDetails", "Contact Details");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.HeaderContactDetails.PhoneNumber", "Phone:");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.HeaderContactDetails.PhoneNumberUrl", "Phone number URL");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.HeaderContactDetails.PhoneNumberDisplayText", "Phone number display text");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.HeaderContactDetails.WhatsAppNumber", "WhatsApp:");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.HeaderContactDetails.WhatsAppNumberUrl", "WhatsApp number URL");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.HeaderContactDetails.WhatsAppNumberDisplayText", "WhatsApp display text");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.HeaderContactDetails.EmailAddress", "Email:");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.HeaderContactDetails.EmailAddressUrl", "Email address URL");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.HeaderContactDetails.EmailAddressDisplayText", "Email address display text");

            base.Install();
        }

        /// <summary>
        /// Uninstall plugin
        /// </summary>
        public override void Uninstall()
        {
            //settings
            _settingService.DeleteSetting<HeaderContactDetailsSettings>();

            //locales
            this.DeletePluginLocaleResource("Plugins.Widgets.HeaderContactDetails.ContactDetails");
            this.DeletePluginLocaleResource("Plugins.Widgets.HeaderContactDetails.PhoneNumber");
            this.DeletePluginLocaleResource("Plugins.Widgets.HeaderContactDetails.PhoneNumberUrl");
            this.DeletePluginLocaleResource("Plugins.Widgets.HeaderContactDetails.PhoneNumberDisplayText");
            this.DeletePluginLocaleResource("Plugins.Widgets.HeaderContactDetails.WhatsAppNumber");
            this.DeletePluginLocaleResource("Plugins.Widgets.HeaderContactDetails.WhatsAppNumberUrl");
            this.DeletePluginLocaleResource("Plugins.Widgets.HeaderContactDetails.WhatsAppNumberDisplayText");
            this.DeletePluginLocaleResource("Plugins.Widgets.HeaderContactDetails.EmailAddress");
            this.DeletePluginLocaleResource("Plugins.Widgets.HeaderContactDetails.EmailAddressUrl");
            this.DeletePluginLocaleResource("Plugins.Widgets.HeaderContactDetails.EmailAddressDisplayText");

            base.Uninstall();
        }
    }
}
