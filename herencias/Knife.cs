using System;
using System.Collections.Generic;
using System.Text;

namespace herencias
{
    public class Knife : Weapon
    {
        public Knife()
        {
            name = "Knife";
            damage = 7;
        }

        public override void Action()
        {
            Console.WriteLine("Has apuñalado " + damage);
        }
    }
}