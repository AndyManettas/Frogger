using System;
using SplashKitSDK;

namespace splashkit
{
    public class Frog
    {
        protected int _lives;
        private Point2D _position;
        protected Row _row;

        public Frog()
        {
            _lives = 3;
            _row = null;
            _position.X = 325;
            _position.Y = 700;
        }

        public void Draw()
        {
            SplashKit.DrawBitmap(SplashKit.BitmapNamed("frog"), _position.X, _position.Y);
        }

        // frog hops according to key pressed (logic in the main)
        public void Hop (char direction)
        {
            SplashKit.SoundEffectNamed("hop").Play();

            switch (direction)
            {
                case 'u': _position.Y -= 50;
                break;
                case 'd': _position.Y += 50;
                break;
                case 'l': _position.X -= 50;
                break;
                case 'r': _position.X += 50;
                break;
            }
        }

        // frog dies and respawns
        public void Respawn ()
        {
            _position.X = 325;
            _position.Y = 700;
            _lives -= 1;
        }

        // frog sticks to the platforms
        public void Stick(MovingObject movingObj)
        {
           _position.X += movingObj.Polarity;
        }

        public int Lives
        {
            get
            {
                return _lives;
            }
            set
            {
                _lives = value;
            }
        }

        public Point2D Position
        {
            get
            {
                return _position;
            }
        }

        public double Y
        {
            get
            {
                return _position.Y;
            }
            set
            {
                _position.Y = value;
            }
        }

        public double X
        {
            get
            {
                return _position.X;
            }
            set
            {
                _position.X = value;
            }
        }

        public Row Row
        {
            get
            {
                return _row;
            }
            set
            {
                _row = value;
            }
        }
    }
}
