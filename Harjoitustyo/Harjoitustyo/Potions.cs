using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harjoitustyo
{
    internal class Potions : IItem
    {
        public string Name { get; set; }
        //items price
        public int Price { get; set; }

        //item is equipped?
        public bool IsEquipped { get; set; }

        //item healing
        public int Heal { get; set; }

        public Potions(string name, int price, int heal)
        {
            this.Name = name;
            this.Price = price;
            Heal = heal;
        }
        public void HealPlayer(Player player)
        {
           player.CurrentHp += Heal;
        }
    }
}   
