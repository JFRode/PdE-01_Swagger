using PdE_01_BrazilianCitiesAPI.Models;
using System.Collections.Generic;

namespace PdE_01_BrazilianCitiesAPI.Repository
{
    public interface IStateRepository
    {
        void Add(State state);

        IEnumerable<State> GetAll();

        State Find(long id);

        void Remove(long id);

        void Update(State state);
    }
}