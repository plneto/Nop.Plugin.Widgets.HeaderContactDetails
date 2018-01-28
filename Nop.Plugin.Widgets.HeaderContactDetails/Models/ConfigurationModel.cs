using Nop.Web.Framework.Mvc.ModelBinding;
using Nop.Web.Framework.Mvc.Models;

namespace Nop.Plugin.Widgets.HeaderContactDetails.Models
{
    public class ConfigurationModel : BaseNopModel
    {
        public int ActiveStoreScopeConfiguration { get; set; }
        
        [NopResourceDisplayName("Plugins.Widgets.HeaderContactDetails.PhoneNumberUrl")]
        public string PhoneNumberUrl { get; set; }

        public bool PhoneNumberUrl_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.HeaderContactDetails.PhoneNumberDisplayText")]
        public string PhoneNumberDisplayText { get; set; }

        public bool PhoneNumberDisplayText_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.HeaderContactDetails.WhatsAppNumberUrl")]
        public string WhatsAppNumberUrl { get; set; }

        public bool WhatsAppNumberUrl_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.HeaderContactDetails.WhatsAppNumberDisplayText")]
        public string WhatsAppNumberDisplayText { get; set; }

        public bool WhatsAppNumberDisplayText_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.HeaderContactDetails.EmailAddressUrl")]
        public string EmailAddressUrl { get; set; }

        public bool EmailAddressUrl_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.HeaderContactDetails.EmailAddressDisplayText")]
        public string EmailAddressDisplayText { get; set; }

        public bool EmailAddressDisplayText_OverrideForStore { get; set; }
    }
}