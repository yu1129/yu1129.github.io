using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pokemonLab.Models;
using pokemonLab.Service;
using pokemonLab.ViewModels;

namespace pokemonLab.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonService _pokemonService;

        public PokemonController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var result = _pokemonService.GetAllPokemon();
                return Ok(new APIResult(APIStatus.Success, string.Empty, result));
            }
            catch(Exception ex)
            {
                return Ok(new APIResult(APIStatus.Fail, ex.Message, null));
            }
        }

        [HttpPost]
        public IActionResult Create(PokemonVM query)
        {
            try
            {
                _pokemonService.CreatePokemon(query);
                return Ok(new APIResult(APIStatus.Success, string.Empty, true));
            }
            catch (Exception ex)
            {
                return Ok(new APIResult(APIStatus.Fail, ex.Message, false));
            }
        }

        [HttpPut]
        public IActionResult Update(PokemonVM query)
        {
            try
            {
                _pokemonService.UpdatePokemon(query);
                return Ok(new APIResult(APIStatus.Success, string.Empty, true));
            }
            catch (Exception ex)
            {
                return Ok(new APIResult(APIStatus.Fail, ex.Message, false));
            }
        }

        [HttpDelete]
        public IActionResult Delete(PokemonVM query)
        {
            try
            {
                _pokemonService.DeletePokemon(query);
                return Ok(new APIResult(APIStatus.Success, string.Empty, true));
            }
            catch (Exception ex)
            {
                return Ok(new APIResult(APIStatus.Fail, ex.Message, false));
            }
        }
    }
}
