using System.Linq;
using pokemonLab.Models;

namespace pokemonLab.Repository {
    public interface IDBRepository {
        public PokemonContext DBContext { get; }
        public void Create<T>(T entity) where T : class;
        public void Update<T>(T entity) where T : class;
        public void Delete<T>(T entity) where T : class;
        public IQueryable<T> GetAll<T>() where T : class;
        public void Save();
    }
}