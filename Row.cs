using System;
using SplashKitSDK;
using System.Collections.Generic;

namespace splashkit
{
    public abstract class Row
    {
        private List<MovingObject> _movingObjects = new List<MovingObject>();

        public Row(MovingObject[] objects)
        {
            foreach (MovingObject obj in objects)
            {
                _movingObjects.Add(obj);
            }
        }

        public void RunObjects()
        {
            foreach (MovingObject movingObj in _movingObjects)
            {
                movingObj.Run();
            }
        }

        public abstract void CollisionCheck(Frog frog);

        public List<MovingObject> GetList
        {
            get
            {
                return _movingObjects;
            }
        }
    }
}
