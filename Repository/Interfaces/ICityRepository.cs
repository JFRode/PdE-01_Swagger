using PdE_01_BrazilianCitiesAPI.Models;
using System.Collections.Generic;

namespace PdE_01_BrazilianCitiesAPI.Repository
{
    public interface ICityRepository
    {
        void Add(City city);

        IEnumerable<City> GetAll();

        City Find(long id);

        void Remove(long id);

        void Update(City city);
    }
}