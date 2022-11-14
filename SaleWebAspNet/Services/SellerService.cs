using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SaleWebAspNet.Data;
using SaleWebAspNet.Models;

namespace SaleWebAspNet.Services
{
    public class SellerService
    {
        private readonly SaleWebAspNetContext _context;

        public SellerService(SaleWebAspNetContext context)
        {
            _context = context;
        }

        //Implementação para retornar todos os vendedores em uma lista.
        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }
    }
}
