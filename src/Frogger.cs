using SplashKitSDK;
using System;
using System.Collections.Generic;

namespace frogger
{
    public class Frogger
    {
        private static Lazy<Frogger> _instance = new Lazy<Frogger>(() => new Frogger());
        protected Frog _frog = new Frog();
        private readonly List<Row> _rows = new List<Row>();

        private Frogger()
        {
            LoadResources();
            ReadMovingObjects();
        }

        public static Frogger Instance
        {
            get { return _instance.Value; }
        }

        // load resources into the game
        private void LoadResources()
        {
            FileHandler fileHandler = FileHandler.Instance;
            fileHandler.LoadSoundEffects();
            SplashKit.LoadMusic("traffic", "traffic.mp3");
            SplashKit.MusicNamed("traffic").Play();
        }

        // runs resources
        public void RunGame()
        {
            FileHandler fileHandler = FileHandler.Instance;
            fileHandler.Environment();
            RunObjectsInRow();
            CollisionChecking();
            FrogController();
            OffScreen();
            FrogState();
            foreach (Row row in _rows)
            {
                if (row.Y.Equals(_frog.Y))
                {
                    _frog.Row = row;
                }
            }
        }

        // Frog Controls
        public void FrogController()
        {
            if (!_frog.Y.Equals(100))
            {
                if (SplashKit.KeyTyped(KeyCode.UpKey))
                {
                    _frog.Hop('u');
                }
                if (SplashKit.KeyTyped(KeyCode.DownKey))
                {
                    _frog.Hop('d');
                }
                if (SplashKit.KeyTyped(KeyCode.LeftKey))
                {
                    _frog.Hop('l');
                }
                if (SplashKit.KeyTyped(KeyCode.RightKey))
                {
                    _frog.Hop('r');
                }
            }
            else
            {
                Wins();
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
                Loses();
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

        public void OffScreen()
        {
            if (_frog.Position.Y > 700)
            {
                _frog.Y = 700;
            }
            if (_frog.Position.X >= 675 || _frog.Position.X + 50 <= 25)
            {
                _frog.Splat();
            }
        }

        public void Wins()
        {
            SplashKit.DrawBitmap(SplashKit.BitmapNamed("winner"), 45, 165);
            PlayAgain();
        }

        public void Loses()
        {
            SplashKit.DrawBitmap(SplashKit.BitmapNamed("gameover"), 50, 75);
            PlayAgain();
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

        // factory assembles dictionary into river or road
        public void ReadMovingObjects()
        {
            FileHandler fileHandler = FileHandler.Instance;
            RowFactory rowFactory = RowFactory.Instance;

            foreach (KeyValuePair<double, MovingObject[]> movingObjArray in fileHandler.MovingObjectArrays())
            {
                Row row = rowFactory.GetRow(movingObjArray.Value, movingObjArray.Key);
                _rows.Add(row);
            }
        }

        public Frog Frog
        {
            get { return _frog; }
            set { _frog = value; }
        }
    }
}
