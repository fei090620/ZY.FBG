using System.Collections.Generic;

namespace ZY.FBG.Engine.Command
{
    public class CommadBus
    {
        private CommadBus()
        {
            _commandList = new List<ICommandExecuter<ICommand>>();
        }

        public static readonly CommadBus Instance = new CommadBus();
        private List<ICommandExecuter<ICommand>> _commandList;
        public void RegisteCommand(ICommandExecuter<ICommand> command)
        {
            if (!_commandList.Contains(command))
                _commandList.Add(command);
        }

        public void UnRegisteCommand(ICommandExecuter<ICommand> command)
        {
            if (_commandList.Contains(command))
                _commandList.Remove(command);
        }
    }
}
