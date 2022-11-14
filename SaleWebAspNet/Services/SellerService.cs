using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SaleWebAspNet.Data;
using SaleWebAspNet.Models;
using Microsoft.EntityFrameworkCore;

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
            _context.Add(obj);
            _context.SaveChanges();
        }

        //Retorna o id do vendedor e o departamento com o parâmetro em específico.
        public Seller FindById(int id)
        {
            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);
        }

        //Remove o id do vendedor atráves de um id especificado.
        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }

    }
}
