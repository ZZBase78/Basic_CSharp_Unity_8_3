using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZZBase.Maze
{
    public sealed class MazeSettings
    {
        public float cellWidth { get; }
        public float cellHeight { get; }

        public int mazeWidth { get; }
        public int mazeHeight { get; }

        public float mazeWallThickness { get; }
        public float mazeWallCrossSize { get; }

        public float mazeWallHeight { get; }

        public MazeSettings()
        {
            cellWidth = 3f;
            cellHeight = 3f;
            mazeWidth = 20;
            mazeHeight = 20;
            mazeWallThickness = 0.3f;
            mazeWallCrossSize = 0.5f;
            mazeWallHeight = 2f;
        }
    }
}
