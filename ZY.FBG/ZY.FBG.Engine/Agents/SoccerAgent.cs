﻿using ADCC.Common.Datas;
using System.Diagnostics;
using System;
using ZY.FBG.Engine.Events;

namespace ZY.FBG.Engine.Agents
{
    /// <summary>
    /// 足球Agent
    /// thinking:足球比赛中，足球只有一个，那么SoccerAgent一定是单例来实现？
    /// 不一定，如果使用单例实现，程序从开始到结束，这个对象的这个字段始终都在内存里不被GC回收
    /// 如果不用单例实现，只要保证主线程中该对象只有一个就OK
    /// 那么，使用工厂方法就可以
    /// 但是在构造函数里绑定事件，对于事件的拥有者就必须判断，
    /// 如果注册者都是足球Agent那只能注册一次
    /// </summary>
    public class SoccerAgent : Domain, IChangeMovementStatus, IAggregateRoot
    {
        private SoccerAgent()
        {
            /* GameEngine.Instance是static成员，必然是在被调用之前初始化，且只初始化一次
              SoccerAgent.Instance道理是一样的
              所以这里的事件绑定只会绑定一次 */
            GameEngine.Instance.OnGameTimeChanged += Instance_OnGameTimeChanged;
        }

        //id是必填项，否则返回null
        public static SoccerAgent CreateNew(string id, MovementStatus movementStatus = null)
        {
            if (string.IsNullOrEmpty(id))
                return null;

            SoccerAgent soccer = new SoccerAgent
            {
                Id = id,
                Status = movementStatus == null ? new MovementStatus(0, 0, null) : movementStatus
            };

            return soccer;
        }

        private void Instance_OnGameTimeChanged(object sender, GameTimeEventArgs e)
        {
            Status.UpdatePos();
            Debug.WriteLine("({0},{1},{2})", Status.Pos.X, Status.Pos.Y, Status.Pos.Z);
        }

        public void UpdateMovementStatus(MovementStatus newMovementStatus)
        {
            //add code. . .
        }

        public MovementStatus Status { get; private set; }
    }
}
