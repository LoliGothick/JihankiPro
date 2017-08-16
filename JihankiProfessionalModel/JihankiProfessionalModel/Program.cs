using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JihankiPro
{
    class Program
    {
        static void Main(string[] args)
        {
            var jihanki = Jihanki.Default;

            jihanki.Start();
        }
    }
}
