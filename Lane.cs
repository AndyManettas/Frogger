using System;
using SplashKitSDK;

namespace splashkit
{
    public class Lane : Row
    {
        public Lane(Vehicle[] vehicle) : base(vehicle) { }

        public override void CollisionCheck(Frog frog)
        {
            foreach (MovingObject movingObj in GetList)
            {
                if (SplashKit.BitmapCollision(movingObj.Bitmap, movingObj.Position, SplashKit.BitmapNamed("frog"), frog.Position))
                {
                    SplashKit.SoundEffectNamed("splat").Play();
                    frog.Respawn();
                }
            }
        }
    }
}
