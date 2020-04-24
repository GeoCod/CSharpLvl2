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
        static Image Image { get; } = Image.FromFile("Images\\rock.png");
        #endregion


        #region ClassLifeCycles
        public Rock(Point pos, Point dir, Size size) : base(pos, dir, size)
        {

        }
        #endregion


        #region Methods
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(Image, Pos.X, Pos.Y, 80, 60);
        }

        public override void Update()
        {
            Pos.X -= Dir.X;
            if (Pos.X < 0)
            {
                Pos.X = Game.Random.Next(Game.Width + 20, Game.Width + Game.Width);
                Pos.Y = Game.Random.Next(Game.Height);
            }
        }
        #endregion
    }
}