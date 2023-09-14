using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentsByUserAPI.InputModels;
using PaymentsByUserAPI.ViewModels;
using PaymentsByUserCore.DomainExceptions;
using PaymentsByUserCore.DTOs;
using PaymentsByUserCore.Entities;
using PaymentsByUserCore.Interfaces.Application;

namespace PaymentsByUserAPI.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateUserInputModel inputModel)
        {
            try
            {
                var user = new User(inputModel.Id, inputModel.Name, inputModel.GridA, inputModel.GridB, inputModel.GridC);
                _userService.CreateUser(user);
                var userViewModel = new UserViewModel(user.Id, user.Name, user.GridA, user.GridB, user.GridC);
                return CreatedAtAction(nameof(GetById), new { Id = user.Id }, userViewModel);
            }
            catch (DuplicatedUserException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (DuplicatedGridException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var user = _userService.GetById(id);
                var userViewModel = new UserViewModel(user.Id, user.Name, user.GridA, user.GridB, user.GridC);
                return Ok(userViewModel);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            try
            {
                var users = _userService.GetUsers();
                var usersViewModel = users.ConvertAll(user => new UserViewModel(user.Id, user.Name, user.GridA, user.GridB, user.GridC));
                return Ok(usersViewModel);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateUserGrid(int id, [FromBody] GridInputModel inputModel)
        {
            var gridDto = new GridDTO(inputModel.GridA, inputModel.GridB, inputModel.GridC);
            try
            {
                _userService.UpdateUserGrid(id, gridDto);
                return NoContent();
            }
            catch (DuplicatedGridException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
