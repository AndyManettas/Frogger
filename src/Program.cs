using frogger;
using SplashKitSDK;

public class Program
{
    public static void Main()
    {
        Frogger _game = new Frogger();
        Window froggerWin = new Window("Frogger", 700, 800);
        int i = 1;

        while (!froggerWin.CloseRequested)
        {
            froggerWin.Clear(Color.White);

            _game.RunGame();

            if (!_game.Frog.Position.Y.Equals(100))
            {
                if (SplashKit.KeyTyped(KeyCode.UpKey))
                {
                    _game.Frog.Hop('u');
                }
                if (SplashKit.KeyTyped(KeyCode.DownKey))
                {
                    _game.Frog.Hop('d');
                }
                if (SplashKit.KeyTyped(KeyCode.LeftKey))
                {
                    _game.Frog.Hop('l');
                }
                if (SplashKit.KeyTyped(KeyCode.RightKey))
                {
                    _game.Frog.Hop('r');
                }
            } 
            else
            {
                while (i == 1)
                {
                    SplashKit.SoundEffectNamed("win").Play();
                    i = 2;
                }
                SplashKit.DrawBitmap(SplashKit.BitmapNamed("winner"), 45, 165);
                _game.PlayAgain();
            }

            // sidebars
            SplashKit.FillRectangle(Color.Black, 0, 0, 25, 800);
            SplashKit.FillRectangle(Color.Black, 675, 0, 25, 800);

            froggerWin.Refresh(60);
            SplashKit.ProcessEvents();
        }
    }
}
