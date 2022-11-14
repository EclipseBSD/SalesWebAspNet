﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace SaleWebAspNet.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>(); //Associação com ICollection

        public Seller()
        {
        }

        //Instânciamos um construtor sem conter a coleção
        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        //Adiciona vendas em nossa lista
        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }

        //Remove vendas em nossa lista
        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        //Calculando o total de vendas a partir de um intervalo de uma data inicial e final
        //Utilizando assim uma expressão lambda com o LINQ
        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }
    }
}