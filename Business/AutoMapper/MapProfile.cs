using AutoMapper;
using DTO.Class;
using Repository.Entities;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.AutoMapper
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<SucursalDto, Sucursal>().ReverseMap();
            CreateMap<StockDto, Stock>().ReverseMap();
            CreateMap<Stock_SucursalDto, Stock_Sucursal>().ReverseMap();
            CreateMap<Stock_StateDto, Stock_State>().ReverseMap();
            CreateMap<SaleDto, Sale>().ReverseMap();
            CreateMap<Sale_StockDto, Sale_Stock>().ReverseMap();
            CreateMap<Sale_StateDto, Sale_State>().ReverseMap();
            CreateMap<RulesDto, Rules>().ReverseMap();
            CreateMap<Rules_PermissionDto, Rules_Permission>().ReverseMap();
            CreateMap<PermissionDto, Permission>().ReverseMap();
            CreateMap<DispatchDto, Dispatch>().ReverseMap();
            CreateMap<Dispatch_StockDto, Dispatch_Stock>().ReverseMap();
            CreateMap<Dispatch_StateDto, Dispatch_State>().ReverseMap();
          
        }
    }
}
