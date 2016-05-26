using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerTap.Facade.Model;


namespace BeerTap.Facade.Controller
{
    public class DomainServiceException : Exception
    {
        public DomainServiceException(string message) : base(message)
        {

        }
    }
    public interface IEmployeeTapService : IBeerTapService
    {
        Task<Beer> UpdateTap(int officeId, int beerId,int employeeId);
    }
    public class EmployeeTapService : IEmployeeTapService
    {
        private readonly Model.BeerTap _db = new Model.BeerTap();

        Task<Beer> IEmployeeTapService.UpdateTap(int officeId, int beerId,int employeeId)
        {
            var officeBeer = ValidateOfficeBeer(officeId, beerId);
            if (officeBeer.Result == null)
                throw new DomainServiceException(string.Format("Office: {0} or Beer: {1} does not exist Mate!", officeId, beerId));

            var officeEmployee = ValidateOfficeEmployee(officeId, employeeId);
            if (officeEmployee.Result == null)
                throw new DomainServiceException(string.Format("Employee Id: {0} don't have the rights to get a beer Mate!", employeeId));

            if (officeEmployee.Result.Driving == true)
                if (officeEmployee.Result.BeerCount > 5)
                    throw new DomainServiceException(string.Format("Drunk driving is prohibited Mate! You already have {0} glass of beer!", officeEmployee.Result.BeerCount));

            if (officeBeer.Result.mL == 0)
                throw new DomainServiceException(string.Format("Your glass can't fill with remaining beer {0} on the container Mate!", beerId));

            if (officeBeer.Result.mL < 100)
            {
                officeBeer.Result.mL = 0;
            }
            else
            {
                officeBeer.Result.mL -= 100;
            }

            officeEmployee.Result.BeerCount += 1;
            
            _db.SaveChanges();
            return Task.FromResult(officeBeer.Result);
        }

        private Task<Beer> ValidateOfficeBeer(int officeId, int beerId)
        {
            var officeBeer = _db.Beers
                            .Where(b => b.OfficeId == officeId && b.Id == beerId);

            return Task.FromResult(officeBeer.FirstOrDefault());
        }
        private Task<Employee> ValidateOfficeEmployee(int officeId, int employeeId)
        {
            var officeEmployee = _db.Employees
                                .Where(b => b.OfficeId == officeId && b.Id == employeeId);

            return Task.FromResult(officeEmployee.FirstOrDefault());
        }
    }
}
