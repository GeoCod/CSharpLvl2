using System;
using System.Drawing;

namespace Geologist.Objects
{
    /// <summary>
    /// Объект кристаллы
    /// </summary>
    class Crystal : BaseObject
    {
        #region Fields
        int _height = 70, _width = 70;

        static Image Image { get; } = Image.FromFile("Images\\crystal.png");
        #endregion


        #region ClassLifeCycles
        public Crystal(Point pos, Point dir, Size size) : base(pos, dir, size)
        {

        }

        public Crystal()
        {
            Pos = new Point(Game.Random.Next(Game.Width, Game.Width * 2), Game.Random.Next(0, Game.Height - _height));
            Dir = new Point(Game.Random.Next(1, 10), Game.Random.Next(-10, 10));
            Size = new Size(_width, _height);
        }
        #endregion


        #region Methods
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(Image, Pos.X, Pos.Y, _height, _width);
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
