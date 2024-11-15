using AutoMapper;
using Inventary.DTOs.Category;
using Inventory.DTOs.InventoryMovement;
using Inventory.DTOs.InventoryStock;
using Inventory.DTOs.MovementType;
using Inventory.DTOs.Product;
using Inventory.DTOs.Supplier;
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

            CreateMap<InventoryMovementToCreateDto, InventoryMovement>();
            CreateMap<InventoryMovementToEditDto,InventoryMovement>();
            CreateMap<InventoryMovement,InventoryMovementToListDto>()
                .ForMember(dest => dest.MovementTypeName, opt =>
                opt.MapFrom(src => src.MovementType.Name))
                .ForMember (dest => dest.ProductName, opt =>
                opt.MapFrom(src => src.Product.Name));

            //InventoryStock
            CreateMap<InventoryStockToCreateDto, InventoryStock>();
            CreateMap<InventoryStockToEditDto,InventoryStock>();
            CreateMap<InventoryStock,InventoryStockToListDto>()
                .ForMember(dest => dest.ProductName, opt =>
                opt.MapFrom(src => src.Product.Name));

            //MovementType
            CreateMap<MovementTypeToCreateDto, MovementType>();
            CreateMap<MovementTypeToEditDto, MovementType>();
            CreateMap<MovementType, MovementTypeToListDto>();

            //Product
            CreateMap<ProductToCreateDto, Product>();
            CreateMap<ProductToEditDto, Product>();
            CreateMap<Product, ProductToListDto>()
                .ForMember(dest => dest.SupplierName, opt =>
                opt.MapFrom(src => src.Supplier.Name))
                .ForMember (dest => dest.CategoryName, opt =>
                opt.MapFrom(src => src.Category.Name));


            CreateMap<SupplierToCreateDto, Category>();
            CreateMap<SupplierToEditDto,Category>();
            CreateMap<Category, SupplierToListDto>();
        }
    }
}