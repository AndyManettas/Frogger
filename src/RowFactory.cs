using System;
using SplashKitSDK;
using System.Collections.Generic;

namespace frogger
{
    public class RowFactory
    {
        // Lazy<RowFactory> uses double-checked locking by default to store either the exception that was
        // thrown during construction, or the result of the function that was passed to Lazy<RowFactory>
        private static readonly Lazy<RowFactory> _instance = new Lazy<RowFactory>(() => new RowFactory());

        private RowFactory(){}

        public static RowFactory Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        public Row GetRow(MovingObject[] movingObjArray, double y)
        {
            if (y >= 450)
            {
                return new Road(movingObjArray, y);
            }
            if (y <= 350)
            {
                return new River(movingObjArray, y);
            }
            return null;
        }
    }
}
