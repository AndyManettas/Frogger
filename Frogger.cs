using System;
using SplashKitSDK;
using System.Collections.Generic;

namespace splashkit
{
    public class Frogger
    {
        protected readonly Frog _frog = new Frog();
        protected readonly Environment _environment = new Environment();
        private List<Row> _rows = new List<Row>();

        private void LoadResources()
        {
            SplashKit.LoadBitmap("frog", "frog.png");
            SplashKit.LoadBitmap("frogicon", "frog-icon.png");
            SplashKit.LoadBitmap("pgrass", "purplegrass.png");
            SplashKit.LoadBitmap("riverbank", "riverbank.png");
            SplashKit.LoadBitmap("grass", "grasss.png");
            SplashKit.LoadBitmap("grassedge", "grassedge.png");
            SplashKit.LoadBitmap("truck", "truck.png");
            SplashKit.LoadBitmap("racecarR", "racecarright.png");
            SplashKit.LoadBitmap("car", "car.png");
            SplashKit.LoadBitmap("tractor", "tractor.png");
            SplashKit.LoadBitmap("racecarL", "racecarleft.png");
            SplashKit.LoadBitmap("gameover", "Gameover.png");
            SplashKit.LoadBitmap("turtle2", "turtle2.png");
            SplashKit.LoadBitmap("turtle3", "turtle3.png");
            SplashKit.LoadBitmap("turtleUW", "turtleunderwater.png");
            SplashKit.LoadBitmap("logM", "logmed.png");
            SplashKit.LoadBitmap("logL", "loglong.png");
            SplashKit.LoadBitmap("logS", "logsmall.png");
        }

        public Frogger()
        {
            LoadResources();
            AddRows();
        }

        public void RunGame()
        {
            _environment.Draw();
            RunObjectsInRow();

            int x = 30;
            int i = 0;

            while (i < _frog.Lives)
            {
                SplashKit.DrawBitmap(SplashKit.BitmapNamed("frogicon"), x, 755);

                x += 60;
                i++;
            }

            if (_frog.Lives > 0)
            {
                _frog.Draw();
            }
            else
            {
                SplashKit.DrawBitmap(SplashKit.BitmapNamed("gameover"), 50, 75);
            }
        }

        public void RunObjectsInRow()
        {
            foreach (Row row in _rows)
            {
                row.RunObjects();
                row.CollisionCheck(_frog);
            }
        }

        public Frog Frog
        {
            get
            {
                return _frog;
            }
        }

        // Read 2 lines into Factory constructor passing in two strings as parameters
        public void AddRows()
        {
            // Lane Moving Objects
            Vehicle[] truck = new Vehicle[3];
            truck[0] = new Vehicle("truck", 0, 450, -2);
            truck[1] = new Vehicle("truck", 175, 450, -2);
            truck[2] = new Vehicle("truck", 500, 450, -2);
            Lane truckLane = new Lane(truck);
            _rows.Add(truckLane);

            Vehicle[] racecarR = new Vehicle[2];
            racecarR[0] = new Vehicle("racecarR", 0, 500, 5);
            racecarR[1] = new Vehicle("racecarR", 375, 500, 5);
            Lane racecarRLane = new Lane(racecarR);
            _rows.Add(racecarRLane);

            Vehicle[] car = new Vehicle[3];
            car[0] = new Vehicle("car", 650, 550, -2);
            car[1] = new Vehicle("car", 450, 550, -2);
            car[2] = new Vehicle("car", 250, 550, -2);
            Lane carLane = new Lane(car);
            _rows.Add(carLane);

            Vehicle[] tractor = new Vehicle[3];
            tractor[0] = new Vehicle("tractor", 650, 600, 2);
            tractor[1] = new Vehicle("tractor", 400, 600, 2);
            tractor[2] = new Vehicle("tractor", 200, 600, 2);
            Lane tractorLane = new Lane(tractor);
            _rows.Add(tractorLane);

            Vehicle[] racecarL = new Vehicle[4];
            racecarL[0] = new Vehicle("racecarL", 700, 650, -3);
            racecarL[1] = new Vehicle("racecarL", 525, 650, -3);
            racecarL[2] = new Vehicle("racecarL", 350, 650, -3);
            racecarL[3] = new Vehicle("racecarL", 175, 650, -3);
            Lane racecarLLane = new Lane(racecarL);
            _rows.Add(racecarLLane);


            // River Moving Objects
            Platform[] logM = new Platform[3];
            logM[0] = new Platform("logM", 0, 150, 3);
            logM[1] = new Platform("logM", 275, 150, 3);
            logM[2] = new Platform("logM", 600, 150, 3);
            River logMLane = new River(logM);
            _rows.Add(logMLane);

            Platform[] turtle2 = new Platform[4];
            turtle2[0] = new Platform("turtle2", 700, 200, -2);
            turtle2[1] = new Platform("turtle2", 550, 200, -2);
            turtle2[2] = new Platform("turtle2", 400, 200, -2);
            turtle2[3] = new Platform("turtle2", 250, 200, -2);
            River turtle2Lane = new River(turtle2);
            _rows.Add(turtle2Lane);

            Platform[] logL = new Platform[2];
            logL[0] = new Platform("logL", 0, 250, 4);
            logL[1] = new Platform("logL", 380, 250, 4);
            River logLLane = new River(logL);
            _rows.Add(logLLane);

            Platform[] logS = new Platform[3];
            logS[0] = new Platform("logS", 0, 300, 2);
            logS[1] = new Platform("logS", 330, 300, 2);
            logS[2] = new Platform("logS", 560, 300, 2);
            River logSLane = new River(logS);
            _rows.Add(logSLane);

            Platform[] turtle3 = new Platform[3];
            turtle3[0] = new Platform("turtle3", 700, 350, -2);
            turtle3[1] = new Platform("turtle3", 500, 350, -2);
            turtle3[2] = new Platform("turtle3", 300, 350, -2);
            River turtle3Lane = new River(turtle3);
            _rows.Add(turtle3Lane);
        }
    }
}
