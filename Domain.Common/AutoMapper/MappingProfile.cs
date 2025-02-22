using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common.Dto;
using Infrastructure.Core.Entities;
using AutoMapper;

namespace Domain.Common.AutoMapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<OrderAcme, OrderXml>()
            .ForMember(dest => dest.pedido, opt => opt.MapFrom(src => src.numPedido))
            .ForMember(dest => dest.Cantidad, opt => opt.MapFrom(src => src.cantidadPedido))
            .ForMember(dest => dest.EAN, opt => opt.MapFrom(src => src.codigoEAN))
            .ForMember(dest => dest.Producto, opt => opt.MapFrom(src => src.nombreProducto))
            .ForMember(dest => dest.Cedula, opt => opt.MapFrom(src => src.numDocumento))
            .ForMember(dest => dest.Direccion, opt => opt.MapFrom(src => src.direccion));
        }
    }
}
