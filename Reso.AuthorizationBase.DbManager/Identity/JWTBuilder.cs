using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reso.AuthorizationBase.DbManager.Identity
{
    /// <summary>
    /// This class have to build the JWT Authorization to your API or Project MVC
    /// </summary>
    public static class JWTBuilder
    {
        public static void BuildJWTService(IServiceCollection services)
        {

            //Authentication Schema
            const string scheme = JwtBearerDefaults.AuthenticationScheme;

            // Add authentication
            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = scheme;
                    options.DefaultChallengeScheme = scheme;
                    options.DefaultScheme = scheme;
                })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidAudience = ResoJWTValidators.AUDIENCE,
                        ValidIssuer = ResoJWTValidators.ISSUER,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.Default.GetBytes(ResoJWTValidators.SECRET_KEY))
                    };
                });
        }

    }
}
