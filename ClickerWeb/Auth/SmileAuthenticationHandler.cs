using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace ClickerWeb.Auth
{
    public class SmileAuthenticationHandler : AuthenticationHandler<SmileAuthenticationSchemeOptions>
    {
        public SmileAuthenticationHandler(IOptionsMonitor<SmileAuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var claims = new List<Claim>();
            claims.Add(new Claim("Fun", "Smile"));

            var identity = new ClaimsIdentity(claims: claims, authenticationType: Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal: principal, authenticationScheme: Scheme.Name);
            return await Task.FromResult(AuthenticateResult.Success(ticket));
        }
    }
}
