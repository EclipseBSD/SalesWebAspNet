using System;
using System.Linq;
using System.Collections.Generic;

namespace SaleWebAspNet.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>(); //Associação com ICollection de vendedores

        public Department()
        {
        }

        //Instânciamos um construtor sem conter a coleção
        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }

        //Adiciona um vendedor no departamento.
        public void AddSeller(Seller seller)
        {
            Sellers.Add(seller);
        }

        //Faz uma soma com o LINQ onde calcula o total de vendas em um intervalo de tempo.
        //Aproveitando também o método criado a partir da classe Seller.
        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sellers.Sum(seller => seller.TotalSales(initial, final));
        }

    }
}
