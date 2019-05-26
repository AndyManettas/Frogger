using System;
using SplashKitSDK;
using System.Collections.Generic;

namespace splashkit
{
    public abstract class Row
    {
        protected List<MovingObject> _movingObjects = new List<MovingObject>();
        protected double _y;

        // moving objects get added to the rows list attribute
        protected Row(MovingObject[] objects, double y)
        {
            _y = y;
            foreach (MovingObject obj in objects)
            {
                obj.Y = y;
                _movingObjects.Add(obj);
            }
        }

        // draws and moves each object in the rows list attribute
        public void RunObjects()
        {
            foreach (MovingObject movingObj in _movingObjects)
            {
                movingObj.Draw();
                movingObj.Move();
            }
        }

        // abstract method checks for frog collision with row objects
        public abstract void CollisionCheck(Frog frog);


        public List<MovingObject> GetList
        {
            get
            {
                return _movingObjects;
            }
        }

        public double Y
        {
            get
            {
                return _y;
            }
        }
    }
}
