using Microsoft.AspNetCore.Mvc;
using RunningApp.DTO;
using RunningApp.Helpers;
using RunningApp.Interfaces;
using RunningApp.Models;
using RunningApp.Repository;
using System.Diagnostics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RunningApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RunningActivityController : ControllerBase
    {
        private readonly IRunningActivityRepository _runningActivityRepository;
        private readonly ILoggerManager _logger;

        public RunningActivityController(IRunningActivityRepository runningActivityRepository, ILoggerManager logger)
        {
            this._runningActivityRepository = runningActivityRepository;
            this._logger = logger;
        }

        // GET: api/<RunningActivityController>
        [HttpGet]
        public async Task<IEnumerable<RunningActivityDTO>> Get()
        {
            var acitvities = await _runningActivityRepository.GetAll();
            _logger.LogInfo("get all running activity record");
            return acitvities.Select(a => a.ToRunningActivityDTOModel()).ToList();
        }

        // GET api/<RunningActivityController>/5
        [HttpGet("{id}")]
        public async Task<RunningActivityDTO> Get(int id)
        {
            var acitvity = await _runningActivityRepository.GetByIdAsync(id);
            _logger.LogInfo($"get running activity with id:{id}");
            return acitvity.ToRunningActivityDTOModel();
        }

        // POST api/<RunningActivityController>
        [HttpPost]
        public IActionResult Post([FromBody] RunningActivityDTO acitvity)
        {

            try
            {
                if (_runningActivityRepository.Add(acitvity.ToRunningActivityModel()))
                {
                    _logger.LogInfo($"successfully added new running activity ");
                    return Ok(acitvity);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"failed to add new running activity with user profile id:{(acitvity == null ? 0 : acitvity.UserId)}, error: {ex.Message}");
            }
         
            return BadRequest();
        }

        // PUT api/<RunningActivityController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] RunningActivityDTO activity)
        {
            try
            {
                activity.RunningActivityId = id;
                if (_runningActivityRepository.Update(activity.ToRunningActivityModel()))
                {
                    _logger.LogInfo($"successfully updated running activity id:{activity.RunningActivityId}");
                    return Ok(activity);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"failed to update running activity with user profile id:{activity.UserId}, error: {ex.Message}");
            }
     
            return BadRequest();
        }

        // DELETE api/<RunningActivityController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var activity = await _runningActivityRepository.GetByIdAsync(id);
                if (activity != null)
                {
                    _runningActivityRepository.Delete(activity);
                    _logger.LogInfo($"successfully deleted running activity id:{id}");
                    return Ok(activity);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"failed to delete running activity with id:{id}, error: {ex.Message}");
            }
    
            return NotFound();
        }
    }
}
