using System;
using System.Drawing;

namespace Geologist.Objects
{
    /// <summary>
    /// Объект горные породы
    /// </summary>
    class Rock : BaseObject
    {
        //Па задумке от горных пород надо будет уворачиваться или сбивать их молотком
        #region Fields
        /// <summary>
        /// высота картинки
        /// </summary>
        static int _height = 50;
        /// <summary>
        /// ширина картинки
        /// </summary>
        static int _width = (int)(_height * 1.4);
        //public int Height { get; private set; } = 50;
        //public int Width { get; private set; } = 70;

        static Image Image { get; } = Image.FromFile("Images\\rock.png");
        #endregion


        #region ClassLifeCycles
        public Rock(Point pos, Point dir, Size size) : base(pos, dir, size)
        {

        }

        public Rock()
        {
            Pos = new Point(Game.Random.Next(Game.Width, Game.Width * 2), Game.Random.Next(0, Game.Height - _height));
            Dir = new Point(Game.Random.Next(1, 10), Game.Random.Next(-10, 10));
            Size = new Size(_width, _height);
        }
        #endregion


        #region Methods
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(Image, Pos.X, Pos.Y, _width, _height);
        }

        public override void Update()
        {
            Pos.X -= Dir.X;
            if (Pos.X < -_width)
            {
                Pos.X = Game.Random.Next(Game.Width, Game.Width + Game.Width);
                Pos.Y = Game.Random.Next(Game.Height - _height);
            }
            Pos.Y -= Dir.Y;
            if (Pos.Y < 0 || Pos.Y > Game.Height - _height)
                Dir.Y = -Dir.Y;
        }
        #endregion
    }
}