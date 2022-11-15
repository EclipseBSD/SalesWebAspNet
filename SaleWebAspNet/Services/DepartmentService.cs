using SaleWebAspNet.Data;
using SaleWebAspNet.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


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
        //Utilizando o objeto Task transformando em uma lista assíncrona.
        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }

    }
}
