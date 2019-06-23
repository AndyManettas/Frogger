using SplashKitSDK;
using System;
using System.Collections.Generic;

namespace frogger
{
    public class GameFacade
    {
        private static readonly Lazy<GameFacade> _instance = new Lazy<GameFacade>(() => new GameFacade());
        protected IGameState _gameState;

        private GameFacade()
        {
            _gameState = new GameMenuState();
            FileHandler fileHandler = FileHandler.Instance;
            fileHandler.LoadBitmaps();
        }

        public static GameFacade Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        public void SetState(IGameState newState)
        {
            _gameState = newState;
        }

        public void Display()
        {
            _gameState.Display(this);
        }
    }
}
