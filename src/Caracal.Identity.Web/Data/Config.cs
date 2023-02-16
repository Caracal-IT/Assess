using System.Security.Claims;
using System.Text.Json;
using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Test;
using IdentityModel;

namespace Caracal.Identity.Web.Data;

public static class Config
  {
    public static IEnumerable<IdentityResource> IdentityResources =>
      new []
      {
        new IdentityResources.OpenId(),
        new IdentityResources.Profile(),
        new IdentityResource
        {
          Name = "role",
          UserClaims = new List<string> {"role"}
        }
      };

    public static IEnumerable<ApiScope> ApiScopes =>
      new []
      {
        new ApiScope("weatherapi.read"),
        new ApiScope("weatherapi.write"),
      };
    
    public static IEnumerable<ApiResource> ApiResources => new[]
    {
      new ApiResource("weatherapi")
      {
        Scopes = new List<string> {"weatherapi.read", "weatherapi.write"},
        ApiSecrets = new List<Secret> {new Secret("ScopeSecret".Sha256())},
        UserClaims = new List<string> {"role"}
      }
    };

    public static IEnumerable<Client> Clients =>
      new[]
      {
        // m2m client credentials flow client
        new Client
        {
          ClientId = "m2m.client",
          ClientName = "Client Credentials Client",

          AllowedGrantTypes = GrantTypes.ClientCredentials,
          ClientSecrets = {new Secret("SuperSecretPassword".Sha256())},

          AllowedScopes = {"weatherapi.read", "weatherapi.write"},
          Claims =
          {
            new ClientClaim(JwtClaimTypes.Role, "weatherapiRead")
          }
        },

        // interactive client using code flow + pkce
        new Client
        {
          ClientId = "interactive",
          ClientSecrets = {new Secret("SuperSecretPassword".Sha256())},

          AllowedGrantTypes = GrantTypes.Code,
          AlwaysSendClientClaims = true,

          RedirectUris = {"https://localhost:5444/signin-oidc"},
          FrontChannelLogoutUri = "https://localhost:5444/signout-oidc",
          PostLogoutRedirectUris = {"https://localhost:5444/signout-callback-oidc"},

          AllowOfflineAccess = true,
          AllowedScopes = {"openid", "profile", "role", "weatherapi.read"},
          RequirePkce = true,
          // RequireConsent = true,
          RequireConsent = false,
          AllowPlainTextPkce = false
        },
      };
  }