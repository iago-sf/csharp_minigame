using System;
using System.Collections.Generic;
using System.Text;

namespace herencias
{
    public interface ICell
    {
        public Item hasItem { set; get; }
        public Container chest { set; get; }



        void Display();
    }
}