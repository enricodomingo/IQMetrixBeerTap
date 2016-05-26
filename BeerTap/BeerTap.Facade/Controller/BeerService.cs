using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using BeerTap.Facade.Model;

namespace BeerTap.Facade.Controller
{
    public interface IBeerService : IBeerTapService
    {
        IEnumerable<Beer> GetAll(int officeId);
        Task<Beer> GetBeerById(int id,int officeId);
        Beer Update(Beer beer);
        Beer Add(Beer beer);
    }
    public class BeerService : IBeerService
    {
        //private readonly IDictionary<int, BeerModel> _beer;
        private readonly Model.BeerTap _db = new Model.BeerTap();
        public BeerService()
        {

        }
        public Beer Add(Beer beer)
        {
            _db.Beers.Add(beer);
            _db.SaveChanges();
            return beer;
        }

        public IEnumerable<Beer> GetAll(int officeId)
        {
            return _db.Beers
                .Where(b => b.OfficeId == officeId).AsEnumerable();
        }

        public Task<Beer> GetBeerById(int id, int officeId)
        {
            var beer = _db.Beers
                .Where(b => b.OfficeId == officeId && b.Id == id);

            return Task.FromResult(beer.FirstOrDefault());
        }

        public Beer Update(Beer beer)
        {
            var _beer = GetBeerById(beer.Id,beer.OfficeId);
            if (_beer.Result == null)
                throw new DomainServiceException(string.Format("Office: {0} or Beer: {1} does not exist Mate!", beer.OfficeId ,beer.Id ));

            _beer.Result.Name = beer.Name;
            _beer.Result.Container = beer.Container;
            _beer.Result.mL = beer.mL;
            _db.SaveChanges();
            return beer;
        }
    }
}
