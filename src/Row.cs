using System;
using SplashKitSDK;
using System.Collections.Generic;

namespace frogger
{
    public abstract class Row
    {
        protected List<MovingObject> _movingObjects = new List<MovingObject>();
        protected double _y;

        // moving objects get added to the rows list attribute
        protected Row(MovingObject[] objectArray, double y)
        {
            _y = y;
            foreach (MovingObject obj in objectArray)
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
                movingObj.Surface();
                movingObj.Draw();
                movingObj.Move();
            }
        }

        // abstract method checks for frog collision with objects in row
        public abstract void CollisionCheck(Frog frog);


        public List<MovingObject> GetList
        {
            get { return _movingObjects; }
        }

        public double Y
        {
            get { return _y; }
        }
    }
}
