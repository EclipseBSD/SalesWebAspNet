using System.Linq;
using System.Collections.Generic;
using SaleWebAspNet.Data;
using SaleWebAspNet.Models;

namespace SaleWebAspNet.Services
{
    public class DepartmentService
    {
        private readonly SaleWebAspNetContext _context;

        public DepartmentService(SaleWebAspNetContext context)
        {
            _context = context;
        }

        //Implementação que retorna a lista de departamentos ordenadamente.
        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }

    }
}
