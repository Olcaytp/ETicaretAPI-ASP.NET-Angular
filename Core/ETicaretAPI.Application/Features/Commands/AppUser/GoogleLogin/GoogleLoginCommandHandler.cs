using ETicaretAPI.Application.Abstraction.Token;
using ETicaretAPI.Application.DTOs;
using Google.Apis.Auth;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.AppUser.GoogleLogin
{
    public class GoogleLoginCommandHandler : IRequestHandler<GoogleLoginCommandRequest, GoogleLoginCommandResponse>
    {
        readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;
        readonly ITokenHandler _tokenHandler;

        public GoogleLoginCommandHandler(UserManager<Domain.Entities.Identity.AppUser> userManager, ITokenHandler tokenHandler)
        {
            _userManager = userManager;
            _tokenHandler = tokenHandler;
        }

        public async Task<GoogleLoginCommandResponse> Handle(GoogleLoginCommandRequest request, CancellationToken cancellationToken)
        {
            var settings = new GoogleJsonWebSignature.ValidationSettings()
            {
                Audience = new List<string>() { "1015139408101-v6kap7kuv1asv76jntb30l740ahhqd33.apps.googleusercontent.com" }
            };

            var payload = await GoogleJsonWebSignature.ValidateAsync(request.IdToken, settings);

            var info = new UserLoginInfo(request.Provider, payload.Subject, request.Provider);
            Domain.Entities.Identity.AppUser user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);

            bool result = user != null;
            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(payload.Email);
                if (user == null)
                {
                    user = new()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Email = payload.Email,
                        UserName = payload.Email,
                        NamSurname = payload.Name,
                    };
                    var identityResult = await _userManager.CreateAsync(user);
                    result = identityResult.Succeeded;
                }
            }

            if(result)
                await _userManager.AddLoginAsync(user, info); //AspnetUserLogins
            else
                throw new Exception("Google ile giriş başarısız");

            Token token = _tokenHandler.CreateAccessToken(300);

            return new()
            {
                Token = token
            };
        }
    }
}
