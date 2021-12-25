using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZZBase.Maze
{
    public sealed class MazePrefabs
    {
        public GameObject wall { get; private set; }
        public GameObject wallCross { get; private set; }
        public GameObject floor { get; private set; }

        public MazePrefabs()
        {
            wall = Resources.Load<GameObject>("Prefabs/Maze/Wall");
            wallCross = Resources.Load<GameObject>("Prefabs/Maze/WallCross");
            floor = Resources.Load<GameObject>("Prefabs/Maze/Floor");
        }
    }
}
