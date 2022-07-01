using System.Collections.Generic;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4;

namespace IdentityServer
{
    public static class Configuration
    {
        public static IEnumerable<Client> GetClients() =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "client_id",

                    ClientSecrets = { new Secret("client_secret".ToSha256())},

                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    AllowedScopes =
                    {
                        "TestAPI"
                    }
                },
                new Client
                {
                    ClientId = "client_id_test",

                    ClientSecrets = { new Secret("client_secret_test".ToSha256())},

                    AllowedGrantTypes = GrantTypes.Code,

                    AllowedScopes =
                    {
                        "TestAPI",
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile

                    },

                    RedirectUris = { "https://localhost:5001/signin-oidc" }
                }
            };

        public static IEnumerable<ApiResource> GetApiResources() =>
            new List<ApiResource>
            {
                new ApiResource("TestAPI")
            };

        public static IEnumerable<IdentityResource> GetIdentityResources() =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()

            };
    }
}
