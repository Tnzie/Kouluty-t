using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harjoitustyo
{
    class Armor : IItem
    {
        //name and price of armor
        public string Name { get; set; }
        public int Price { get; set; }
        //how much defence it gives
        public int Defence { get; set; }
        
        //is the item owned
        public bool Owned { get; set; }
        //item is equipped?
        public bool IsEquipped { get; set; }

        public Armor(string name, int price, int defence)
        {
            this.Name = name;
            this.Price = price;
            this.Defence = defence;
        }

        public void Use(Player playersName)
        {
            
        }
    }
}
