using System;
using SplashKitSDK;

namespace splashkit
{
    public abstract class MovingObject
    {
        private Point2D _position;
        protected Bitmap _bitmap;
        private int _polarity;
        private int _width;

        protected MovingObject(string bitmap, double x, double y, int polarity)
        {
            _bitmap = SplashKit.BitmapNamed(bitmap);
            _position.X = x;
            _position.Y = y;
            _polarity = polarity;
            _width = SplashKit.BitmapWidth(_bitmap);
        }

        public void Run()
        {
            SplashKit.DrawBitmap(_bitmap, X, Y);

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
