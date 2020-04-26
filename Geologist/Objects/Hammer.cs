using System;
using System.Drawing;

namespace Geologist.Objects
{
    /// <summary>
    /// Класс объекта геологического молотка
    /// </summary>
    class Hammer : BaseObject
    {
        #region Filds
        int _height = 30;
        int _width = 30;
        int _speed = 1;
        static Image Image { get; } = Image.FromFile("Images\\hammer.png");
        #endregion


        #region Properties


        #endregion


        #region ClassLifeCycles
        public Hammer(Point point)
        {
            Pos = new Point(point.X, point.Y);
            Dir = new Point(_speed, 0);
            Size = new Size(_width, _height);
        }

        public Hammer(Point pos, Point dir, Size size) : base(pos, dir, size)
        {

        }


        #endregion


        #region Methods
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(Image, Pos.X, Pos.Y, _width, _height);
        }

        public override void Update()
        {
            Pos.X += _speed;
            if (Pos.X > Game.Width)
            {
                //удалить объект
            }

        }
        #endregion
    }
}
