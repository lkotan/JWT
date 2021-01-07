using AutoMapper;
using Jwt.API.Repositories;
using Jwt.Business.Abstract;
using Jwt.Business.Concrete;
using Jwt.Models.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jwt.API.Controllers
{
    [Authorize(Roles ="ProductList")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController:ControllerRepository<IProductService,ProductModel>
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service, IMapper mapper) : base(service, mapper)
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
