using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Domain.Entities;

namespace API.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Prenda,PrendaDto>().ReverseMap();
            CreateMap<Insumo,InsumoDto>().ReverseMap();
            CreateMap<InsumoPrenda,InsumosPrendaDto>().ReverseMap();
            CreateMap<Prenda,InsumosxPrendaDto>().ReverseMap();
            CreateMap<Orden,OrdenDto>().ReverseMap();
            CreateMap<Empleado,EmpleadoDto>().ReverseMap();
        }
    }
}