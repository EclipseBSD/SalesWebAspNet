using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SaleWebAspNet.Models
{
    public class Seller
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} size should be between {2} and {1}")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [EmailAddress(ErrorMessage = "Enter a valid email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Birth Date")] //Atributo para definir o que vai ser mostrado na aplicação
        [DataType(DataType.Date)] //Atributo para definir o tipo de data na view
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")] //Formatando data para formato brasileiro
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Range(100.0, 50000.0, ErrorMessage = "{0} must be from {1} to {2}")]
        [Display(Name = "Base Salary")]
        [DisplayFormat(DataFormatString = "{0:F2}")] //Formatação do atributo com duas casa decimais
        public double BaseSalary { get; set; }

        public Department Department { get; set; }
        [Display(Name = "Department")]

        public int DepartmentId { get; set; }
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
