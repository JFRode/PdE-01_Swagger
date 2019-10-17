using PdE_01_BrazilianCitiesAPI.Infrastructure.Contexts;
using PdE_01_BrazilianCitiesAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace PdE_01_BrazilianCitiesAPI.Repository
{
    public class CityRepository : ICityRepository
    {
        private readonly BrazilianCitiesApiDbContext _dbContext;

        public CityRepository(BrazilianCitiesApiDbContext context)
        {
            _dbContext = context;
        }

        public void Add(City city)
        {
            _dbContext.Cities.Add(city);
            _dbContext.SaveChanges();
        }

        public City Find(long id)
        {
            return _dbContext.Cities.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<City> GetAll()
        {
            return _dbContext.Cities.ToList();
        }

        public void Remove(long id)
        {
            var city = _dbContext.Cities.First(c => c.Id == id);

            if (city == null)
                return;

            _dbContext.Cities.Remove(city);
            _dbContext.SaveChanges();
        }

        public void Update(City city)
        {
            _dbContext.Cities.Update(city);
            _dbContext.SaveChanges();
        }
    }
}