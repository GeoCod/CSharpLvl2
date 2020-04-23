using System;
using System.Drawing;

namespace Geologist.Objects
{

    class Crystal : BaseObject
    {
        static Image Image { get; } = Image.FromFile("Images\\crystal.png");

        public Crystal(Point pos, Point dir, Size size) : base(pos, dir, size)
        {

        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(Image, Pos.X, Pos.Y, 80, 80);
        }

        public override void Update()
        {
            Pos.X -= Dir.X;
            if (Pos.X < 0) Pos.X = Game.Width + 50;
        }
    }
}
