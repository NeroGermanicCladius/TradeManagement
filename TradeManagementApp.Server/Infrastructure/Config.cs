using System.Collections.Generic;
using IdentityServer4.Models;

namespace TradeManagementApp.Server.Infrastructure
{
    public class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource
                {
                    Name = "role",
                    UserClaims = new List<string> { "role" }
                }
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new[]
            {
                new ApiScope("blazor_api.read"),
                new ApiScope("blazor_api.write"),
            };

        public static IEnumerable<ApiResource> ApiResources => new[]
        {
            new ApiResource("blazor_api")
            {
                Scopes = new List<string> { "blazor_api.read", "blazor_api.write" },
                ApiSecrets = new List<Secret> { new Secret("ScopeSecret".Sha256()) },
                UserClaims = new List<string> { "role" }
            }
        };

        public static IEnumerable<Client> Clients =>
            new[]
            {
                new Client
                {
                    ClientId = "m2m.client",
                    ClientName = "Client Credentials Client",

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("SuperSecretPassword".Sha256()) },

                    AllowedScopes = { "blazor_api.read", "blazor_api.write" }
                },

                new Client
                {
                    ClientId = "interactive",
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = { "https://localhost:5001/authentication/login-callback" },
                    PostLogoutRedirectUris = { "https://localhost:5001/authentication/logout-callback" },
                    AllowedScopes = { "openid", "profile", "blazor_api.read" },
                    RequirePkce = true,
                    RequireConsent = false,
                    RequireClientSecret = false,
                    AllowedCorsOrigins = { "https://localhost:5001" }
                },
            };
    }
}