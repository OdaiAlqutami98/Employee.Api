using Employee.DataModel;
using Employee.Domain;
using Employee.Logic;
using Employee.Logic.Manager;
using Employee.Shared;
using Employee.Shared.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Employee.Api.Extension.Extension;


namespace Employee.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController(EmployeeManager _employeeManager) : ControllerBase
    {
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var employee = await _employeeManager.GetAll().ToListAsync();
            if (employee is not null)
            {
                return Ok(employee);
            }
            return BadRequest(false);
        }
        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(string id)
        {
            var employeeid = Guid.Parse(id);
            var employee = await _employeeManager.GetById(employeeid);
            if (employee is not null)
            {
                return Ok(employee);
            }
            return BadRequest(false);
        }
        [HttpGet]
        [Route("GetEmployee")]
        public IEnumerable<Employees> GetEmployee()
        {
            return _employeeManager.GetAll();
        }
        [HttpPost]
        [Route("AddEdit")]
        public async Task<IActionResult> AddEdit( EmployeeModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (model.EmployeeId is null)
            {
                Employees employee = new Employees();
                employee.Name = model.Name;
                employee.Email = model.Email;
                employee.HomeAddress = model.HomeAddress;
                employee.MobileNumber = model.MobileNumber;
                employee.FilePath = model.ImagePath;
                await _employeeManager.Add(employee);
                await _employeeManager.SaveChangesAsync();
                return Ok(new Response<bool>(true,"Employee Add successfully"));
            }
            else
            {
                var employees = await _employeeManager.Get(e => e.EmployeeId == model.EmployeeId).SingleOrDefaultAsync();
                if (employees is not null)
                {
                    employees.Name = model.Name;
                    employees.Email = model.Email;
                    employees.HomeAddress = model.HomeAddress;
                    employees.MobileNumber = model.MobileNumber;
                    employees.FilePath = model.ImagePath;
                    _employeeManager.Update(employees);
                    await _employeeManager.SaveChangesAsync();
                    return Ok(new Response<bool>(true,"Employee Update successfully"));
                }
            }
            return BadRequest(new Response<bool>());
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var employeeid = Guid.Parse(id);
            var employee = await _employeeManager.GetById(employeeid);
            if (employee is not null)
            {
                await _employeeManager.Delete(employee);
                await _employeeManager.SaveChangesAsync();
                return Ok(new Response<bool>(true,"Employee Deleted successfully"));
            }
            return BadRequest(new Response<bool>());
        }
    }
}
