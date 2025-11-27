using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harjoitustyo
{
    internal class CorruptedKing : Enemy
    {
        public CorruptedKing() : base("The Corrupted King", 4000, 200, 100, 1000)
        {

        }
        
        //failed escape line 
        public override string EscapeLine => ("Corruption can't be escaped!");
       
        public override void Speak()
        {
            //Kings last words
            string deathline = "I have failed...";
            if (IsDead)
            {
                Utils.SayLine(deathline);
            }
            else
            {
                //King has starting line
                string startingline = "You managed to get into my castle. Unfortunately this is where your story ends.";
                Utils.ActionBreak(startingline);
            }
        }
    }
}
