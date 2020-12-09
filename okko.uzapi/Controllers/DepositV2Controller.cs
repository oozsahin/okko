using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using okko.uzapi.DTOs;
using okko.uzapi.Contracts;

namespace UZMiswebapi.Controllers
{
    [Authorize]
    [Route("api/v{version:apiVersion}/deposits")]
    [ApiVersion("2.0")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class DepositV2Controller : ControllerBase
    {
        private readonly IDepositRepository _npRepo;
        private readonly IMapper _mapper;
        public DepositV2Controller(IDepositRepository npRepo, IMapper mapper)
        {
            _npRepo = npRepo;
            _mapper = mapper;
        }
        /// <summary>
        /// Get list of Deposits v2.
        /// </summary>
        /// <returns>Deposits</returns>
        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<DepositDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IEnumerable<DepositDto>> GetDeposits([FromBody] DepositDto model)
        {
            IEnumerable<DepositDto> resultList;
            resultList = await _npRepo.GetDeposits(model.Date_Open.ToString("dd.MM.yyyy"));
            //var objDto = new List<DepositDto>();
            //foreach (var obj in objList)
            //{
            //    objDto.Add(_mapper.Map<DepositDto>(obj));
            //}
            return resultList;
        }
    }
}