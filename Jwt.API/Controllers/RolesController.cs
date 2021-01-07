using AutoMapper;
using Jwt.API.Repositories;
using Jwt.Business.Abstract;
using Jwt.Models.Role;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jwt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController:ControllerRepository<IRoleService,RoleModel>
    {
        private readonly IRoleService _service;

        public RolesController(IRoleService service,IMapper mapper):base(service,mapper)
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
