using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SaleWebAspNet.Data;
using SaleWebAspNet.Models;
using SaleWebAspNet.Services.Exceptions;
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
        //Transformando ela em um método assíncrono
        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Seller.ToListAsync();
        }

        //Implementação para adicionar um novo objeto no banco de dados e salvando as alterações.
        public async Task InsertAsync(Seller obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        //Retorna o id do vendedor e o departamento com o parâmetro em específico.
        public async Task<Seller> FindByIdAsync(int id)
        {
            return await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        //Remove o id do vendedor atráves de um id especificado.
        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Seller.FindAsync(id);
                _context.Seller.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateException)
            {
                throw new IntegrityException("Can't delete seller because he/she has sales");
            }
            
        }

        //Implementação para atualizar o objeto do Seller caso bate com o parâmetro do método.
        //Se passar por um if ele vai jogar uma exceção.
        public async Task UpdateAsync(Seller obj)
        {
            bool hasAny = await _context.Seller.AnyAsync(x => x.Id == obj.Id);

            if (!hasAny)
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

    }
}
