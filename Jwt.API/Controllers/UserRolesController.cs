using AutoMapper;
using Jwt.API.Repositories;
using Jwt.Business.Abstract;
using Jwt.Core.Models.UserRole;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jwt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRolesController:ControllerRepository<IUserRoleService,UserRoleModel>
    {
        private readonly IUserRoleService _service;

        public UserRolesController(IUserRoleService service, IMapper mapper) : base(service, mapper)
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
