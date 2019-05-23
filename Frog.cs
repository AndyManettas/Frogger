using System;
using SplashKitSDK;

namespace splashkit
{
    public class Frog
    {
        protected int _lives;
        protected bool _aliveState;
        private Point2D _position;
        private Row _row; // if frog is on river

        public Frog()
        {
            _lives = 3;
            _aliveState = true;
            _position.X = 325;
            _position.Y = 700;
        }

        public void Draw()
        {
            SplashKit.DrawBitmap(SplashKit.BitmapNamed("frog"), _position.X, _position.Y);
        }

        public void Hop (char direction)
        {
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

        public void Die ()
        {
            _position.X = 325;
            _position.Y = 700;
            _lives -= 1;
        }

        public void Stick(MovingObject movingObj)
        {
           _position.X += movingObj.Polarity; // make moving object polarity apply to the frogs x coordinate;
        }

        public void Drown()
        {

        }

        public int Lives
        {
            get
            {
                return _lives;
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
    }
}
