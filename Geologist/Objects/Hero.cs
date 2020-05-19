using System;
using System.Drawing;
using System.Windows.Forms;

namespace Geologist.Objects
{
    /// <summary>
    /// Объект героя
    /// </summary>
    class Hero : BaseObject
    {
        #region Fields
        int _width = 100;
        int _height = 80;
        static Image Image { get; } = Image.FromFile("Images\\geologist.png");
        int _speed = 10;
        #endregion


        #region ClassLifeCycles
        public Hero(Point pos, Point dir, Size size) : base(pos, dir, size)
        {

        }

        public Hero()
        {
            Pos = new Point(5, Game.Height / 2);
            Dir = new Point(0 ,0);
            Size = new Size(_width, _height);
        }
        #endregion


        #region Methods
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(Image, Pos.X, Pos.Y, 80, 90);
        }

        public override void Update()
        {
            Pos.X += Dir.X;
            if (Pos.X <= 0)
            {
                Pos.X = 0;
                Dir.X = 0;
            }
            else if (Pos.X >= Game.Width - Size.Width)
            {
                Dir.X = 0;
            }

            Pos.Y += Dir.Y;
            if (Pos.Y <= 0)
            {
                Pos.Y = 0;
                Dir.Y = 0;
            }
            else if (Pos.Y >= Game.Height - Size.Height)
            {
                Dir.Y = 0;
            }
        }

        /// <summary>
        /// Изменение направления движения по нажатию клавиш
        /// </summary>
        /// <param name="e">Нажатие клавиш WASD, стрелки, Space</param>
        public void Move(KeyEventArgs e)
        {
            //Проверка нажаты ли клавиши
            bool up = e.KeyCode == Keys.W || e.KeyCode == Keys.Up;
            bool down = e.KeyCode == Keys.S || e.KeyCode == Keys.Down;
            bool right = e.KeyCode == Keys.D || e.KeyCode == Keys.Right;
            bool left = e.KeyCode == Keys.A || e.KeyCode == Keys.Left;

            //Как-то работает коряво
            if (up)
            {
                Dir.Y = -_speed;
                if (left) Dir.X = -_speed;
                else if (right) Dir.X = _speed;
                //else Dir.X = 0;
            }
            else if (down)
            {
                Dir.Y = _speed;
                if (left) Dir.X = -_speed;
                else if (right) Dir.X = _speed;
                //else Dir.X = 0;
            }
            else if (left)
            {
                Dir.X = -_speed;
                if (up) Dir.Y = -_speed;
                else if (down) Dir.Y = _speed;
                //else Dir.Y = 0;
            }
            else if (right)
            {
                Dir.X = _speed;
                if (up) Dir.Y = -_speed;
                else if (down) Dir.Y = _speed;
                //else Dir.Y = 0;
            }
            else
            {
                Dir.X = 0;
                Dir.Y = 0;
            }


            #region прочие попытки кправления героем
            //if (up) Dir.Y = -_speed;
            //if (down) Dir.Y = _speed;
            //if (left) Dir.X = -_speed;
            //if (right) Dir.X = _speed;




            //if (up & left)
            //{
            //    Dir.X = -_speed;
            //    Dir.Y = -_speed;
            //}
            //else if (up && right)
            //{
            //    Dir.X = _speed;
            //    Dir.Y = _speed;
            //}
            //else if (down && left)
            //{
            //    Dir.X = -_speed;
            //    Dir.Y = _speed;
            //}
            //else if (down && right)
            //{
            //    Dir.X = _speed;
            //    Dir.Y = _speed;
            //}
            //else if (left && !up && !down)
            //{
            //    Dir.X = -_speed;
            //    Dir.Y = 0;
            //}
            //else if (right && !up && !down)
            //{
            //    Dir.X = _speed;
            //    Dir.Y = 0;
            //}
            //else if (up && !left && !right)
            //{
            //    Dir.X = 0;
            //    Dir.Y = -_speed;
            //}
            //else if (down && !left && !right)
            //{
            //    Dir.X = 0;
            //    Dir.Y = _speed;
            //}
            //else
            //{
            //    Dir.X = 0;
            //    Dir.Y = 0;
            //}
            #endregion
        }

        internal void MoveStop()
        {
            Dir.X = 0;
            Dir.Y = 0;
        }
        #endregion
    }
}
