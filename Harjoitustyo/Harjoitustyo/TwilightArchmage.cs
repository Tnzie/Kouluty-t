using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harjoitustyo
{
    internal class TwilightArchmage : Enemy
    {
        public TwilightArchmage(): base("Twilight Archmage", 300, 50, 10, 100) 
        {
        
        }
        //failed escape line 
        public override string EscapeLine => ("Where do you think youre going?");
        public override void Speak()
        {
            //Archmages last words
            string deathline = "My beatiful creation will avenge me...";
            if (IsDead)
            {
                Utils.SayLine(deathline);
            }
            else
            {
                //Archmage has a starting line
                string startingline = "Fresh souls for my experiments. How lovely!";
                Utils.ActionBreak(startingline);
            }
        }
    }
}
