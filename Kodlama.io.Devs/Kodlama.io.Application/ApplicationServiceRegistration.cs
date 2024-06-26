﻿using Application;
using Core.Application.Pipelines.Validation;
using FluentValidation;
using Kodlama.io.Application.Features.ProgramLanguage.Rules;
using Kodlama.io.Application.Features.ProgramLanguageTechnologies.Rules;
using Kodlama.io.Application.Features.SocialMedias.Rules;
using Kodlama.io.Application.Features.Users.Authentications.Rules;
using Kodlama.io.Application.Features.Users.Rules;
using Kodlama.io.Application.Features.UserSocialMedias.Rules;
using Kodlama.io.Application.Services.AuthService;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Application
{
    public static  class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddScoped<ProgramLanguageBusinessRules>();
            services.AddScoped<ProgramLanguageTechnologyBusinessRules>();
            services.AddScoped<UserBusinessRules>();
            services.AddScoped<AuthBusinessRoles>();
            services.AddScoped<UserSocialMediaBusinessRules>();
            services.AddScoped<SocialMediaBusinessRules>();
            services.AddScoped<IAuthService, AuthManager>();

            services.AddSecurityServices(); 
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            return services;
        }
    }
}
