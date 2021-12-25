using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZZBase.Maze
{
    public interface IUpdate : IUpdatable
    {
        public void Update(float deltaTime);
    }
}
