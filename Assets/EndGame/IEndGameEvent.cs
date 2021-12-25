using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZZBase.Maze
{
    public interface IEndGameEvent
    {

        public event Action actionEndGame;

    }
}
