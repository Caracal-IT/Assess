using IdentityModel.Client;

namespace Caracal.Assess.Mvc.Services;

public interface ITokenService
{
    Task<TokenResponse> GetToken(string scope);
}