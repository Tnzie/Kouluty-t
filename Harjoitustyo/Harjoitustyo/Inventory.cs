using System;
using System.Collections.Generic;

namespace Harjoitustyo
{
    internal class Inventory
    {
        public int Weaponlimit { get; private set; }
        public int Armorlimit { get; private set; }
        public int Potionlimit { get; private set; }

        public List<Weapon> Weaponlist { get; set; }
        public List<Armor> Armorlist { get; set; }
        public List<Potions> Potionslist { get; set; }

        public Inventory(int weaponlimit, int armorlimit, int potionlimit)
        {
            Weaponlimit = weaponlimit;
            Armorlimit = armorlimit;
            Potionlimit = potionlimit;

            Weaponlist = new();
            Armorlist = new();
            Potionslist = new();
        }

        bool CanFitInInventory(object item)
        {
            return item switch
            {
                Weapon => Weaponlist.Count < Weaponlimit,
                Armor => Armorlist.Count < Armorlimit,
                Potions => Potionslist.Count < Potionlimit,
                _ => false
            };
        }

        public void AttemptPurchase(Player player, object item, int cost)
        {
            if (!CanFitInInventory(item))
            {
                Console.WriteLine("\nNo space left in inventory!");
                Console.ReadKey(true);
                return;
            }

            if (player.GoldAmount >= cost)
            {
                player.GoldAmount -= cost;
                AddItem(item);
                Console.WriteLine($"\nYou bought {item.GetType().Name} for {cost} gold!");
            }
            else
            {
                Console.WriteLine("\nNot enough gold!");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
        }

        public void AddItem(object item)
        {
            if (!CanFitInInventory(item))
            {
                Console.WriteLine("No more space left for this item.");
                return;
            }

            switch (item)
            {
                case Weapon weapon:
                    Weaponlist.Add(weapon);
                    Console.WriteLine($"{weapon.Name} added to inventory");
                    break;

                case Armor armor:
                    Armorlist.Add(armor);
                    Console.WriteLine($"{armor.Name} added to inventory");
                    break;

                case Potions potion:
                    Potionslist.Add(potion);
                    Console.WriteLine($"{potion.Name} added to inventory");
                    break;
            }
        }

        // ----------------------------
        // EQUIP SYSTEM
        // ----------------------------

        public void EquipWeapon(Player player)
        {
            Console.Clear();
            Console.WriteLine("Choose a weapon to equip:");

            for (int i = 0; i < Weaponlist.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Weaponlist[i].Name}");
            }

            Console.WriteLine("9. Cancel");

            char c = Console.ReadKey(true).KeyChar;

            if (c == '9') return;

            int index = c - '1';

            if (index >= 0 && index < Weaponlist.Count)
            {
                player.ActiveWeapon = Weaponlist[index];
                Console.WriteLine($"Equipped {player.ActiveWeapon.Name}!");
            }
            else
            {
                Console.WriteLine("Invalid choice!");
            }

            Console.ReadKey(true);
        }

        public void EquipArmor(Player player)
        {
            Console.Clear();
            Console.WriteLine("Choose armor to equip:");

            for (int i = 0; i < Armorlist.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Armorlist[i].Name}");
            }

            Console.WriteLine("9. Cancel");

            char c = Console.ReadKey(true).KeyChar;

            if (c == '9') return;

            int index = c - '1';

            if (index >= 0 && index < Armorlist.Count)
            {
                player.ActiveArmor = Armorlist[index];
                Console.WriteLine($"Equipped {player.ActiveArmor.Name}!");
            }
            else
            {
                Console.WriteLine("Invalid choice!");
            }

            Console.ReadKey(true);
        }
    }
}
