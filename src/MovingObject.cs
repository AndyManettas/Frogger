using System;
using SplashKitSDK;

namespace frogger
{
    public class MovingObject
    {
        private Point2D _position;
        protected Bitmap _bitmap;
        protected int _velocity;
        protected int _width;
        protected IFloatingState _floatingState;

        public MovingObject(string bitmap, double x, int velocity)
        {
            _bitmap = SplashKit.BitmapNamed(bitmap);
            _position.X = x;
            _position.Y = 0;
            _velocity = velocity;
            _width = SplashKit.BitmapWidth(_bitmap);
            _floatingState = new AboveWaterState();
        }

        public void Draw()
        {
            SplashKit.DrawBitmap(_bitmap, X, Y);
        }

        // velocity determining objects' speed and direction
        // (left if negative velocity and right if positive velocity)
        public void Move()
        {
            _position.X += _velocity;

            if (_velocity < 0)
            {
                if (_position.X + _width <= 0)
                {
                    _position.X = 700;
                }
            }
            if (_velocity > 0)
            {
                if (_position.X >= 700)
                {
                    _position.X  = 0 - _width;
                }
            }
        }

        public void SetState(IFloatingState newState)
        {
            _floatingState = newState;
        }

        public void Surface()
        {
            string bitmapName = SplashKit.BitmapName(_bitmap);
            string last = bitmapName.Substring(bitmapName.Length - 1, 1);
            _floatingState.Surface(this, last);
        }

        public IFloatingState State
        {
            get { return _floatingState;  }
        }

        public double X
        {
            get { return _position.X; }
            set { _position.X = value; }
        }

        public double Y
        {
            get { return _position.Y; }
            set { _position.Y = value; }
        }

        public Bitmap Bitmap
        {
            get { return _bitmap; }
            set { _bitmap = value; }
        }

        public Point2D Position
        {
            get { return _position; }
        }

        public int Velocity
        {
            get { return _velocity; }
        }

        public int Width
        {
            get { return _width; }
        }
    }
}
