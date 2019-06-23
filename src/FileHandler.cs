using System;
using SplashKitSDK;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace frogger
{
    public class FileHandler
    {
        private static readonly Lazy<FileHandler> _instance = new Lazy<FileHandler>(() => new FileHandler());

        private FileHandler() { }

        public static FileHandler Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        public void Menu()
        {
            string filePath = @"Resources/txtfiles/menu.txt";
            List<string> menu = File.ReadAllLines(filePath).ToList();

            foreach (string line in menu)
            {
                string[] entries = line.Split(',');
                string name = entries[0];
                int x = int.Parse(entries[1]);
                int y = int.Parse(entries[2]);
                SplashKit.DrawBitmap(SplashKit.BitmapNamed(name), x, y);
            }
        }

        public Dictionary<double, MovingObject[]> MovingObjectArrays()
        {
            Dictionary<double, MovingObject[]> movingObjArrayDict = new Dictionary<double, MovingObject[]>();

            string filePath = @"Resources/txtfiles/movingObjects.txt";
            List<string> fileLines = File.ReadAllLines(filePath).ToList();

            foreach (string line in fileLines)
            {
                string[] entries = line.Split(',');
                int arrayLength = int.Parse(entries[0]);
                string name = entries[1];
                int velocity = int.Parse(entries[2]);

                int i, k;

                MovingObject[] movingObjArray = new MovingObject[arrayLength];

                for (i = 0, k = 3; i < arrayLength; i++, k++)
                {
                    movingObjArray[i] = new MovingObject(name, int.Parse(entries[k]), velocity);
                }

                double yCoord = int.Parse(entries[k]);

                movingObjArrayDict.Add(yCoord, movingObjArray);
            }

            return movingObjArrayDict;
        }

        public void Environment()
        {
            SplashKit.FillRectangle(Color.Black, 25, 750, 650, 50);
            SplashKit.FillRectangle(Color.Black, 25, 450, 650, 250);
            SplashKit.FillRectangle(SplashKit.RGBColor(4, 0, 66), 25, 0, 650, 400);

            string filePath = @"Resources/txtfiles/environment.txt";
            List<string> environment = File.ReadAllLines(filePath).ToList();

            for (int i = 25; i < 675; i += 50)
            {
                foreach (string line in environment)
                {
                    string[] entries = line.Split(',');
                    string name = entries[0];
                    int x = int.Parse(entries[1]);
                    SplashKit.DrawBitmap(SplashKit.BitmapNamed(name), i, x);
                }
            }
        }

        public void LoadBitmaps()
        {
            string filePath = @"Resources/txtfiles/bitmaps.txt";

            List<string> bitmaps = File.ReadAllLines(filePath).ToList();

            foreach (string line in bitmaps)
            {
                string[] entries = line.Split(',');
                string name = entries[0];
                string filename = entries[1];
                SplashKit.LoadBitmap(name, filename);
            }
        }

        public void LoadSoundEffects()
        {
            string filePath = @"Resources/txtfiles/soundeffects.txt";

            List<string> soundEffects = File.ReadAllLines(filePath).ToList();

            foreach (string line in soundEffects)
            {
                string[] entries = line.Split(',');
                string name = entries[0];
                string filename = entries[1];
                SplashKit.LoadSoundEffect(name, filename);
            }
        }
    }
}