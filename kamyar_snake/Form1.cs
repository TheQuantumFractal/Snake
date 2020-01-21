using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace kamyar_snake
{
    public partial class Form1 : Form
    {
        Random gen = new Random();
        Graphics gfx;
        Snake snake;
        Food food;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gfx = CreateGraphics();
            snake = new Snake(new Point(ClientSize.Width / 2, ClientSize.Height / 2), new Size(20, 20), Color.ForestGreen);
            food = new Food(ClientSize, gen);    
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            snake.Erase(gfx, BackColor);
            food.Draw(gfx, BackColor);
            //int x = 0, y = 0;
            //for (int i = 50; i < 600; i += 5)
            //{
            //   y = (int)(Math.Sqrt((double)(Math.Abs(Math.Pow(10, 2) - Math.Pow(i, 2)))));
            //   gfx.FillRectangle(Brushes.IndianRed, i, y, 5, 5);
            //}
            
            snake.Move(ClientSize);
            snake.ChangeDirection();
            //if intersect
            if (food.EllipseHit.IntersectsWith(new Rectangle(snake.pieces[0]._location, snake.pieces[0]._size)))
            {
                food.generate(ClientSize, gen);
                if (snake.pieces.Last()._direction == SnakePiece.Direction.Left)
                {
                    snake.pieces.Add(new SnakePiece(new Point(snake.pieces.Last()._location.X + 20, snake.pieces.Last()._location.Y), snake.pieces.Last()._size, snake.pieces.Last()._color, snake.pieces[snake.pieces.Count-1].Direct));
                }
                if (snake.pieces.Last()._direction == SnakePiece.Direction.Right)
                {
                    snake.pieces.Add(new SnakePiece(new Point(snake.pieces.Last()._location.X - 20, snake.pieces.Last()._location.Y), snake.pieces.Last()._size, snake.pieces.Last()._color, snake.pieces[snake.pieces.Count - 1].Direct));
                }
                if (snake.pieces.Last()._direction == SnakePiece.Direction.Up)
                {
                    snake.pieces.Add(new SnakePiece(new Point(snake.pieces.Last()._location.X, snake.pieces.Last()._location.Y + 20), snake.pieces.Last()._size, snake.pieces.Last()._color, snake.pieces[snake.pieces.Count - 1].Direct));
                }
                if (snake.pieces.Last()._direction == SnakePiece.Direction.Down)
                {
                    snake.pieces.Add(new SnakePiece(new Point(snake.pieces.Last()._location.X, snake.pieces.Last()._location.Y - 20), snake.pieces.Last()._size, snake.pieces.Last()._color, snake.pieces[snake.pieces.Count - 1].Direct));
                }
                //if (snake.pieces.Count >= 2)
                //{
                //    for (int i = snake.pieces.Count - 1; i > 1; i--)
                //    {
                //        snake.pieces[i]._direction = snake.pieces[i - 1]._direction;
                //    }
                //}
            }
            snake.Draw(gfx);
            food.Draw(gfx, Color.Black);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                snake.pieces[0].Direct = SnakePiece.Direction.Right;
            }
            if (e.KeyCode == Keys.Left)
            {
                snake.pieces[0].Direct = SnakePiece.Direction.Left;
            }
            if (e.KeyCode == Keys.Up)
            {
                snake.pieces[0].Direct = SnakePiece.Direction.Up;
            }
            if (e.KeyCode == Keys.Down)
            {
                snake.pieces[0].Direct = SnakePiece.Direction.Down;
            }
        }
       
    }
}
