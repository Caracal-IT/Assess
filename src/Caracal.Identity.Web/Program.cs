using Caracal.Identity.Web.Data;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Test;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

var identityServer = builder.Services.AddIdentityServer(options =>
{
    options.Events.RaiseErrorEvents = true;
    options.Events.RaiseInformationEvents = true;
    options.Events.RaiseFailureEvents = true;
    options.Events.RaiseSuccessEvents = true;

    // https://docs.duendesoftware.com/identityserver/v5/fundamentals/resources/api_scopes/
    options.EmitStaticAudienceClaim = true;
});

identityServer.AddTestUsers(TestUsers.Users)
              .AddInMemoryClients(Config.Clients)
              .AddInMemoryApiResources(Config.ApiResources)
              .AddInMemoryApiScopes(Config.ApiScopes)
              .AddInMemoryIdentityResources(Config.IdentityResources);

var app = builder.Build();
app.UseIdentityServer();

// Discovery Endpoint
// /.well-known/openid-configuration

// Github: https://github.com/kevinrjones/SettingUpIdentityServer
// UI    : https://Github.com/DuendeSoftware/IdentityServer.Quickstart.ui

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
    
app.MapRazorPages()
   .RequireAuthorization();


app.Run();