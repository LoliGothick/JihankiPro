using System;
namespace JihankiPro
{
    /// <summary>
    /// Summary description for Class1
    /// </summary>
    public class DrinkInfo
    {
        private readonly string name;
        private readonly int price;

        public string Name
        {
            get => name;
        }

        public int Price
        {
            get => price;
        }

        public DrinkInfo(string name, int price) => (this.name, this.price) = (name, price);
    }
}