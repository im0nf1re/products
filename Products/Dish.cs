using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products
{
    class Dish
    {
        public Dish(string name, bool basis, int id)
        {
            Id = id;
            Basis = basis;
            Name = name;
        }

        public bool Basis;
        public int Id;
        public string Name;



    }
}
