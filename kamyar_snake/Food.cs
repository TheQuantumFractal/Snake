using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace kamyar_snake
{
    class Food
    {
        public int x;
        public int y;
        public Rectangle EllipseHit;


        public Food(Size ClientSize, Random rand)
        {
            generate(ClientSize, rand);
        }

        public void generate(Size ClientSize, Random rand)
        {
            for (int i = 1; i % 20 != 0; )
            {
                i = rand.Next(1, ClientSize.Width-20);
                x = i;
            }
            for (int i = 1; i % 20 != 0; )
            {
                i = rand.Next(1, ClientSize.Height - 20);
                y = i;
            }
            EllipseHit = new Rectangle(x, y, 20, 20);
        }

        public void Draw(Graphics gfx, Color brush)
        {
            gfx.FillEllipse(new SolidBrush(brush), x, y, 20, 20);
        }
    }
}
