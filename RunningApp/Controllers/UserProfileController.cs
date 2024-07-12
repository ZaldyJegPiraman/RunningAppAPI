using Microsoft.AspNetCore.Mvc;
using RunningApp.Data;
using RunningApp.DTO;
using RunningApp.Helpers;
using RunningApp.Interfaces;
using RunningApp.Models;
using RunningApp.Repository;
using System.Diagnostics;
using System.Net;
using static System.Reflection.Metadata.BlobBuilder;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RunningApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly ILoggerManager _logger;

        public UserProfileController(IUserProfileRepository userProfileRepository, ILoggerManager logger)
        {
            this._userProfileRepository = userProfileRepository;
            this._logger = logger;
        }

        // GET: api/<UserProfileController>
        [HttpGet]
        public async Task<IEnumerable<UserProfileDTO>> Get()
        {
            var users = await _userProfileRepository.GetAll();

            if (users == null)
            {
                return null;
            }


            _logger.LogInfo("get all user profile record");
            return users.Select(a => a.ToUserProfileDTOModel()).ToList(); 
        }

        // GET api/<UserProfileController>/5
        [HttpGet("{id}")]
        public async Task<UserProfileDTO> Get(int id)
        {
            var user = await _userProfileRepository.GetByIdAsync(id);

            if (user == null)
            {
                return null;
            }

            _logger.LogInfo($"get user profile with id:{id}");
            return user.ToUserProfileDTOModel();
        }

        // POST api/<UserProfileController>
        [HttpPost]
        public IActionResult Post([FromBody] UserProfileDTO user)
        {
            try
            {
                if (_userProfileRepository.Add(user.ToUserProfileModel()))
                {
                    _logger.LogInfo($"successfully added new user profile");
                    return Ok(user);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"failed to add new  user profile, error:{ex.Message}");
            }

            return BadRequest();
        }

        // PUT api/<UserProfileController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UserProfileDTO user)
        {
            try
            {
                user.UserId = id;

                if (_userProfileRepository.Update(user.ToUserProfileModel()))
                {
                    _logger.LogInfo($"successfully updated user profile with id:{id}");
                    return Ok(user);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"failed to update user profile with id:{id}, error: {ex.Message}");
            }
        
            return BadRequest();
        }

        // DELETE api/<UserProfileController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var user = await _userProfileRepository.GetByIdAsync(id);
                if (user != null)
                {
                    _userProfileRepository.Delete(user);
                    _logger.LogInfo($"successfully deleted user profile with id:{id}");
                    return Ok(user);
                }

            }
            catch (Exception ex)
            {

                _logger.LogError($"failed to delete user profile with id:{id}, error: {ex.Message}");
            }
            return NotFound();
        }
    }
}
