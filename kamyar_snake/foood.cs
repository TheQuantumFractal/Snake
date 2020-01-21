using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace kamyar_snake
{
    public class foood
    {
        public int x;
        public int y;


        public void generate(Size ClientSize, Random rand)
        {
            x = rand.Next(0, ClientSize.Width);

        }

    }
}
