using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Card_Catalog
{
    class Vaildation
    {
        public static int IsInt(string anyValue, string option)
        {
            int num;
            while (!(int.TryParse(anyValue, out num)))
            {
                Console.Write("Enter {0}: ", option);
                anyValue = Console.ReadLine();
            }

            int.TryParse(anyValue, out num);
            return num;
        }

        public static decimal IsDecimal(string anyValue)
        {
            decimal money;
            while (!(decimal.TryParse(anyValue, out money)))
            {
                Console.Write("Enter price again: ");
                anyValue = Console.ReadLine();
            }

            decimal.TryParse(anyValue, out money);
            return money;
        }

        public static bool IsYorN(string anyValue)
        {
            anyValue = anyValue.ToUpper();
            switch (anyValue[0])
            {
                case 'Y':
                    return true;
                default:
                    return false;
            }
        }
    }
}
