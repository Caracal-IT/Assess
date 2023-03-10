namespace Caracal.Assess.Mvc.Services;

public class IdentityServerSettings {
    public string DiscoveryUrl { get; set; } = default!;
    public string ClientName { get; set; } = default!;
    public string ClientPassword { get; set; } = default!;
    public bool UseHttps { get; set; }
}