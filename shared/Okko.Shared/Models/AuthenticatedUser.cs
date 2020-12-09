using Okko.Shared.Data;
using Okko.Shared.Enums;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;


namespace Okko.Shared.Models
{
    public class AuthenticatedUser : BaseEntity
    {
        [Required]
        [StringLength(10, ErrorMessage = "user name is too long.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "The password is required!!!")]
        public string Password { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        public GenderTypeEnum GenderType { get; set; }

        public bool IsUserItemsPropertyLoaded { get; set; } = false;

        public ObservableCollection<BaseItem> UserItems
        {
            get => _userItems;
            set => SetProperty(ref _userItems, value);
        }
        private ObservableCollection<BaseItem> _userItems = new ObservableCollection<BaseItem>();

        public string Token { get; set; }

        public override string ToString()
        {
            var salutation = string.Empty;
            if (GenderType == GenderTypeEnum.Male)
            {
                salutation = "Mr";
            }

            if (GenderType == GenderTypeEnum.Female)
            {
                salutation = "Mrs";
            }

            return $"{salutation}. {FirstName} {LastName}";
        }

    }
}

