using System;
using System.Collections.Generic;
using System.Text;

namespace herencias
{
    public class Yuan : Enemy
    {
        public Yuan(int nposx, int nposy) 
        {
            posX = nposx;
            posY = nposy;
        }

        public override void Move(int movX, int movY)
        {
            base.Move(movX, movY);
        }

        public override void Display()
        {
            base.Display();
            Console.Write("¥");
        }
    }
}