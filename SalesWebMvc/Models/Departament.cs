using System;
using System.Linq;
using System.Collections.Generic;

namespace SalesWebMvc.Models
{
    public class Departament
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>(); // Associação do Departament com Seller

        public Departament()
        {
        }

        public Departament(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public void AddSeller(Seller seller)
        {
            Sellers.Add(seller);
        }
        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sellers.Sum(se => se.TotalSales(initial, final));
        }
    }
}
