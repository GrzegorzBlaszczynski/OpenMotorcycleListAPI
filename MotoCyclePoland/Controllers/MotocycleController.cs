using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MotoCyclePoland.Database;
using MotoCyclePoland.Database.Tables;
using SharedDTO.Models;

namespace MotoCyclePoland.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotocycleController : ControllerBase
    {
        motoDbContext _context;
        IMapper _mapper;



        public MotocycleController(motoDbContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetBrands")]
        public ActionResult<IEnumerable<SimpleBrandDTO>> GetBrandList()
        {
            var brands = _context.Brands
            .ToList();

            var motocyclesDTO = _mapper.Map<IEnumerable<SimpleBrandDTO>>(brands);
            return Ok(motocyclesDTO);
        }

        [HttpGet]
        [Route("GetBrandsWithMotocycles")]
        public ActionResult<IEnumerable<BrandDTO>> GetBrandListWithMotocycle()
        {
             var brands = _context.Brands
             .Include(m => m.Motocycles) 
             .ToList();

             var brandsDTO = _mapper.Map<IEnumerable<BrandDTO>>(brands);
             return Ok(brandsDTO);
        }


        [HttpGet]
        [Route("SearchbyName")]
        public ActionResult<IEnumerable<MotocycleDTO>> GetbyName(string name)
        {
            List<Motocycle> moto = _context.Motocycles.Include(m => m.Brand).Where(x=>(x.Brand.Name.ToUpper() +" " + x.Name.ToUpper()).Contains(name.ToUpper())).ToList();
            var motocyclesDTO = _mapper.Map<IEnumerable<MotocycleDTO>>(moto);

            return Ok(motocyclesDTO);
        }

        [HttpGet]
        [Route("SearchWithBrand")]
        public ActionResult<IEnumerable<MotocycleDTO>> GetByBrand(string brand)
        {
            List<Motocycle> moto = _context.Motocycles.Include(m => m.Brand).Where(x => (x.Brand.Name.ToUpper()).Contains(brand.ToUpper())).ToList();
            var motocyclesDTO = _mapper.Map<IEnumerable<MotocycleDTO>>(moto);

            return Ok(motocyclesDTO);
        }


        [HttpGet]
        [Route("GetByProductionDates")]
        public ActionResult<IEnumerable<MotocycleDTO>> GetByProductionDates(string brand)
        {
            List<Motocycle> moto = _context.Motocycles.Include(m => m.Brand).Where(x => (x.Brand.Name.ToUpper()).Contains(brand.ToUpper())).ToList();
            var motocyclesDTO = _mapper.Map<IEnumerable<MotocycleDTO>>(moto);

            return Ok(motocyclesDTO);
        }
    }
}
