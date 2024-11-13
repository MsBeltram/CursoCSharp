using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Inventary.DTOs.Category;
using Inventory.Entities;

namespace Inventory.API.Mapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CategoryToCreateDto, Category>();
            CreateMap<CategoryToEditDto,Category>();
            CreateMap<Category, CategoryToListDto>();
        }
    }
}