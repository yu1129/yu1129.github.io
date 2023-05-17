using System.Linq;
using Microsoft.EntityFrameworkCore;
using pokemonLab.Models;

namespace pokemonLab.Repository
{
    public class DBRepository : IDBRepository
    {
        private readonly PokemonContext _dbContext;

        public DBRepository(PokemonContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public PokemonContext DBContext => _dbContext;

        public void Create<T>(T entity) where T : class
        {
            _dbContext.Entry<T>(entity).State = EntityState.Added;
        }

        public void Delete<T>(T entity) where T : class
        {
            _dbContext.Entry<T>(entity).State = EntityState.Deleted;
        }

        public IQueryable<T> GetAll<T>() where T : class
        {
            return _dbContext.Set<T>();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Update<T>(T entity) where T : class
        {
            _dbContext.Entry<T>(entity).State = EntityState.Modified;
        }
    }
}