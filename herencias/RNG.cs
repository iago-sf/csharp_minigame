using System;
using System.Collections.Generic;
using System.Text;

namespace herencias
{
    public static class RNG
    {
        private static Random rng = new Random();
        public static int Nums(int numero)
        {
            return rng.Next(0, numero);
        }
        public static int Nums(int a, int b)
        {
            return rng.Next(a, b);
        }
    }
}