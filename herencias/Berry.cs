using System;
using System.Collections.Generic;
using System.Text;

namespace herencias
{
    public class Berry : Item
    {
        public Berry()
        {
            name = "Berry";
        }

        public override void Action()
        {
            base.Action();
            Console.WriteLine("You healed 5 eating a berry");
        }
    }
}