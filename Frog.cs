using System;
using SplashKitSDK;

namespace splashkit
{
    public class Frog
    {
        protected int _lives;
        protected bool _aliveState;
        private Point2D _position;
        private int _width;

        public Frog()
        {
            _lives = 3;
            _aliveState = true;
            _position.X = 325;
            _position.Y = 700;
            _width = 50;
        }

        public void Draw()
        {
            SplashKit.DrawBitmap(SplashKit.BitmapNamed("frog"), _position.X, _position.Y);
        }

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

        public void Respawn ()
        {
            _position.X = 325;
            _position.Y = 700;
            _lives -= 1;
        }

        public void Stick(MovingObject movingObj)
        {
           _position.X += movingObj.Polarity; // make moving object polarity apply to the frogs x coordinate;
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

        public bool AliveState
        {
            get
            {
                return _aliveState;
            }
            set
            {
                _aliveState = value;
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
            set
            {
                _position.Y = value;
            }
        }

        public double X
        {
            set
            {
                _position.X = value;
            }
        }

        public int Width
        {
            get
            {
                return _width;
            }
        }
    }
}
