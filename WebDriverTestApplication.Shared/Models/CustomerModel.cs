using WebDriverTestApplication.Shared.Constants;
using WebDriverTestApplication.Shared.Resources;
using System.ComponentModel.DataAnnotations;

namespace WebDriverTestApplication.Shared.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }

        [Display(ResourceType = typeof(Labels), Name = nameof(Labels.Name))]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = nameof(Messages.FieldRequired))]
        [MaxLength(250, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = nameof(Messages.MaxLength))]
        public string Name { get; set; }

        [Display(ResourceType = typeof(Labels), Name = nameof(Labels.EmailAddress))]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = nameof(Messages.FieldRequired))]
        [MaxLength(250, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = nameof(Messages.MaxLength))]
        [RegularExpression(RegularExpressions.EmailRegularExpression, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = nameof(Messages.InvalidEmailAddress))]
        public string EmailAddress { get; set; }

        [Display(ResourceType = typeof(Labels), Name = nameof(Labels.PhoneNumber))]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = nameof(Messages.FieldRequired))]
        [MaxLength(20, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = nameof(Messages.MaxLength))]
        [RegularExpression(RegularExpressions.DutchPhoneNumberRegularExpression, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = nameof(Messages.InvalidPhonenumber))]
        public string PhoneNumber { get; set; }
    }
}
