using System;
using System.Drawing;

namespace Geologist.Objects
{
    /// <summary>
    /// Объект героя
    /// </summary>
    class Hero : BaseObject
    {
        #region Fields
        static Image Image { get; } = Image.FromFile("Images\\geologist.png");
        #endregion


        #region ClassLifeCycles
        public Hero(Point pos, Point dir, Size size) : base(pos, dir, size)
        {

        }
        #endregion


        #region Methods
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(Image, Pos.X, Pos.Y, 80, 90);
        }

        public override void Update()
        {
            //Pos.X -= Dir.X;
            //if (Pos.X < 0) Pos.X = Game.Width + 50;
            
            Pos.Y += Dir.Y;
            if (Pos.Y < 0) Pos.Y = Game.Height;
        }

        // Сделать обработку нажатий клавиш
        private static void KeyDown(string LastKey)
        {
            if (LastKey == "Up")
            {
                //hero.Move вверх;
            }
            else if (LastKey == "Down")
            {
                //hero.Move вниз;
            }
            else if (LastKey == "LeftCtrl")
            {
                //hero кидает молоток;
            }
            else if (LastKey == "Space")
            {
                //игра ставится на паузу. Может быть этот обработчик сделать в Programm?
            }
        }
        #endregion
    }
}
