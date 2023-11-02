using EFLCT.Context;
using EFLCT.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EFLCT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private CompanyContext _companyContext;

        public EmployeeController (CompanyContext companyContext)
        {
            _companyContext = companyContext;
        }

        /// <summary>
        /// Create API for Employee details adding 
        /// </summary>
        /// <param name="request"> Employee Id value need not provide </param>        
        [HttpPost]
        public void CreateEmployee( Employee request)
        {
            _companyContext.Employees.Add(request);
            _companyContext.SaveChanges();
        }

        /// <summary>
        /// API for updating Employee details 
        /// </summary>
        /// <param name="id">Employee Id</param>
        /// <param name="request">Employee Id value need to provide </param>
        [HttpPut("{id}")]
        public void UpdateEmployee(int id, Employee request)
        {
            var employee = _companyContext.Employees.FirstOrDefault(s => s.EmployeeId == id);
            if (employee != null)
            {
                _companyContext.Entry<Employee>(employee).CurrentValues.SetValues(request);
                _companyContext.SaveChanges();
            }
        }


        //  Get Employee API
        [HttpGet]
        public IEnumerable<Employee> GetEmployee()
        {
            return _companyContext.Employees;
        }

        // Get Employee By Id 
        [HttpGet("{id}")]
        public Employee GetEmployeeById(int id)
        {
            return _companyContext.Employees.FirstOrDefault(s => s.EmployeeId == id);
        }

        /// <summary>
        /// Delete employee details using employee id 
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var student = _companyContext.Employees.FirstOrDefault(s => s.EmployeeId == id);
            if (student != null)
            {
                _companyContext.Employees.Remove(student);
                _companyContext.SaveChanges();
            }
        }


    }
}
