using System;
using System.Diagnostics;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security.OAuth;
using Owin;
using Mspend.Api.Providers;
using Newtonsoft.Json.Linq;
using AuthenticationMode = Microsoft.Owin.Security.AuthenticationMode;
using System.IdentityModel.Tokens;

namespace Mspend.Api
{
    public partial class Startup
    {
        public static string PublicClientId { get; private set; }

        // 有关配置身份验证的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // 使应用程序可以使用 Cookie 来存储已登录用户的信息
            // 并使用 Cookie 来临时存储有关使用第三方登录提供程序登录的用户的信息
            //app.UseCookieAuthentication(new CookieAuthenticationOptions());
            //app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // 针对基于 OAuth 的流配置应用程序
            PublicClientId = "self";
            // 使应用程序可以使用不记名令牌来验证用户身份
            var oAuthOptions = new OAuthAuthorizationServerOptions
            {
#if DEBUG
                AllowInsecureHttp = true,
#endif
                TokenEndpointPath = new PathString("/auth0/token"),
                Provider = new ApplicationOAuthProvider(PublicClientId),
                AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(5),
                RefreshTokenProvider=new ApplicationRefreshTokenProvider()
            };

            var issuer = WebConfigurationManager.AppSettings["Auth0Domain"];
            var audience = WebConfigurationManager.AppSettings["Auth0ClientID"];
            var secret = TextEncodings.Base64Url.Decode(WebConfigurationManager.AppSettings["Auth0ClientSecret"]);
            var jwtBearerAuthenticationOptions = new JwtBearerAuthenticationOptions
            {
                AuthenticationMode = AuthenticationMode.Active,
                AllowedAudiences = new[] { audience },
                IssuerSecurityTokenProviders = new IIssuerSecurityTokenProvider[]
                {
                    new SymmetricKeyIssuerSecurityTokenProvider(issuer, secret)
                }
            };
            app.UseCors(CorsOptions.AllowAll);
            app.UseOAuthBearerTokens(oAuthOptions);
            app.UseJwtBearerAuthentication(jwtBearerAuthenticationOptions);

            // 取消注释以下行可允许使用第三方登录提供程序登录
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //    consumerKey: "",
            //    consumerSecret: "");

            //app.UseFacebookAuthentication(
            //    appId: "",
            //    appSecret: "");

            //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            //{
            //    ClientId = "",
            //    ClientSecret = ""
            //});
        }
    }
}
