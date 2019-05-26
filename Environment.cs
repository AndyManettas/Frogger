using System;
using SplashKitSDK;

namespace splashkit
{
    public class Environment
    {
        public void Draw()
        {
            for(int i = 25; i < 675; i += 50)
            {
                SplashKit.DrawBitmapOnWindow(SplashKit.CurrentWindow(), SplashKit.BitmapNamed("pgrass"), i, 700);
            }

            SplashKit.FillRectangle(Color.Black, 25, 750, 650, 50);
            SplashKit.FillRectangle(Color.Black, 25, 450, 650, 250);

            for (int i=25; i < 675; i += 50)
            {
                SplashKit.DrawBitmapOnWindow(SplashKit.CurrentWindow(), SplashKit.BitmapNamed("pgrass"), i, 400);
            }

            SplashKit.FillRectangle(SplashKit.RGBColor(4, 0, 66), 25, 0, 650, 400);

            for (int i = 25; i < 675; i += 50)
            {
                SplashKit.DrawBitmapOnWindow(SplashKit.CurrentWindow(), SplashKit.BitmapNamed("grass"), i, 100);
            }

            for (int i = 25; i < 675; i += 50)
            {
                SplashKit.DrawBitmapOnWindow(SplashKit.CurrentWindow(), SplashKit.BitmapNamed("grassedge"), i, 75);
            }
        }
    }
}
