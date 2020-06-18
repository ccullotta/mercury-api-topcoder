using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using topcoderattempt1.Dtos;
using topcoderattempt1.Models;

namespace topcoderattempt1.Profiles
{
    public class MercuryProfile : Profile
    {
        private class testFormatter : IValueConverter<byte[], String>
        {
            public string Convert(byte[] sourceMember, ResolutionContext context)
            {
                return "success";
            }
        }
        public MercuryProfile()
        {
            CreateMap<UserModel, UserReadDto>();
            //.ForMember(t => t.LastUpdatedOn, opt => opt.MapFrom(src => System.Text.Encoding.UTF8.GetString(src.LastUpdatedOn)));
            CreateMap<UserCreateDto, UserModel>()
                .ForMember(u => u.PasswordHash, opt => opt.MapFrom(src => src.Password));

            CreateMap<UserAuthDto, UserModel>()
                .ForMember(u => u.PasswordHash, opt => opt.MapFrom(src => src.Password));

            CreateMap<UserPermission, UserPermissionReadDto>();

            CreateMap<UserModel, UserProfileDto>()
                .ForMember(u => u.id, opt => opt.MapFrom(src => src.User_id));
            CreateMap<Keyholder, ToolkitInfoDto>();

            CreateMap<UserPermission, UserPermissionCompactDto>();

            CreateMap<UserActivity, UserActivityCompactDto>();

        }

    }
}
