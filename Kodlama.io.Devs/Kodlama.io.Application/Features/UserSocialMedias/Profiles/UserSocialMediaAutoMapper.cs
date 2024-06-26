﻿using AutoMapper;
using Core.Persistence.Paging;
using Kodlama.io.Application.Features.UserSocialMedias.Commands.Create;
using Kodlama.io.Application.Features.UserSocialMedias.Dtos;
using Kodlama.io.Application.Features.UserSocialMedias.Models;
using Kodlama.io.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Application.Features.UserSocialMedias.Profiles
{
    public  class UserSocialMediaAutoMapper :Profile
    {

        public UserSocialMediaAutoMapper()
        {
            CreateMap<UserSocialMedia, CreateUserSocialMediaCommand>().ReverseMap();
            CreateMap<UserSocialMedia, CreatedUserSocialMediaDto>().
                ForMember(c=>c.SocialMediaName,opt=>opt.MapFrom(c=>c.SocialMedia.SocialMediaName)).
                ForMember(c => c.Email, opt => opt.MapFrom(c => c.User.Email)).ReverseMap();

            CreateMap<UserSocialMedia, GetByIdUserSocialMediaDto>().
                ForMember(c => c.SocialMediaName, opt => opt.MapFrom(c => c.SocialMedia.SocialMediaName)).ReverseMap();

            CreateMap<UserSocialMedia, DeletedUserSocialMediaDto>().
               ForMember(c => c.SocialMediaName, opt => opt.MapFrom(c => c.SocialMedia.SocialMediaName)).ReverseMap();

            CreateMap<IPaginate<UserSocialMedia>, UserSocialMediaListModel>().ReverseMap();
            CreateMap<UserSocialMedia, GetListUserSocialMediaDto>().
                ForMember(c => c.SocialMediaName, opt => opt.MapFrom(c => c.SocialMedia.SocialMediaName)).ReverseMap();
        }
    }
}
