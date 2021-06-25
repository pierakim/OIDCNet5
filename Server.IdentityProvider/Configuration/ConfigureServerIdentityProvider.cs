using System.Collections.Generic;
using System.Security.Claims;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace Server.IdentityProvider.Configuration
{
    public static class ConfigureServerIdentityProvider
    {
        /// <summary>
        /// Identity resource configuration
        /// </summary>
        public static List<IdentityResource> IdentityResources 
        {
            get
            {
                var idResources = new List<IdentityResource>()
                {
                    new IdentityResources.OpenId(),
                    new IdentityResources.Profile(),
                    new IdentityResources.Email(),
                    new IdentityResources.Phone(),
                    new IdentityResources.Address(),
                    new IdentityResource("roles", "User roles", new List<string> { "role" })
                };

                return idResources;
            }
        }

        /// <summary>
        /// Scope for API configuration
        /// </summary>
        public static List<ApiScope> ApiScopes 
        {
            get
            {
                var apiScopes = new List<ApiScope>()
                {
                    new ApiScope("employeesWebApi", "Employees Web API")
                };
                
                return apiScopes;
            }
        }

        /// <summary>
        /// API Resources configuration
        /// </summary>
        public static List<ApiResource> ApiResources 
        {
            get
            {
                var apiResource1 = new ApiResource("employeesWebApiResource", "Employees Web API")
                {
                    Scopes = { "employeesWebApi" },
                    UserClaims = 
                    { "role",
                      "given_name",
                      "family_name",
                      "email",
                      "phone",
                      "address"
                    }
                };

                var apiResources = new List<ApiResource>()
                {
                    apiResource1
                };

                return apiResources;
            }
        }

        /// <summary>
        /// Client configuration
        /// </summary>
        public static List<Client> Clients 
        {
            get
            {
                var client1 = new Client
                {
                    ClientId = "client1",
                    ClientName = "Client 1",
                    ClientSecrets = new[] { new Secret("client1_secret_code".Sha256()) },
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    AllowedScopes = 
                    {
                        "openid",
                        "roles",
                        "employeesWebApi"
                    }
                };

                var clients = new List<Client>
                {
                    client1
                };

                return clients;
            }
        }

        /// <summary>
        /// Test Users
        /// </summary>
        public static List<TestUser> TestUsers 
        {
            get
            {
                var usr1 = new TestUser()
                {
                    SubjectId = "2f47f8f0-bea1-4f0e-ade1-88533a0eaf57",
                    Username = "user1",
                    Password = "password1",
                    Claims = new List<Claim>
                    {
                        new Claim("given_name", "firstName1"),
                        new Claim("family_name", "lastName1"),
                        new Claim("address", "USA"),
                        new Claim("email","user1@localhost"),
                        new Claim("phone", "123"),
                        new Claim("role", "Admin")
                    }
                };

                var usr2 = new TestUser()
                {
                    SubjectId = "5747df40-1bff-49ee-aadf-905bacb39a3a",
                    Username = "user2",
                    Password = "password2",
                    Claims = new List<Claim>
                    {
                        new Claim("given_name", "firstName2"),
                        new Claim("family_name", "lastName2"),
                        new Claim("address", "UK"),
                        new Claim("email","user2@localhost"),
                        new Claim("phone", "456"),
                        new Claim("role", "Operator")
                    }
                };

                var testUsers = new List<TestUser>
                {
                    usr1,
                    usr2
                };

                return testUsers;
            }
        }
    }
}
