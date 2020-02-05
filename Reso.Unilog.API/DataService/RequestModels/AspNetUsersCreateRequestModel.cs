using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataService.RequestModels
{
    public  class AuthorizeRegisterModel: AccountCreateRequestModel
    {
        // Summary:
        //     This API supports the ASP.NET Core Identity default UI infrastructure and is
        //     not intended to be used directly from your code. This API may change or be removed
        //     in future releases.

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Required")]
        [JsonProperty("password")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        public  string Password { get; set; }

        // Summary:
        //     This API supports the ASP.NET Core Identity default UI infrastructure and is
        //     not intended to be used directly from your code. This API may change or be removed
        //     in future releases.
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        [DataType(DataType.Password)]
        [JsonProperty("confirm_password")]
        public  string ConfirmPassword { get; set; }

        [JsonProperty("is_admin")]
        public  bool IsAdmin { get; set; }        
    }

    public  class AspNetUsersCreateRequestModel: CreateRequestModel
    {        
        [JsonProperty("name")]
        public  string Name { get; set; }
        [JsonProperty("email")]
        public  string Email { get; set; }
        [JsonProperty("password")]
        public  string PasswordHash { get; set; }

        private string normalizedUserName;
        [JsonIgnore]
        public  string NormalizedUserName { get => normalizedUserName; set => normalizedUserName = Name.ToUpper(); }       

        private string normalizedEmail;
        [JsonIgnore]
        public  string NormalizedEmail { get => normalizedEmail; set => normalizedEmail = Email.ToUpper(); }

        [JsonIgnore]
        public  bool EmailConfirmed { get; set; } = false;
        [JsonIgnore]
        public  string SecurityStamp { get; set; } = Guid.NewGuid().ToString();
        [JsonIgnore]
        public  string ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();
        [JsonProperty("phone_number")]
        public  string PhoneNumber { get; set; }
        [JsonIgnore]
        public  bool PhoneNumberConfirmed { get; set; } = false;
        [JsonIgnore]
        public  bool TwoFactorEnabled { get; set; } = false;
        [JsonIgnore]
        public  bool LockoutEnabled { get; set; } = true;
        [JsonIgnore]
        public  int AccessFailedCount { get; set; } = 0;
        
    }
}
