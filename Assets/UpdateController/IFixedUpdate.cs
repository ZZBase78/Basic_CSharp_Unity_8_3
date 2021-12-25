using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZZBase.Maze
{
    public interface IFixedUpdate : IUpdatable
    {
        public void FixedUpdate(float fixedDeltatime);
    }
}
