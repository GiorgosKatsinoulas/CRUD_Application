using CRUDApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDApplication.Controllers
{
    public class CreateController : Controller
    {
        private  IEmployeeRepository _employeeRepository;

        public CreateController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        
        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
                
                _employeeRepository.Add(employee);
            
           
            return RedirectToAction("ViewEmployee");
        }

        public IActionResult ViewEmployee()
        {
            var model = _employeeRepository.GetAllEmployee();
            return View(model);
        }

        
        public IActionResult Delete(int Id)
        {
            
            var model = _employeeRepository.GetEmployee(Id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(Employee employee)
        {
            _employeeRepository.Delete(employee.Id);
            
            return RedirectToAction("ViewEmployee");
        }

        
        public IActionResult Details(Employee employee)
        {
            var model =_employeeRepository.GetEmployee(employee.Id);
            if (model == null)
            {
                Response.StatusCode = 404;
                return View("EmployeeNotFound", employee.Id);
            }
            return View(model);
        }

        public IActionResult Edit(int Id)
        {
            var model = _employeeRepository.GetEmployee(Id);
            if (model == null)
            {
                Response.StatusCode = 404;
                return View("EmployeeNotFound", Id);
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
             _employeeRepository.Update(employee);

            return RedirectToAction("ViewEmployee");
        }
    }
}
