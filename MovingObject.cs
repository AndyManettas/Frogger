using System;
using SplashKitSDK;

namespace splashkit
{
    public abstract class MovingObject
    {
        private Point2D _position;
        protected Bitmap _bitmap;
        protected int _polarity;
        protected int _width;

        protected MovingObject(string bitmap, double x, int polarity)
        {
            _bitmap = SplashKit.BitmapNamed(bitmap);
            _position.X = x;
            _position.Y = 0;
            _polarity = polarity;
            _width = SplashKit.BitmapWidth(_bitmap);
        }

        public void Draw()
        {
            SplashKit.DrawBitmap(_bitmap, X, Y);
        }

        // polarity determining objects' speed and direction
        // (left if negative polarity and right if positive polarity)
        public void Move()
        {
            _position.X += _polarity;

            if (_polarity < 0)
            {
                if (_position.X + _width <= 0)
                {
                    _position.X = 700;
                }
            }
            if (_polarity > 0)
            {
                if (_position.X >= 700)
                {
                    _position.X  = 0 - _width;
                }
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

        public Bitmap Bitmap
        {
            get
            {
                return _bitmap;
            }
            set
            {
                _bitmap = value;
            }
        }

        public Point2D Position
        {
            get
            {
                return _position;
            }
        }

        public int Polarity
        {
            get
            {
                return _polarity;
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
