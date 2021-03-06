﻿using System;
using System.Drawing;

namespace Geologist.Objects
{
    /// <summary>
    /// Объект кристаллы
    /// </summary>
    class Crystal : BaseObject
    {
        #region Fields
        static Image Image { get; } = Image.FromFile("Images\\crystal.png");
        #endregion


        #region ClassLifeCycles
        public Crystal(Point pos, Point dir, Size size) : base(pos, dir, size)
        {

        }
        #endregion


        #region Methods
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(Image, Pos.X, Pos.Y, 80, 80);
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
