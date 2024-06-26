﻿using AutoMapper;
using Core.Security.Entities;
using Kodlama.io.Application.Features.Users.Dtos;
using Kodlama.io.Application.Features.Users.EntityBaseDependency;
using Kodlama.io.Application.Features.Users.Rules;
using Kodlama.io.Application.Services.Repositories;
using MediatR;

namespace Kodlama.io.Application.Features.Users.Queries.Get.Email
{
    public class GetByEmailUserQuery : IRequest<GetSingleUserDto>
    {
        public string Email { get; set; }
        public class GetByEmailUserQueryHandler : UserDependResolver, IRequestHandler<GetByEmailUserQuery, GetSingleUserDto>
        {
            public GetByEmailUserQueryHandler(IUserRepository userRepository, IMapper mapper, UserBusinessRules roles) : base(userRepository, mapper, roles)
            {
            }

            public async Task<GetSingleUserDto> Handle(GetByEmailUserQuery request, CancellationToken cancellationToken)
            {
                User user = await Rules.UserExistsWhenRequested(request.Email);
                return Mapper.Map<GetSingleUserDto>(user);

            }
        }
    }
}
