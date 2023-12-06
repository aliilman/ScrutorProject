using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using ScrutorProject.UserServicve;

namespace ScrutorProject.Controllers
{

    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        private readonly IRepository<User> _userRepository;
     
        public UsersController(IUserService userService, IRepository<User> userRepository)
        {
            _userService = userService;
            _userRepository = userRepository;

        }

        [HttpGet("{id:int}")]
        public IActionResult GetUser(int id)
        {
            return Ok(_userService.GetUser(id));
        }
        [HttpGet("GetUsers")]
        public IActionResult GetUsers()
        {

            return Ok(_userRepository.Get());
        }
    }
}