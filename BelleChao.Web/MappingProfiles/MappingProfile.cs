using AutoMapper;
using BelleChao.Data.DTOs;
using BelleChao.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BelleChao.Web.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ApplicationUser, UserTOPostDTO>();
            CreateMap<Restaurant, RestaurantToPost>();
            CreateMap<UserTOPostDTO, UserToRegisterDTO>();
            CreateMap<RestaurantToPost, RestaurantToRegisterDTO>();
            CreateMap<MenuItemToPost, MenuItemToAddDTO>();
            CreateMap<MenuItem, MenuItemToPost>();
            CreateMap<Restaurant, RestaurantToUpdateDTO>();
        }
    }
}
