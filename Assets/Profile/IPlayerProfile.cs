using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZZBase.Maze
{
    public interface IPlayerProfile
    {
        public string name { get; set; }
        public string dataPath { get; set; }
    }
}
