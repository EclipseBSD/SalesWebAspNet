using SaleWebAspNet.Data;
using SaleWebAspNet.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleWebAspNet.Services
{
    public class SalesRecordService
    {
        private readonly SaleWebAspNetContext _context;

        public SalesRecordService(SaleWebAspNetContext context)
        {
            _context = context;
        }

        //Método para retornar uma busca de vendas por data entre o valor mínimo e o máximo.
        //Utilizando a operação assíncrona.
        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecords select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }

            return await result
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .OrderByDescending(x => x.Date)
                .ToListAsync();
        }
    }
}
