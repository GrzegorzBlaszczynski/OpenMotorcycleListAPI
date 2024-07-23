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
    public class MotorcycleController : ControllerBase
    {
        MotoDbContext _context;
        IMapper _mapper;



        public MotorcycleController(MotoDbContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Get simple list of brands
        /// </summary>
        /// <returns>A list of brands(SimpleBrandDTO)</returns>
        [HttpGet]
        [Route("GetBrands")]
        public ActionResult<IEnumerable<SimpleBrandDTO>> GetBrandList()
        {
            var brands = _context.Brands
            .ToList();

            var motorcyclesDTOobjs = _mapper.Map<IEnumerable<SimpleBrandDTO>>(brands);
            return Ok(motorcyclesDTOobjs);
        }

        /// <summary>
        /// Gets brands with their motorcycles included
        /// </summary>
        /// <returns>A list of brands(BrandDTO) with their motorcycles(MotorcycleDTO) </returns>
        [HttpGet]
        [Route("GetBrandsWithMotorcycles")]
        public ActionResult<IEnumerable<BrandDTO>> GetBrandListWithMotocycle()
        {
             var brands = _context.Brands
             .Include(m => m.Motorcycles) 
             .ToList();

             var brandsDTO = _mapper.Map<IEnumerable<BrandDTO>>(brands);
             return Ok(brandsDTO);
        }

        /// <summary>
        /// Searches for motorcycles based on a partial or full name
        /// </summary>
        /// <param name="brand">The partial or full name of the motorcycle or brand</param>
        /// <returns>A list of all motorcycles(MotorcycleDTO) that match the specified search criteria</returns>
        [HttpGet]
        [Route("SearchByName")]
        public ActionResult<IEnumerable<MotorcycleDTO>> GetbyName(string name)
        {
            List<Motorcycle> moto = _context.Motorcycles.Include(m => m.Brand).Where(x=>(x.Brand.Name.ToUpper() +" " + x.Name.ToUpper()).Contains(name.ToUpper())).ToList();
            var motocyclesDTO = _mapper.Map<IEnumerable<MotorcycleDTO>>(moto);

            return Ok(motocyclesDTO);
        }

        /// <summary>
        /// Gets motorcycles of a specified brand.
        /// </summary>
        /// <param name="brand">Brand name</param>
        /// <returns>A list of all motorcycles (MotorcycleDTO) of specified brand.</returns>
        [HttpGet]
        [Route("SearchWithBrand")]
        public ActionResult<IEnumerable<MotorcycleDTO>> GetByBrand(string brand)
        {
            List<Motorcycle> moto = _context.Motorcycles.Include(m => m.Brand).Where(x => (x.Brand.Name.ToUpper()).Contains(brand.ToUpper())).ToList();
            var motocyclesDTO = _mapper.Map<IEnumerable<MotorcycleDTO>>(moto);

            return Ok(motocyclesDTO);
        }

        /// <summary>
        /// Gets all motorcycles from database.
        /// </summary>
        /// <returns>A list of all motorcycles (MotorcycleDTO)</returns>
        [HttpGet]
        [Route("GetAllMotorcycles")]
        public ActionResult<IEnumerable<MotorcycleDTO>> GetAllMotocycles()
        {
            List<Motorcycle> moto = _context.Motorcycles.Include(m => m.Brand).ToList();
            var motocyclesDTO = _mapper.Map<IEnumerable<MotorcycleDTO>>(moto);

            return Ok(motocyclesDTO);
        }

        /// <summary>
        /// Gets a motorcycles with a specific full name.
        /// </summary>
        /// <param name="name">The full name of the motorcycle.</param>
        /// <returns>A list of motorcycles (MotorcycleDTO) that match the specified name.</returns>
        [HttpGet]
        [Route("GetByName")]
        public ActionResult<MotorcycleDTO> GetByName(string name)
        {
            List<Motorcycle> moto = _context.Motorcycles.Include(m => m.Brand).Where(x => x.Name.ToUpper() == name.ToUpper()).ToList();
            var motocyclesDTO = _mapper.Map<IEnumerable<MotorcycleDTO>>(moto);

            return Ok(motocyclesDTO);
        }

        /// <summary>
        /// Returns a list of motorcycles that were produced within the specified date range.
        /// </summary>
        /// <param name="from">Start date of the production</param>
        /// <param name="to">To Date. Leave blank if you want to search up to the current date.</param>
        /// <returns>A list of motorcycles(MotorcycleDTO) produced between the specified dates</returns>
        [HttpGet]
        [Route("GetByProductionDate")]
        public ActionResult<MotorcycleDTO> GetByProductionDate(DateTime from,DateTime? to)
        {
            List<Motorcycle> moto = _context.Motorcycles.Include(m => m.Brand).Where(x => x.StartProduction>=from &&  (to == null || x.EndProduction<=to)).ToList();
            var motocyclesDTO = _mapper.Map<IEnumerable<MotorcycleDTO>>(moto);

            return Ok(motocyclesDTO);
        }
    }
}
