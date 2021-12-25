using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZZBase.Maze
{
    public interface IMessageEventSource
    {
        public event Action<IMessage> actionMessage;
    }
}
