using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harjoitustyo
{
    internal class Player
    {

        //players name
        public string Name { get; set; }

        //players Max Hp
        public int MaxHp { get; set; }
        //players current HP
        public int CurrentHp { get; set; }
        //players gold amount
        public int GoldAmount { get; set; }

        //Players current weapon and armor
        public Weapon ActiveWeapon { get; set; }
        public Armor ActiveArmor { get; set; }

        public Inventory Inventory { get; set; }


        // players defence and is player dead
        public int Defence { get; set; }
        public bool IsDead { get; set; }

        //constructor for player class
        public Player(int maxHp, int GOLD_AMOUNT, Weapon START_WEAPON, Armor START_ARMOR)
        {
            //starting hp and starting gold amount
            MaxHp = maxHp;
            CurrentHp = MaxHp;
            GoldAmount = GOLD_AMOUNT;

            Inventory = new(4, 4, 10);
            Inventory.Weaponlist.Add(START_WEAPON);
            Inventory.Armorlist.Add(START_ARMOR);

            //starter gear
            ActiveWeapon = START_WEAPON;
            ActiveArmor = START_ARMOR;

        }

        //check if player is hit by enemy
        public int GetsHit(Enemy enemy)
        {
            int damagetaken = Math.Max(0, enemy.Damage - ActiveArmor.Defence);
            CurrentHp -= damagetaken;
            //damage calculation with players damage

            //check if player is dead
            if (CurrentHp <= 0)
            {
                //the player is dead
                IsDead = true;
            }
            return damagetaken;
        }

        //restore HP after losing a battle
        public void Revive()
        {
            //Restore player HP to max
            CurrentHp = MaxHp;

            //make player alive again
            IsDead = false;
        }

        public static int PlayerRng()
        {
            //randomizer for player, fleeing, crit etc.
            int playerRNG = Random.Shared.Next(1, 10);
            return playerRNG;
        }

        public void EquipMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Equip Menu ===");
                Console.WriteLine("1. Equip Weapon");
                Console.WriteLine("2. Equip Armor");
                Console.WriteLine("9. Back");

                char c = Console.ReadKey(true).KeyChar;

                switch (c)
                {
                    case '1':
                        Inventory.EquipWeapon(this);
                        break;
                    case '2':
                        Inventory.EquipArmor(this);
                        break;
                    case '9':
                        return;
                }
            }
        }


        public void CheckInventory()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Inventory ===");
                Console.WriteLine("1. View Weapons");
                Console.WriteLine("2. View Armor");
                Console.WriteLine("3. View Potions");
                Console.WriteLine("4. Equip Weapon");
                Console.WriteLine("5. Equip Armor");
                Console.WriteLine("9. Back");
                Console.Write("Choose an option: ");

                char choice = Console.ReadKey(true).KeyChar;

                switch (choice)
                {
                    case '1':
                        ShowWeapons();
                        break;

                    case '2':
                        ShowArmor();
                        break;

                    case '3':
                        ShowPotions();
                        break;

                    case '4':
                        Inventory.EquipWeapon(this);
                        break;

                    case '5':
                        Inventory.EquipArmor(this);
                        break;

                    case '9':
                        return;
                }
            }
        }

        private void ShowWeapons()
        {
            Console.Clear();
            Console.WriteLine("Your Weapons:");

            if (Inventory.Weaponlist.Count == 0)
                Console.WriteLine("No weapons");
            else
                foreach (var w in Inventory.Weaponlist)
                    Console.WriteLine($"- {w.Name}");

            Console.WriteLine("\nEquipped: " + ActiveWeapon.Name);
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey(true);
        }

        private void ShowArmor()
        {
            Console.Clear();
            Console.WriteLine("Your Armor:");

            if (Inventory.Armorlist.Count == 0)
                Console.WriteLine("No armor");
            else
                foreach (var a in Inventory.Armorlist)
                    Console.WriteLine($"- {a.Name}");

            Console.WriteLine("\nEquipped: " + ActiveArmor.Name);
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey(true);
        }

        private void ShowPotions()
        {
            Console.Clear();
            Console.WriteLine("Your Potions:");

            if (Inventory.Potionslist.Count == 0)
                Console.WriteLine("No potions");
            else
                foreach (var p in Inventory.Potionslist)
                    Console.WriteLine($"- {p.Name}");

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey(true);
        }


    }
}
