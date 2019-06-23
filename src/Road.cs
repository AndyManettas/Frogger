using System;
using SplashKitSDK;

namespace frogger
{
    public class Road : Row
    {
        public Road(MovingObject[] movingObjArray, double y) : base(movingObjArray, y) { }

        public override void CollisionCheck(Frog frog)
        {
            foreach (MovingObject movingObj in GetList)
            {
                // kills frog if hit by a vehicle
                if (SplashKit.BitmapCollision(movingObj.Bitmap, movingObj.Position, SplashKit.BitmapNamed("frog"), frog.Position))
                {
                    frog.Splat();
                }
            }
        }
    }
}
