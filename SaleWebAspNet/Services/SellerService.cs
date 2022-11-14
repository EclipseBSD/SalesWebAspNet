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

        //Implementação para adicionar um novo objeto no banco de dados e salvando as alterações.
        public void Insert(Seller obj)
        {
            obj.Department = _context.Department.First();
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
