using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using okko.uzapi.Contracts;
using okko.uzapi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace okko.uzapi.Controllers
{

    /// <summary>
    /// Endpoint used to interact with the Persons 
    /// </summary>
    [Route("api/v{version:apiVersion}/persons")]
    [ApiController]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonsRepository _npRepo;
        private readonly ILoggerService _logger;
        public PersonsController(IPersonsRepository npRepo,
            ILoggerService logger)
        {
            _npRepo = npRepo;
            _logger = logger;
        }
        /// <summary>
        /// Get All Persons
        /// </summary>
        /// <returns>List Of Persons</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPersons()
        {
            var location = GetControllerActionNames();
            IList<Persons> resultData=null;
            try
            {
                resultData = await _npRepo.FindAll();
            }
            catch (Exception e)
            {
                _logger.LogWarn($"{location}: {e.Message} - {e.InnerException}");
            }
            return Ok(resultData);
        }
        /// <summary>
        /// Get An Person by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A Person's record</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPerson(int id)
        {
            var location = GetControllerActionNames();
            Persons resultData = null;
            try
            {
                resultData = await _npRepo.FindById(id);
            }
            catch (Exception e)
            {
                _logger.LogWarn($"{location}: {e.Message} - {e.InnerException}");
            }
            return Ok(resultData);
        }
        /// <summary>
        /// Creates A Person
        /// </summary>
        /// <param name="personsDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles="Administrator")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] Persons persons)
        {
            var location = GetControllerActionNames();
            bool resultData = false;
            try
            {
                resultData = await _npRepo.Create(persons);
            }
            catch (Exception e)
            {
                _logger.LogWarn($"{location}: {e.Message} - {e.InnerException}");
            }
            return Ok(resultData);
        }

        /// <summary>
        /// Updates A Person
        /// </summary>
        /// <param name="id"></param>
        /// <param name="personDTO"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update([FromBody] Persons persons)
        {
            var location = GetControllerActionNames();
            bool resultData = false;
            try
            {
                resultData = await _npRepo.Update(persons);
            }
            catch (Exception e)
            {
                _logger.LogWarn($"{location}: {e.Message} - {e.InnerException}");
            }
            return Ok(resultData);
        }
        /// <summary>
        /// Removes an person by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete([FromBody] Persons persons)
        {
            var location = GetControllerActionNames();
            bool resultData = false;
            try
            {
                resultData = await _npRepo.Delete(persons);
            }
            catch (Exception e)
            {
                _logger.LogWarn($"{location}: {e.Message} - {e.InnerException}");
            }
            return Ok(resultData);           
        }

        private string GetControllerActionNames()
        {
            var controller = ControllerContext.ActionDescriptor.ControllerName;
            var action = ControllerContext.ActionDescriptor.ActionName;

            return $"{controller} - {action}";
        }

        private ObjectResult InternalError(string message)
        {
            _logger.LogError(message);
            return StatusCode(500, "Something went wrong. Please contact the Administrator");
        }
        
    }
}