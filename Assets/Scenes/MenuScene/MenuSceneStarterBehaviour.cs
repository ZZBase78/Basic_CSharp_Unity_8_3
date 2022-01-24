using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZZBase.Maze
{
    public class MenuSceneStarterBehaviour : MonoBehaviour
    {
        void Start()
        {
            MenuScene menuScene = new MenuScene();
            menuScene.Start();
        }
    }
}
