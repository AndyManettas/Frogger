using SplashKitSDK;
using System;
using System.Collections.Generic;

namespace splashkit
{
    public class Frogger
    {
        protected Frog _frog = new Frog();
        private readonly List<Row> _rows = new List<Row>();

        public Frogger()
        {
            LoadResources();
            ReadMovingObjects();
        }

        // load resources into the game
        private void LoadResources()
        {
            FileHandler.LoadBitmaps();
            FileHandler.LoadSoundEffects();
            SplashKit.LoadMusic("traffic", "traffic.mp3");
            SplashKit.MusicNamed("traffic").Play();
        }

        // runs resources
        public void RunGame()
        {
            FileHandler.Environment();
            RunObjectsInRow();
            CollisionChecking();
            FrogState();
            foreach (Row row in _rows)
            {
                if (row.Y.Equals(_frog.Y))
                {
                    _frog.Row = row;
                }
            }
        }

        // tracks game according to frogs life state
        public void FrogState()
        {
            // frog icons representing lives in bottom left corner
            for (int i = 0, x = 30; i < _frog.Lives; i++, x += 60)
            {
                SplashKit.DrawBitmap(SplashKit.BitmapNamed("frogicon"), x, 755);
            }

            // frog will be drawn as long as it has lives otherwise game will be over
            if (_frog.Lives > 0)
            {
                _frog.Draw();
            }
            else
            {
                SplashKit.DrawBitmap(SplashKit.BitmapNamed("gameover"), 50, 75);
                PlayAgain();
            }
        }

        // moves objects in the row and continuously checks for collision
        public void RunObjectsInRow()
        {
            foreach (Row row in _rows)
            {
                row.RunObjects();
            }
        }

        public void CollisionChecking()
        {
            foreach (Row row in _rows)
            {
                row.CollisionCheck(_frog);
            }
        }

        // reset button giving player the option to play again with 3 lives
        public void PlayAgain()
        {
            Bitmap reset = SplashKit.BitmapNamed("reset");
            SplashKit.DrawBitmap(reset, 240, 650);

            if (SplashKit.MouseClicked(MouseButton.LeftButton))
            {
                if (SplashKit.MousePosition().X > 240 && SplashKit.MousePosition().X < 460)
                {
                    if (SplashKit.MousePosition().Y > 650 && SplashKit.MousePosition().Y < 750)
                    {
                        _frog = new Frog();
                    }
                }
            }
        }

        // factory assembles dictionary into river or lane
        public void ReadMovingObjects()
        {
            foreach (KeyValuePair<double, MovingObject[]> movingObjArray in FileHandler.MovingObjectArrays())
            {
                Row row = RowFactory.GetRow(movingObjArray.Value, movingObjArray.Key);
                _rows.Add(row);
            }
        }

        public Frog Frog
        {
            get
            {
                return _frog;
            }
            set
            {
                _frog = value;
            }
        }
    }
}
