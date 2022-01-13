using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZZBase.Maze
{
    public sealed class EndGamePrefab
    {
        public GameObject endGame { get; private set; }

        public EndGamePrefab()
        {
            endGame = Resources.Load<GameObject>(ResourcesPathes.canvasEndGamePrefab);
        }
    }
}
