using AutoMapper;
using MotoCyclePoland.Database.Tables;
using SharedDTO.Models;

namespace MotoCyclePoland.AutoMapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Brand, BrandDTO>().ForMember(x=>x.Motorcycles,opt=>opt.MapFrom(c=>c.Motorcycles));
            CreateMap<Brand, SimpleBrandDTO>();
            CreateMap<Motorcycle, MotorcycleDTO>()
                .ForMember(x => x.MotorcycleBrand, opt => opt.MapFrom(c => c.Brand.Name))
                .ForMember(x => x.Model, opt => opt.MapFrom(c => c.Name))
                .ForMember(x => x.ProductionStartYear, opt => opt.MapFrom(c => c.StartProduction))
                .ForMember(x => x.ProductionEndYear, opt => opt.MapFrom(x=>x.EndProduction));

        }
    }
}
