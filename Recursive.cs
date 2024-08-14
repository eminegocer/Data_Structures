using System;

public class Class1
{
	public Class1()
	{
        // faktöriyel recursive cozum
        public int Fact(int num)
        {
            int top = 1;
            int a = 1;

            if (num = 0 || num = 1)
                return 1;
            if (a <= num)
            {
                top += Fact(++a);
            }
            return top;

        }

    }


   
}
