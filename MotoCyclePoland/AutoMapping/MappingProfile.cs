using AutoMapper;
using MotoCyclePoland.Database.Tables;
using SharedDTO.Models;

namespace MotoCyclePoland.AutoMapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Brand, BrandDTO>().ForMember(x=>x.Motocycle,opt=>opt.MapFrom(c=>c.Motocycles));
            CreateMap<Brand, SimpleBrandDTO>();
            CreateMap<Motocycle, MotocycleDTO>()
                .ForMember(x => x.MotocycleBrand, opt => opt.MapFrom(c => c.Brand.Name))
                .ForMember(x => x.Model, opt => opt.MapFrom(c => c.Name))
                .ForMember(x => x.ProductionStartYears, opt => opt.MapFrom(c => c.StartProduction))
                .ForMember(x => x.ProductionEndYears, opt => opt.MapFrom(x=>x.EndProduction));

        }
    }
}
