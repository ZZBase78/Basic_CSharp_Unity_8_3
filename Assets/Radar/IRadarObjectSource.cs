using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZZBase.Maze
{
    public interface IRadarObjectSource
    {
        public event Action<GameObject> eventAddRadarObject;
        public event Action<GameObject> eventRemoveRadarObject;
    }
}
