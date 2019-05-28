using System;
using SplashKitSDK;

namespace frogger
{
    public class River : Row
    {
        public River(MovingObject[] movingObjArray, double y) : base(movingObjArray, y) { }

        // checks collision with frog and sticks frog to platform if so
        public override void CollisionCheck(Frog frog)
        {
            bool collided = false;
            foreach (MovingObject movingObj in GetList)
            {
                if (SplashKit.BitmapCollision(movingObj.Bitmap, movingObj.Position, SplashKit.BitmapNamed("frog"), frog.Position))
                {
                    collided = true;
                    frog.Stick(movingObj);
                    // if frog has half his body over the platforms edge, collision is set to false
                    collided &= (frog.X + 25 >= movingObj.X && frog.X + 25 <= movingObj.X + movingObj.Width);
                }
            }
            // kills frog when frog is in the river and is not on a platform
            if (!collided && frog.Y.Equals(Y))
            {
                SplashKit.SoundEffectNamed("splash").Play();
                frog.Respawn();
            }
        }
    }
}
