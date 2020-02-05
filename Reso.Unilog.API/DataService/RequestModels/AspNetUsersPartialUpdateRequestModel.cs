using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataService.RequestModels
{
    public  class PasswordModel
    {
        [Required(ErrorMessage = "Required")]
        [JsonProperty("email")]
        [DataType(DataType.EmailAddress)]
        public  string Email { get; set; }

        [DataType(DataType.Password)]
        [JsonProperty("current_password")]
        public  string CurrentPassword { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Required")]
        [JsonProperty("new_password")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        public  string NewPassword { get; set; }


        [Compare("NewPassword", ErrorMessage = "The password and confirmation password do not match.")]
        [DataType(DataType.Password)]
        [JsonProperty("confirm_password")]
        public  string ConfirmPassword { get; set; }

        [JsonProperty("token")]
        public  string Token { get; set; }
    }
    public  class AspNetUsersPartialUpdateRequestModel
    {
        [Required(ErrorMessage = "Required")]
        [JsonProperty("email")]
        [DataType(DataType.EmailAddress)]
        public  string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Required")]
        [JsonProperty("new_password")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        public  string NewPassword { get; set; }

        [JsonProperty("current_password")]
        [Required(ErrorMessage = "Required")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        public  string CurrentPassword { get; set; }
    }
}
