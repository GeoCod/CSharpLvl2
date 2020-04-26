using System.Drawing;

namespace Geologist.Objects
{
    interface ICollision
    {
        bool Collision(ICollision obj);
        Rectangle Rect { get; }
    }
}
