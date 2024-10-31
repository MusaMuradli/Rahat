using AutoMapper;
using Core.Persistence.Paging;
using Rahat.Application.Dtos;
using Rahat.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<ProductDto, Product>().ReverseMap();
        CreateMap<ProductCreateDto, Product>().ReverseMap();
        CreateMap<ProductUpdateDto, Product>().ReverseMap();
        CreateMap<Paginate<Product>, ProductListDto>().ReverseMap();

        CreateMap<CategoryDto, Category>().ReverseMap();
        CreateMap<CategoryCreateDto, Category>().ReverseMap();
        CreateMap<CategoryUpdateDto, Category>().ReverseMap();
        CreateMap<Paginate<Category>, CategoryListDto>().ReverseMap();
    }
}
