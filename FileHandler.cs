using System;
using SplashKitSDK;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace splashkit
{
    public class FileHandler
    {

        public List<Lane> Vehicles()
        {
            List<Lane> lanes = new List<Lane>();

            string filePath = @"vehicles.txt";
            List<string> vehicleLines = File.ReadAllLines(filePath).ToList();

            foreach (string line in vehicleLines)
            {
                string[] entries = line.Split(',');
                int arrayLength = int.Parse(entries[0]);
                string name = entries[1];
                int polarity = int.Parse(entries[2]);

                int i, k;

                Vehicle[] vehicle = new Vehicle[arrayLength];

                for (i = 0, k = 3; i < arrayLength; i++, k++)
                {
                    vehicle[i] = new Vehicle(name, int.Parse(entries[k]), polarity);
                }

                double yCoord = int.Parse(entries[k]);

                Lane lane = new Lane(vehicle, yCoord);

                lanes.Add(lane);
            }

            return lanes;
        }

        public List<River> Platforms()
        {
            List<River> rivers = new List<River>();

            string filePath = @"platforms.txt";
            List<string> platformLines = File.ReadAllLines(filePath).ToList();

            foreach (string line in platformLines)
            {
                string[] entries = line.Split(',');
                int arrayLength = int.Parse(entries[0]);
                string name = entries[1];
                int polarity = int.Parse(entries[2]);

                int i, k;

                Platform[] platform = new Platform[arrayLength];

                for (i = 0, k = 3; i < arrayLength; i++, k++)
                {
                    platform[i] = new Platform(name, int.Parse(entries[k]), polarity);
                }

                double yCoord = int.Parse(entries[k]);

                River river = new River(platform, yCoord);

                rivers.Add(river);
            }

            return rivers;
        }

        public void Environment()
        {
            SplashKit.FillRectangle(Color.Black, 25, 750, 650, 50);
            SplashKit.FillRectangle(Color.Black, 25, 450, 650, 250);
            SplashKit.FillRectangle(SplashKit.RGBColor(4, 0, 66), 25, 0, 650, 400);

            string filePath = @"environment.txt";
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
            string filePath = @"bitmaps.txt";

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
            string filePath = @"soundeffects.txt";

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