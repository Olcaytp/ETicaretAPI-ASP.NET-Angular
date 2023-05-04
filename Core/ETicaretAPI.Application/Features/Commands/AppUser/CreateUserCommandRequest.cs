﻿using MediatR;

namespace ETicaretAPI.Application.Features.Commands.AppUser
{
    public class CreateUserCommandRequest : IRequest<CreateUserCommandResponse>
    {
        public string NameSurname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordConfirm { get; set; }
        public string Password { get; set; }
    }
}