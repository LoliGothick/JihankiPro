using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JihankiPro
{
    public class Drinks
    {
        private readonly DrinkInfo info;
        private uint stock;

        public Drinks(DrinkInfo info, uint ini) => (this.info, this.stock) = (info, ini);

        public (String, int, uint) InfoTuple => (info.Name, info.Price, stock);

        public String Name => info.Name;

        public int Price => info.Price;

        public uint Stock => stock;

        public bool IsSoldout => stock == 0;
 
        static public Drinks operator --(Drinks drinks)
        {
            drinks.stock--;
            return drinks;
        }
        static public Drinks operator+(Drinks drinks, uint n)
        {
            drinks.stock+=n;
            return drinks;
        }

    }
}
