using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harjoitustyo
{
    abstract class Enemy
    {
        //enemy names and stats
        public string Name { get; set; }
        public abstract string EscapeLine { get; }
        //elemental type of enemy

        //enemy stats
        public int MaxHp { get; set; }
        public int CurrentHp { get; set; }
        public int Damage { get; set; }
        public int Defence { get; set; }
        //reward for killing enemy
        public int Reward { get; set; }
        public bool IsDead { get; set; }
        //check if enemy is dead


        public Enemy(string name, int maxHp, int attack, int defence, int reward)
        {
            this.Name = name;
            this.MaxHp = maxHp;
            this.CurrentHp = maxHp;
            this.Damage = attack;
            this.Defence = defence;
            this.Reward = reward;
        }

        
        //check if player hit enemy
        public int GetsHit(Player player)
        {
            int damagetaken = Math.Max(0, player.ActiveWeapon.Damage - Defence);
            CurrentHp -= damagetaken;

            //check if enemy is dead
            if (CurrentHp <= 0)
            {
                //the enemy is dead
                IsDead = true;
            }
            
            return damagetaken;
        }
        //Enemies need to speak
        virtual public void Speak()
        {
            //enemy starting line and deathline
            string startingline = "Enemy starts the battle by saying something cool";
            string deathline = "Enemys last words";

            if (IsDead)
            {
                Utils.ActionBreak(deathline);
            }
            else 
            {
                Utils.ActionBreak(startingline);
            }
            
        }
    }

}
