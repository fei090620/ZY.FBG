using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZY.FBG.Engine
{
    public class GameTimeEventArgs : EventArgs
    {
        private readonly string _gameTime;
        public GameTimeEventArgs(string gameTime)
        {
            _gameTime = gameTime;
        }

        public string GameTime { get { return _gameTime; } }
    }
}
