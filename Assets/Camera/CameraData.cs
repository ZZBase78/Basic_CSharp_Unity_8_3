using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZZBase.Maze
{
    public sealed class CameraData : ICameraData
    {
        public float speed { get; set; }

        public CameraData()
        {
            speed = 1f;
        }
    }
}
