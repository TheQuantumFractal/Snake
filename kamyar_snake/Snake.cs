using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace kamyar_snake
{
    public class Snake
    {

        public List<SnakePiece> pieces;

        public Snake(Point point, Size size, Color color)
        {
            pieces = new List<SnakePiece>();
            pieces.Add(new SnakePiece(point, size, color, SnakePiece.Direction.None));
        }


        public void Draw(Graphics gfx)
        {
            for (int i = 0; i < pieces.Count; i++)
            {
                pieces[i].Draw(gfx);
            }
        }

        public void Erase(Graphics gfx, Color backColor)
        {
            for (int i = 0; i < pieces.Count; i++)
            {
                pieces[i].Erase(gfx, new SolidBrush(backColor));
            }
        }

        public void Move(Size ClientSize)
        {
            for (int i = 0; i < pieces.Count; i++)
            {
                pieces[i].Move(ClientSize);
            }
        }

        public void ChangeDirection()
        {
            for (int i = pieces.Count - 1; i > 0; i--)
            {
                pieces[i].Direct = pieces[i - 1].Direct;
            }
        }

        

    }
}
