using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harjoitustyo
{
    //enemy 1 marble colossus
    internal class Marblecolossus : Enemy
    {
        public Marblecolossus() : base("Marble Colossus", 200, 20, 10, 50)
        {

        }

        //failed escape line
        public override string EscapeLine => ("I can't let you escape.");

        public override void Speak()
        {
            

            //Marble colossus's last words
            string deathline = "You know not what kind of calamity you're bringing upon this realm.";
           
            if (IsDead)
            {
                Utils.ActionBreak(deathline);
            }
            else
            {
                //Colossus starting line
                string startingline = "You should have not come here. Now I can't let you live.";
                Utils.ActionBreak(startingline);
            }
        }
    }
}

