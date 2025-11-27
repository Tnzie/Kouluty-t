using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harjoitustyo
{
    //rajapinta tavaroille
    internal interface IItem
    {
        //items name
        string Name { get; set; }
        //items price
        int Price { get; set; }

        //item is equipped?
        public bool IsEquipped { get; set; }
    }
}
