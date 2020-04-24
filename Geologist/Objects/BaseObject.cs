using System;
using System.Drawing;

namespace Geologist.Objects
{
    /// <summary>
    /// Базовый класс объектов
    /// </summary>
    class BaseObject
    {
        #region Fields
        /// <summary>
        /// Позиция
        /// </summary>
        protected Point Pos;//{ get; set; }
        /// <summary>
        /// Напарвление
        /// </summary>
        protected Point Dir;//{ get; set; }
        /// <summary>
        /// Размер
        /// </summary>
        protected Size Size;//{ get; set; }
        #endregion


        #region ClassLifeCycles
        public BaseObject()
        {
            Pos = new Point(0, 0);
            Dir = new Point(0, 0);
            Size = new Size(0, 0);
        }
        public BaseObject(Point pos, Point dir, Size size)
        {
            this.Pos = pos;
            this.Dir = dir;
            this.Size = size;
        }
        #endregion


        #region Methods
        public virtual void Draw()
        {
            Game.Buffer.Graphics.DrawEllipse(Pens.White, Pos.X, Pos.Y, Size.Width, Size.Height);
        }


        public virtual void Update()
        {
            Pos.X += Dir.X;
            Pos.Y = Pos.Y + Dir.Y;
            if (Pos.X < 0) Dir.X = -Dir.X;
            if (Pos.X > Game.Width) Dir.X = -Dir.X;
            if (Pos.Y < 0) Dir.Y = -Dir.Y;
            if (Pos.Y > Game.Height) Dir.Y = -Dir.Y;
        }
        #endregion
    }
}

