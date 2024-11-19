using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Authentication.ExtendedProtection.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab07_Snake
{
    public partial class FormGameSnake : Form
    {
        private Graphics graph;
        private Timer timer;
        private Random generator;

        private Size boardSize;
        private List<Point> snake;
        private Keys direction;
        private Point apple;

        public FormGameSnake()
        {
            InitializeComponent();
            generator = new Random();

            boardSize = new Size(41, 31);

            snake = new List<Point>();
            snake.Add(new Point(boardSize.Width / 2, boardSize.Height - 1));
            snake.Add(new Point(boardSize.Width / 2, boardSize.Height));
            snake.Add(new Point(boardSize.Width / 2, boardSize.Height + 1));
            snake.Add(new Point(boardSize.Width / 2, boardSize.Height + 2));
            snake.Add(new Point(boardSize.Width / 2, boardSize.Height + 3));
            direction = Keys.Up;

            genApple();

            PictureBoxGame_SizeChanged(null, null);

            timer = new Timer();
            timer.Interval = 100;//10 times/sec
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Point OldHead = snake.First();

            Point NewHead = Point.Empty;
            switch (direction)
            {
                case Keys.Up:
                    NewHead = new Point(OldHead.X, OldHead.Y - 1);
                    break;
                case Keys.Down:
                    NewHead = new Point(OldHead.X, OldHead.Y + 1);
                    break;
                case Keys.Left:
                    NewHead = new Point(OldHead.X - 1, OldHead.Y);
                    break;
                case Keys.Right:
                    NewHead = new Point(OldHead.X + 1, OldHead.Y);
                    break;
            }
            //game over - collision
            if (NewHead.X < 0 || NewHead.X >= boardSize.Width || //left and right border
                NewHead.Y < 0 || NewHead.Y >= boardSize.Height || //top and bottom border
                snake.Contains(NewHead) //collision with snake
               )
            {
                timer.Stop();
            }
            else
            {
                snake.Insert(0, NewHead);//add newHead
                //Points - value types
                if (NewHead == apple)
                {
                    genApple();
                }
                else
                {
                    snake.Remove(snake.Last());//remove oldTail
                }
                drawGame();
            }
        }

        private void genApple()
        {
            apple = new Point(generator.Next(boardSize.Width),
                              generator.Next(boardSize.Height));
        }

        private void drawGame()
        {
            SizeF fieldSize = new SizeF((float)pictureBoxGame.Width / boardSize.Width,
                                        (float)pictureBoxGame.Height / boardSize.Height);

            graph.Clear(Color.LightGreen);

            for (int x = 0; x < boardSize.Width; x++)
            {
                for (int y = 0; y < boardSize.Height; y++)
                {
                    graph.DrawRectangle(new Pen(Color.Green),
                                        x * fieldSize.Width,
                                        y * fieldSize.Height,
                                        fieldSize.Width,
                                        fieldSize.Height);
                }
            }

            foreach (Point p in snake)
            {
                graph.FillEllipse(new SolidBrush(Color.Brown),
                                  p.X * fieldSize.Width,
                                  p.Y * fieldSize.Height,
                                  fieldSize.Width,
                                  fieldSize.Height);
            }

            graph.FillEllipse(new SolidBrush(Color.Orange),
                              apple.X * fieldSize.Width,
                              apple.Y * fieldSize.Height,
                              fieldSize.Width,
                              fieldSize.Height);

            pictureBoxGame.Refresh();
        }

        private void PictureBoxGame_SizeChanged(object sender, EventArgs e)
        {
            pictureBoxGame.Image = new Bitmap(pictureBoxGame.Width,
                                              pictureBoxGame.Height);
            graph = Graphics.FromImage(pictureBoxGame.Image);

            drawGame();
        }

        private void FormGameSnake_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up ||
                e.KeyCode == Keys.Down ||
                e.KeyCode == Keys.Left ||
                e.KeyCode == Keys.Right)
            {
                direction = e.KeyCode;
            }
        }
    }
}
