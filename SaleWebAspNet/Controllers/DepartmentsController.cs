using Microsoft.AspNetCore.Mvc;
using SaleWebAspNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleWebAspNet.Controllers
{
    public class DepartmentsController : Controller
    {
        public IActionResult Index()
        {
            //Creating Departments' List:
            List<Department> list = new List<Department>();
            list.Add(new Department() { Id = 1, Name = "Eletronics" });
            list.Add(new Department() { Id = 2, Name = "Fashion" });

            return View(list);
        }
    }
}
