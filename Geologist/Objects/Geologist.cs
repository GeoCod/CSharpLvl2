using System;
using System.Drawing;

namespace Geologist.Objects
{
    /// <summary>
    /// Объект героя
    /// </summary>
    class Geologist : BaseObject
    {
        #region Fields
        static Image Image { get; } = Image.FromFile("Images\\geologist.png");
        #endregion


        #region ClassLifeCycles
        public Geologist(Point pos, Point dir, Size size) : base(pos, dir, size)
        {

        }
        #endregion


        #region Methods
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(Image, new Rectangle(Pos.X, Pos.Y, 80, 90));
        }

        public override void Update()
        {
            Pos.X -= Dir.X;
            if (Pos.X < 0) Pos.X = Game.Width + 50;
        }
        #endregion
    }
}
