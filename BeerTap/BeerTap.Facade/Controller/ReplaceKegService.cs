using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerTap.Facade.Model;

namespace BeerTap.Facade.Controller
{
    public interface IReplaceKegService : IBeerTapService
    {
        Task<Beer> ReplaceKeg(int officeId, int beerId);
    }
    public class ReplaceKegService : IReplaceKegService
    {
        private readonly Model.BeerTap _db = new Model.BeerTap();
        public Task<Beer> ReplaceKeg(int officeId, int beerId)
        {
            var officeBeer = ValidateOfficeBeer(officeId, beerId);
            if (officeBeer.Result == null)
                throw new DomainServiceException(string.Format("Office: {0} or Beer: {1} does not exist Mate!", officeId, beerId));

            officeBeer.Result.mL = officeBeer.Result.Container;
            _db.SaveChanges();
            return Task.FromResult(officeBeer.Result);
        }

        private Task<Beer> ValidateOfficeBeer(int officeId, int beerId)
        {
            var officeBeer = _db.Beers
                .Where(b => b.OfficeId == officeId && b.Id == beerId);

            return Task.FromResult(officeBeer.FirstOrDefault());
        }
    }
}
