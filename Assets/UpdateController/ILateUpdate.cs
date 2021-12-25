using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZZBase.Maze
{
    public interface ILateUpdate : IUpdatable
    {
        public void LateUpdate(float deltaTime);
    }
}
