using System;
using System.Collections.Generic;
using System.Linq;
using Cranberries.Util;

namespace JihankiPro
{
    public class Jihanki
    {
        private DrinkTable products;


        private IEnumerable<Drinks> MakeDrinkList(params (String name, int price, uint stock)[] list)
        {
            foreach(var tuple in list)
            {
                yield return new Drinks(new DrinkInfo(tuple.name, tuple.price), tuple.stock);
            }
        }

        public Jihanki(List<Drinks> drinks)
            => products = new DrinkTable(drinks);

        public Jihanki(params (String name, int price, uint stock)[] drinks)
            => products = new DrinkTable(MakeDrinkList(drinks).ToList());

        static public Jihanki Default
            => new Jihanki(
            ("おいしいみず", 200, 5),
            ("サイコソーダ", 300, 5),
            ("ミックスオレ", 350, 5),
            ("あごだし", 500, 10)
        );


        public void ShowLineup()
        {
            var len = products.Select(_ => _.Name.Length).Max();
            foreach(var (i, name, price, is_sold_out, space)
                in products.Select( (_, index) => (index, _.Name, _.Price, _.IsSoldout, new String(' ' ,(len-_.Name.Length)*2+1)) )
            ){
                if(is_sold_out)
                    Console.WriteLine($"[{i,00}] {name}{space}売り切れです！");
                else
                    Console.WriteLine($"[{i,00}] {name}{space}{price}円");
            }
        }


        internal void DrinkEvent()
        {
            Console.WriteLine("先にお金を入力してください");
            var v = int.Parse(Console.ReadLine());
            while (true)
            {
                ShowLineup();
                Console.WriteLine($"今 {v}円 入ってます");
                Console.WriteLine("どれを買う？（商品番号を指定してください）");
                var index = int.Parse(Console.ReadLine());
                if (index >= products.Count)
                {
                    Console.WriteLine($"[{index,00}]番の商品はありません！");
                    continue;
                }
                products[index]--;
                if (v >= products[index].Price)
                {
                    Console.WriteLine($"ガコン！{products[index].Name}が出てきた！");
                    v -= products[index].Price;
                    Console.WriteLine($"今 {v}円 入ってます");
                    Console.WriteLine("もう一本買う？（y/n）");
                    if (Console.ReadLine() == "n") break;
                }
                Console.WriteLine("お金を追加しますか？（y/n）");
                if (Console.ReadLine() == "y")
                {
                    v += int.Parse(Console.ReadLine());
                }
            }
            Console.WriteLine($"お釣りは{v}円です");
        }

        public void Start()
        {
            DrinkEvent();
        }

    }
}
