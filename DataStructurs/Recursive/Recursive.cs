using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructurs.Recursive
{
    public class Recursive
    {
        // faktöriyel recursive cozum
        public static  int Fact(int num, int a =1)
        {
            int top = 0;

            if (num == 0 || num == 1)
                return 1;
            if (a <= num)
            {
                int carp = 1;
                for(int i=1; i<=a; i++)
                {
                    carp = carp * i;
                }

                top =carp + Fact(++a);
            }
            return top;
        }
    }
}
