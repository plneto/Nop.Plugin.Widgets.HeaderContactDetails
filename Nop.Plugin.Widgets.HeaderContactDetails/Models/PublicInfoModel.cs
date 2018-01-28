using Nop.Web.Framework.Mvc.Models;

namespace Nop.Plugin.Widgets.HeaderContactDetails.Models
{
    public class PublicInfoModel : BaseNopModel
    {
        public string PhoneNumberUrl { get; set; }

        public string PhoneNumberDisplayText { get; set; }

        public string WhatsAppNumberUrl { get; set; }

        public string WhatsAppNumberDisplayText { get; set; }

        public string EmailAddressUrl { get; set; }

        public string EmailAddressDisplayText { get; set; }
    }
}