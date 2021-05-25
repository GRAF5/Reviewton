using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ProductsReviewsAngular.DTO;
using ProductsReviewsAngular.Models;

namespace ProductsReviewsAngular
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<UserForRegistrationDto, User>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email))
                .ForMember(u => u.Nickname, opt => opt.MapFrom(x => x.Name));
        }
    }
}
