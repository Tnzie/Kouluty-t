using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harjoitustyo
{
    internal class AccursedMinion : Enemy
    {
        public AccursedMinion() : base("Accursed Minion",50,10,0,10)
        {

        }
        
        //accursed minions cool lines
        //Escapeline
        public override string EscapeLine => "DON'T RUN COWARD!";
        public override void Speak()
        {
            

            //Accursed minions last words
            string deathline = "AAARRGGHH!";
            
            //enemy starting line and deathline
            if (IsDead)
            {
                Utils.ActionBreak(deathline, ConsoleColor.White);
            }
            else
            {
                //Accursed minion starting line
                string startingline = "For our king!";
                Utils.ActionBreak(startingline);
            }
        }

    }
}

