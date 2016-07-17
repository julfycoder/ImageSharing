using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using ImageSharing.LocalResource;

namespace ImageSharing.Models
{
    public class MessagesModel
    {
        [Display(Name="EmailMessage",ResourceType=typeof(Resource))]
        public string EmailMessage { get; set; }

        [Display(Name = "FieldRequiredMessage", ResourceType = typeof(Resource))]
        public string FieldRequiredMessage { get; set; }

        [Display(Name = "MinLengthMessage", ResourceType = typeof(Resource))]
        public string MinLengthMessage { get; set; }

        [Display(Name = "AuthenticationIncorrectMessage", ResourceType = typeof(Resource))]
        public string AuthenticationIncorrectMessage { get; set; }

        [Display(Name = "NothingFound", ResourceType = typeof(Resource))]
        public string NothingFoundMessage { get; set; }

        [Display(Name = "Description", ResourceType = typeof(Resource))]
        public string Description { get; set; }

        [Display(Name = "IdentifierMessage", ResourceType = typeof(Resource))]
        public string IdentifierMessage { get; set; }

        [Display(Name = "PasswordConfirmMessage", ResourceType = typeof(Resource))]
        public string PasswordConfirmMessage { get; set; }
    }
}