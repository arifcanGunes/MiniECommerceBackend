﻿using MediatR;
using Microsoft.AspNetCore.Identity;
using MiniETicaretBackend.Application.Exceptions.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniETicaretBackend.Application.Features.Commands.AppUser.CreateAppUser
{
    public class CreateAppUserCommandHandler : IRequestHandler<CreateAppUserCommandRequest, CreateAppUserCommandResponse>
    {
        readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;

        public CreateAppUserCommandHandler(UserManager<Domain.Entities.Identity.AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateAppUserCommandResponse> Handle(CreateAppUserCommandRequest request, CancellationToken cancellationToken)
        {
            IdentityResult result =  await _userManager.CreateAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = request.Username,
                NameSurname = request.NameSurname,
                Email = request.Email  
            }, request.Password);
            CreateAppUserCommandResponse response = new CreateAppUserCommandResponse() { Succeeded = result.Succeeded};
            if (result.Succeeded)
            {
                response.Message = "Kullanıcı başarıyla eklendi.";
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    response.Message += $"{error.Code} - {error.Description}";
                }
            }
            return response;
        }
    }
}
