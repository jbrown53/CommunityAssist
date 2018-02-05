using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityAssist.Models
{
    public class NewPerson
    {
        public string PersonLastName { get; set; }
        public string PersonFirstName { get; set; }
        public string PersonEmail { get; set; }
        public string PersonPrimaryPhone { get; set; }
        public string PersonPassword { get; set; }
        public string PersonAddressApt { get; set; }
        public string PersonAddressStreet { get; set; }
        public string PersonAddressCity { get; set; }
        public string PersonAddressState { get; set; }
        public string PersonAddressPostal { get; set; }
    }
}