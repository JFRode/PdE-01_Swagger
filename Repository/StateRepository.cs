using PdE_01_BrazilianCitiesAPI.Infrastructure.Contexts;
using PdE_01_BrazilianCitiesAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace PdE_01_BrazilianCitiesAPI.Repository
{
    public class StateRepository : IStateRepository
    {
        private readonly BrazilianCitiesApiDbContext _dbContext;

        public StateRepository(BrazilianCitiesApiDbContext context)
        {
            _dbContext = context;
        }

        public void Add(State state)
        {
            _dbContext.States.Add(state);
            _dbContext.SaveChanges();
        }

        public State Find(long id)
        {
            return _dbContext.States.FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<State> GetAll()
        {
            return _dbContext.States.ToList();
        }

        public void Remove(long id)
        {
            var state = _dbContext.States.First(s => s.Id == id);

            if (state == null)
                return;

            _dbContext.States.Remove(state);
            _dbContext.SaveChanges();
        }

        public void Update(State state)
        {
            _dbContext.States.Remove(state);
            _dbContext.SaveChanges();
        }
    }
}