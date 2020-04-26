using System.Drawing;

namespace Geologist.Objects
{
    /// <summary>
    /// Базовый класс объектов
    /// </summary>
    abstract class BaseObject : ICollision
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
        protected BaseObject()
        {
            Pos = new Point(0, 0);
            Dir = new Point(0, 0);
            Size = new Size(0, 0);
        }
        protected BaseObject(Point pos, Point dir, Size size)
        {
            this.Pos = pos;
            this.Dir = dir;
            this.Size = size;
        }
        #endregion


        #region Methods
        public abstract void Draw();

        public abstract void Update();

        //public Rectangle Rect => new Rectangle(Pos, Size);
        public Rectangle Rect
        {
            get
            {
                return new Rectangle(Pos, Size);
            }
        }

        public bool Collision(ICollision other)
        {
            //если объект имеет пересечение с текущим объектом то true
            if (other.Rect.IntersectsWith(this.Rect)) return true; else return false;
        }

        #endregion
    }
}

