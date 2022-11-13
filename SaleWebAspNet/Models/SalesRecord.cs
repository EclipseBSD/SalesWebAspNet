using SaleWebAspNet.Models.Enums;
using System;

namespace SaleWebAspNet.Models
{
    public class SalesRecord
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public SaleStatus Sales { get; set; }
        public Seller Seller { get; set; }

        public SalesRecord()
        {
        }

        public SalesRecord(int id, DateTime date, double amount, SaleStatus sales, Seller seller)
        {
            Id = id;
            Date = date;
            Amount = amount;
            Sales = sales;
            Seller = seller;
        }
    }
}
