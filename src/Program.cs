using frogger;
using SplashKitSDK;
using System;
using System.Linq;

public static class Program
{
    public static void Main()
    {
        GameFacade facade = GameFacade.Instance;

        Window froggerWin = new Window("Frogger", 700, 800);

        while (!froggerWin.CloseRequested)
        {
            froggerWin.Clear(Color.White);

            facade.Display();

            froggerWin.Refresh(60);
            SplashKit.ProcessEvents();
        }
    }
}
