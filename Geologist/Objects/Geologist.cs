using System;
using System.Drawing;

namespace Geologist.Objects
{
    class Geologist : BaseObject
    {
        static Image Image { get; } = Image.FromFile("Images\\geologist.png");

        public Geologist(Point pos, Point dir, Size size) : base(pos, dir, size)
        {

        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(Image, new Rectangle(Pos.X, Pos.Y, 80, 90));
        }

        public override void Update()
        {
            Pos.X -= Dir.X;
            if (Pos.X < 0) Pos.X = Game.Width + 50;
        }
    }
}
