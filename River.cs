using System;
using SplashKitSDK;

namespace splashkit
{
    public class River : Row
    {
        public River(Platform[] platform) : base(platform) { }

        public override void CollisionCheck(Frog frog)
        {
            foreach (MovingObject movingObj in GetList)
            {
                if (SplashKit.BitmapCollision(movingObj.Bitmap, movingObj.Position, SplashKit.BitmapNamed("frog"), frog.Position))
                {
                    frog.Stick(movingObj);
                }
            }
        }
    }
}
