using System;
using SplashKitSDK;

namespace splashkit
{
    public class Lane : Row
    {
        public Lane(Vehicle[] vehicle, double y) : base(vehicle, y) { }

        public override void CollisionCheck(Frog frog)
        {
            foreach (MovingObject movingObj in GetList)
            {
                // kills frog if hit by a vehicle
                if (SplashKit.BitmapCollision(movingObj.Bitmap, movingObj.Position, SplashKit.BitmapNamed("frog"), frog.Position))
                {
                    SplashKit.SoundEffectNamed("splat").Play();
                    frog.Respawn();
                }
            }
        }
    }
}
