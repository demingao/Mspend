using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Autofac;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Mspend.Domain.Interfaces.Services;

namespace Mspend.Api.Providers
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        private readonly string _publicClientId;
        private readonly IUserService _userService;

        public ApplicationOAuthProvider(string publicClientId)
            : this(publicClientId,IocConfig.Container.Resolve<IUserService>())
        {
            _publicClientId = publicClientId;
        }

        private ApplicationOAuthProvider(string publicClientId, IUserService userService)
        {
            if (publicClientId == null)
            {
                throw new ArgumentNullException("publicClientId");
            }
            _publicClientId = publicClientId;
            _userService = userService;
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var user = _userService.Login(context.UserName, context.Password);
            if (user == null)
            {
                context.SetError("invalid_grant", "用户名或密码不正确。");
                return;
            }
            var oAuthIdentity = new ClaimsIdentity(OAuthDefaults.AuthenticationType);
            oAuthIdentity.AddClaim(new Claim("username",user.LoginName));
            oAuthIdentity.AddClaim(new Claim("userid", user.Id.ToString()));
            var properties = CreateProperties(user.LoginName);
            var ticket = new AuthenticationTicket(oAuthIdentity, properties);
            context.Validated(ticket);
        }

        public override Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        {
            return base.GrantRefreshToken(context);
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            // 资源所有者密码凭据未提供客户端 ID。
            if (context.ClientId == null)
            {
                context.Validated();
            }

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            if (context.ClientId == _publicClientId)
            {
                Uri expectedRootUri = new Uri(context.Request.Uri, "/");

                if (expectedRootUri.AbsoluteUri == context.RedirectUri)
                {
                    context.Validated();
                }
            }

            return Task.FromResult<object>(null);
        }

        public static AuthenticationProperties CreateProperties(string userName)
        {
            IDictionary<string, string> data = new Dictionary<string, string>
            {
                { "userName", userName }
            };
            return new AuthenticationProperties(data);
        }
    }
}