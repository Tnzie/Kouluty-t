using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harjoitustyo
{
    abstract class Weapon : IItem
    {
        //weapons name and price
        public string Name { get; set; }
        public int Price { get; set; }
        
        //checking if item is equipped
        public bool IsEquipped { get; set; }
        
        //weapons damage to enemies
        public int Damage { get; set; }

        public Weapon(string name, int price, int damage)
        {
            this.Name = name;
            this.Price = Price;
            this.Damage = damage;
            IsEquipped = false;

        }
    }
}
