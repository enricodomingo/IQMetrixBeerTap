using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerTap.Facade.Model;

namespace BeerTap.Facade.Controller
{
    public interface IEmployeeService : IBeerTapService
    {
        IEnumerable<Employee> GetAll(int officeId);
        Task<Employee> GetEmployeeById(int id, int officeId);
        Employee Add(Employee employee);
        Employee Update(Employee employee);
    }
    public class EmployeeService : IEmployeeService
    {
        private readonly Model.BeerTap _db = new Model.BeerTap();

        public Employee Add(Employee employee)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetAll(int officeId)
        {
            return _db.Employees
                    .Where(b => b.OfficeId == officeId).AsEnumerable();
        }

        public Task<Employee> GetEmployeeById(int id, int officeId)
        {
            var employee = _db.Employees
                    .Where(b => b.OfficeId == officeId && b.Id == id);

            return Task.FromResult(employee.FirstOrDefault());
        }

        public Employee Update(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
