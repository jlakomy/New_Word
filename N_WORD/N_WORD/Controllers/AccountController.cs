using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using N_WORD.Entities;
using N_WORD.Models;
using N_WORD.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_WORD.Controllers
{
    [Route("/api/account")]
    [ApiController]
    public class AccountController: ControllerBase
    {
        private IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("register")]
        public ActionResult CreateAccount([FromBody] RegisterUserDto dto)
        {
            _accountService.RegisterUser(dto);
            return Ok();
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody] LoginDto dto)
        {
            string token = _accountService.GenerateJwt(dto);
            return Ok(token);
        }
    }
}
