using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyThirdDayApp
{
    internal class generic
    {
        static void main(string[] args)
        {
            DtStation<int> dts = new DtStation<int>();
            dts.Data = 21212;
            Console.WriteLine(dts.Data);
            KeyValue<string,string> kv= new KeyValue<string,string>();
            kv.key = "123123";
            kv.value = "Morbius";
            Console.WriteLine(kv.key+" "+kv.value);
        }
        class DtStation<T>
        {
            public int Data { get; set; }
        }
        class KeyValue<Tkey, Tvalue>
        {
            public Tkey key { get; set; }
            public Tvalue value { get; set; }
        }
    }
}
