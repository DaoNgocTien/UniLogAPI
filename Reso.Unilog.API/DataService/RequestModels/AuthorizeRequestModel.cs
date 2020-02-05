using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataService.RequestModels
{
    public  class AuthorizeLoginModel
    {
        //
        // Summary:
        //     This API supports the ASP.NET Core Identity default UI infrastructure and is
        //     not intended to be used directly from your code. This API may change or be removed
        //     in future releases.
        [EmailAddress]
        [Required(ErrorMessage = "Required")]
        public  string Email { get; set; }
        //
        // Summary:
        //     This API supports the ASP.NET Core Identity default UI infrastructure and is
        //     not intended to be used directly from your code. This API may change or be removed
        //     in future releases.
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Required")]
        public  string Password { get; set; }
    }

    public  class LoginResponseModel
    {
        public  int Id { get; set; }
        public  String Token { get; set; }
        public  int Role { get; set; }
        public  String Email { get; set; }
    }

    //        public  class AuthorizeRegisterModel 
    //    {
    //        //
    //        // Summary:
    //        //     This API supports the ASP.NET Core Identity default UI infrastructure and is
    //        //     not intended to be used directly from your code. This API may change or be removed
    //        //     in future releases.
    //        [EmailAddress]
    //        [Required(ErrorMessage = "Required")]
    //        [JsonProperty("email")]
    //        public  string Email { get; set; }
    //        //
    //        // Summary:
    //        //     This API supports the ASP.NET Core Identity default UI infrastructure and is
    //        //     not intended to be used directly from your code. This API may change or be removed
    //        //     in future releases.

    //        [DataType(DataType.Password)]
    //        [Required(ErrorMessage = "Required")]
    //        [JsonProperty("password")]
    //        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
    //        public  string Password { get; set; }

    //        // Summary:
    //        //     This API supports the ASP.NET Core Identity default UI infrastructure and is
    //        //     not intended to be used directly from your code. This API may change or be removed
    //        //     in future releases.
    //        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    //        [DataType(DataType.Password)]
    //        public  string ConfirmPassword { get; set; }

    //        [JsonProperty("is_admin")]
    //        public  bool IsAdmin { get; set; }

    //        //  Default: token_v2_7/2019
    //        [JsonProperty("admin_registration_token")]
    //        public  string AdminRegistrationToken { get; set; }

    //        [JsonIgnore]
    //        [JsonProperty("role_names")]
    //        public  List<string> RoleNames { get; set; }
    //    }

    public  class AuthorizeTokenModel
{
    [JsonProperty("id")]
    public  int Id { get; set; }
    [JsonProperty("token")]
    public  string Token { get; set; }
    [JsonProperty("valid_to")]
    public  DateTime ValidTo { get; set; }
    [JsonProperty("valid_from")]
    public  DateTime ValidFrom { get; set; }
    [JsonProperty("email")]
    public  string Email { get; set; }
    [JsonProperty("roles")]
    public  List<string> Roles { get; set; }
}
}
