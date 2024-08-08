using AutoMapper;
using Cert.Core.DTOs;
using Cert.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Cert.Infrastructure.Mapping
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            
            CreateMap<Producto, ProductoDTOs>();
            CreateMap<ProductoDTOs, Producto>();
        }
    }
}
