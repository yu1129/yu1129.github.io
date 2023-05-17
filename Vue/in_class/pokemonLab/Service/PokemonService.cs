using System.Linq;
using System.Collections.Generic;
using pokemonLab.Models;
using pokemonLab.Repository;
using pokemonLab.ViewModels;

namespace pokemonLab.Service
{
    public class PokemonService : IPokemonService
    {
        private readonly IDBRepository _repository;

        public PokemonService(IDBRepository repository)
        {
            _repository = repository;
        }
        
        public void CreatePokemon(PokemonVM query)
        {
            var entity = new Pokemon()
            {
                Name = query.Name,
                NickName = query.NickName,
                Hp = query.Hp,
                Attack = query.Attack,
                Defanse = query.Defanse,
                SpAttack = query.SpAttack,
                SpDefense = query.SpDefense,
                Speed = query.Speed,
                Type = query.Type,
                Image = query.Image
            };

            _repository.Create(entity);
            _repository.Save();
        }

        public void DeletePokemon(PokemonVM query)
        {
            var target = _repository.GetAll<Pokemon>().FirstOrDefault(x => x.Id == query.Id);

            _repository.Delete(target);
            _repository.Save();
        }

        public IEnumerable<PokemonVM> GetAllPokemon()
        {
            return _repository.GetAll<Pokemon>().Select(x => new PokemonVM()
            {
                Id = x.Id,
                Name = x.Name,
                NickName = x.NickName,
                Hp = x.Hp,
                Attack = x.Attack,
                Defanse = x.Defanse,
                SpAttack = x.SpAttack,
                SpDefense = x.SpDefense,
                Speed = x.Speed,
                Type = x.Type,
                Image = x.Image
            });
        }

        public void UpdatePokemon(PokemonVM query)
        {
            var target = _repository.GetAll<Pokemon>().FirstOrDefault(x => x.Id == query.Id);

            target.NickName = query.NickName;
            target.Type = query.Type;

            _repository.Update(target);
            _repository.Save();
        }
    }
}