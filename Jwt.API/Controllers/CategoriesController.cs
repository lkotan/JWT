using AutoMapper;
using Jwt.API.Repositories;
using Jwt.Business.Abstract;
using Jwt.Models.Category;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Jwt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController:ControllerRepository<ICategoryService,CategoryModel>
    {
        private readonly ICategoryService _service;

        public CategoriesController(ICategoryService service,IMapper mapper):base(service,mapper)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }
    }
}
