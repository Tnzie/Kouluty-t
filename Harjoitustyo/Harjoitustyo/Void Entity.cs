using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harjoitustyo
{
    internal class VoidEntity : Enemy
    {
        public VoidEntity(): base("Void Entity", 550, 50, 40,200)
        {
            
        }
        //failed escape line 
        public override string EscapeLine => ("I won't let you leave!");

        public override void Speak()
        {           
            //Void Entitys last words
            string deathline = "I failed you master. The void is no longer.";
            if (IsDead)
            {
                Utils.SayLine(deathline);
            }
            else
            {
                //Void entity has a starting line
                string startingline = "You slayed my master! I will avenge her!";
                Utils.ActionBreak(startingline);
            }
        }
    }
}
