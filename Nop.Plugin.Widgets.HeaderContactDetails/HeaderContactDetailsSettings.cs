using Nop.Core.Configuration;

namespace Nop.Plugin.Widgets.HeaderContactDetails
{
    public class HeaderContactDetailsSettings : ISettings
    {
        public string PhoneNumberUrl { get; set; }

        public string PhoneNumberDisplayText { get; set; }

        public string WhatsAppNumberUrl { get; set; }

        public string WhatsAppNumberDisplayText { get; set; }

        public string EmailAddressUrl { get; set; }

        public string EmailAddressDisplayText { get; set; }
    }
}