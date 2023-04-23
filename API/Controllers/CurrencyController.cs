﻿using API.Models;
using API.ViewModels.Currency;
using AutoMapper;
using BankApplicationModels;
using BankApplicationServices.IServices;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly ILogger<CurrencyController> _logger;
        private readonly IMapper _mapper;
        private readonly ICurrencyService _currencyService;

        public CurrencyController(ILogger<CurrencyController> logger, IMapper mapper, ICurrencyService currencyService)
        {
            _logger = logger;
            _mapper = mapper;
            _currencyService = currencyService;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{bankId}")]
        public async Task<ActionResult<List<CurrencyDto>>> GetAllCurrencies([FromRoute] string bankId)
        {
            try
            {
                _logger.Log(LogLevel.Information, message: "Fetching the Currencies");
                IEnumerable<Currency> currencies = await _currencyService.GetAllCurrenciesAsync(bankId);
                List<CurrencyDto> currencyDtos = _mapper.Map<List<CurrencyDto>>(currencies);
                return Ok(currencyDtos);
            }
            catch (Exception)
            {
                _logger.Log(LogLevel.Error, message: "Fetching the Currencies Failed");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching the Currencies.");
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{bankId}/{currencyCode}")]
        public async Task<ActionResult<CurrencyDto>> GetCurrencyByCode([FromRoute] string bankId,[FromRoute] string currencyCode)
        {
            try
            {
                _logger.Log(LogLevel.Information, message: $"Fetching Currerncy with Code {currencyCode}");
                Currency currency = await _currencyService.GetCurrencyByCode(currencyCode, bankId);
                if (currency is null)
                {
                    return NotFound();
                }
                CurrencyDto currencyDto = _mapper.Map<CurrencyDto>(currency);
                return Ok(currencyDto);
            }
            catch (Exception)
            {
                _logger.Log(LogLevel.Error, message: $"Fetching Currency with Code {currencyCode} Failed");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching the Currency by Code.");
            }
        }


        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<ActionResult<Message>> AddCurrency([FromBody] CurrencyViewModel currencyViewModel)
        {
            try
            {
                _logger.Log(LogLevel.Information, message: $"Adding a new Currency");
                Message message = await _currencyService.AddCurrencyAsync(currencyViewModel.BankId, currencyViewModel.CurrencyCode, currencyViewModel.ExchangeRate);
                return Ok(message.ResultMessage);
            }
            catch (Exception)
            {
                _logger.Log(LogLevel.Error, message: $"Adding a new Currency Failed");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while creating the Currency.");
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut]
        public async Task<ActionResult<Message>> UpdateCurrency([FromBody] CurrencyViewModel currencyViewModel)
        {
            try
            {
                _logger.Log(LogLevel.Information, message: $"Updating Currency with Code {currencyViewModel.CurrencyCode}");
                Message message = await _currencyService.UpdateCurrencyAsync(currencyViewModel.BankId, currencyViewModel.CurrencyCode, currencyViewModel.ExchangeRate);
                return Ok(message.ResultMessage);
            }
            catch (Exception)
            {
                _logger.Log(LogLevel.Error, message: $"Updating Currency with Code {currencyViewModel.CurrencyCode} Failed");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while updating the Currency.");
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{bankId}/{currencyCode}")]
        public async Task<ActionResult<Message>> DeleteCurrency([FromRoute] string bankId, [FromRoute] string currencyCode)
        {
            try
            {
                _logger.Log(LogLevel.Information, message: $"Deleting Currency with Code {currencyCode}");
                Message message = await _currencyService.DeleteCurrencyAsync(bankId,currencyCode);
                return Ok(message.ResultMessage);
            }
            catch (Exception)
            {
                _logger.Log(LogLevel.Error, message: $"Deleting Currency with Code {currencyCode} Failed");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while Deleting the Currency.");
            }
        }
    }
}
