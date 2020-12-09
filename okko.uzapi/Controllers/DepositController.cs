using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using okko.uzapi.Contracts;
using okko.uzapi.DTOs;

namespace UZMiswebapi.Controllers
{
    [Authorize]
    [Route("api/v{version:apiVersion}/deposits")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class DepositController : ControllerBase
    {
        private readonly ILoggerService _logger;
        private readonly IDepositRepository _npRepo;
        private readonly IMapper _mapper;
        public DepositController(IDepositRepository npRepo, IMapper mapper, ILoggerService logger)
        {
            _npRepo = npRepo;
            _mapper = mapper;
            _logger = logger;
        }
        /// <summary>
        /// Get list of Deposits v1.
        /// </summary>
        /// <returns>Deposits</returns>
        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<DepositDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IList<DepositDto>> GetDeposits([FromBody] DepositDto model)
        {
            var location = GetControllerActionNames();
            IList<DepositDto> resultData = null;
            try
            {
                resultData = await _npRepo.GetDeposits(model.Date_Open.ToString("dd.MM.yyyy"));
            }
            catch (Exception e)
            {

                _logger.LogWarn($"{location}: {e.Message} - {e.InnerException}");
            }
            return resultData;
        }
        /// <summary>
        /// Get list of client type v1
        /// </summary>
        /// <returns>client type</returns>
        [AllowAnonymous]
        [HttpGet("GetUzClientType")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<UzClientTypeDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IList<UzClientTypeDto>> GetUzClientType()
        {           
            var location = GetControllerActionNames();
            IList<UzClientTypeDto> resultData = null;
            try
            {
                resultData = await _npRepo.GetUzClientType();
            }
            catch (Exception e)
            {

                _logger.LogWarn($"{location}: {e.Message} - {e.InnerException}");
            }
            return resultData;

        }
        /// <summary>
        /// Get list of deposits with criteria v1
        /// </summary>
        /// <param name="model"></param>
        /// <returns>deposits</returns>
        [AllowAnonymous]
        [HttpGet("GetSomeDeposits")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<DepositDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IList<DepositDto>> GetSomeDeposits([FromBody] DepositDto model)
        {
            var location = GetControllerActionNames();
            IList<DepositDto> resultData = null;
            try
            {
                resultData = await _npRepo.GetSomeDeposits(model.Branch, model.Date_Open.ToString("dd.MM.yyyy"), model.Code_Subject, model.File_Name, model.Currency_Code, model.Account_Type);
            }
            catch (Exception e)
            {

                _logger.LogWarn($"{location}: {e.Message} - {e.InnerException}");
            }
            return resultData;
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