using System;
using System.Collections.Generic;
using System.Linq;

namespace JihankiPro {
    /// <summary>
    /// Summary description for Class1
    /// </summary>
    public class DrinkTable : IEnumerable<Drinks>
    {
        private List<Drinks> table;

        public DrinkTable(List<Drinks> drinks) => this.table = drinks.ToList();

        public Drinks this[int n]
        {
            set => table[n] = value;
            get => table[n];
        }

        public int Count => table.Count;

        public IEnumerator<Drinks> GetEnumerator()
        {
            foreach (Drinks val in table)
            {
                yield return val;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}