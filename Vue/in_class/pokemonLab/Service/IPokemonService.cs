using System.Collections.Generic;
using pokemonLab.ViewModels;

namespace pokemonLab.Service
{
    public interface IPokemonService
    {
        public IEnumerable<PokemonVM> GetAllPokemon();
        public void CreatePokemon(PokemonVM query);
        public void UpdatePokemon(PokemonVM query);
        public void DeletePokemon(PokemonVM query);
    }
}