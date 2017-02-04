using System;

namespace ZY.FBG.Engine.Command
{
    /// <summary>
    /// 命令接口
    /// </summary>
    public interface ICommandExecuter<in TCommand> 
        where TCommand : ICommand
    {
        void Execute(TCommand newStatus);
    }
}
