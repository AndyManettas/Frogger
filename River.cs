using System;
using SplashKitSDK;

namespace splashkit
{
    public class River : Row
    {
        public River(Platform[] platform) : base(platform) { }

        public override void CollisionCheck(Frog frog)
        {
            bool collided = false;
            foreach (MovingObject movingObj in GetList)
            {
                if (SplashKit.BitmapCollision(movingObj.Bitmap, movingObj.Position, SplashKit.BitmapNamed("frog"), frog.Position))
                {
                    Console.WriteLine("collided");
                    collided = true;
                    frog.Stick(movingObj);
                    if ((!collided) && frog.Position.Y <= 350 && frog.Position.Y >= 150)
                    {
                        Console.WriteLine("not collided");
                        if (frog.Position.X + 25 < movingObj.X || frog.Position.X + 25 > movingObj.X + movingObj.Width)
                        {
                            SplashKit.SoundEffectNamed("splash").Play();
                            frog.Respawn();
                        }
                    }
                }
            }
        }
    }
}
