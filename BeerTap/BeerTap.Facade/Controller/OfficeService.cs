using System.Collections.Generic;
using BeerTap.Facade.Model;
using System.Threading.Tasks;

namespace BeerTap.Facade.Controller
{
    public interface IOfficeService : IBeerTapService
    {
        IEnumerable<Office> GetAll();
        Task<Office> GetOfficeById(int id);
        Office Update(Office office);
        Office Add(Office office);
    }
    public class OfficeService : IOfficeService
    {
        private readonly Model.BeerTap _db = new Model.BeerTap();

        public Office Add(Office office)
        {
            _db.Offices.Add(office);
            _db.SaveChanges();
            return office;
        }

        public IEnumerable<Office> GetAll()
        {
            return _db.Offices;
        }

        public Office Update(Office office)
        {
            var _office = Task.FromResult(_db.Offices.Find(office.Id));
            if (_office.Result == null)
                throw new DomainServiceException(string.Format("Office: {0} does not exist Mate!", _office.Id));

            _office.Result.Name = office.Name;
            _office.Result.Description = office.Description;
            _db.SaveChanges();
            return office;
        }

        Task<Office> IOfficeService.GetOfficeById(int id)
        {
            return Task.FromResult(_db.Offices.Find(id));
        }

    }
}
