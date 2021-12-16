using System;
using System.Collections.Generic;
using System.Text;

namespace herencias
{
    public class Stick : Weapon
    {

        public Stick()
        {
            name = "Stick";
            damage = 2;
        }

        public override void Action()
        {
            Console.WriteLine("Has golpeado " + damage);
        }
    }
}