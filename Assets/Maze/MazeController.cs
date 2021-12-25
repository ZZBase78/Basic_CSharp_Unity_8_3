using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZZBase.Maze
{
    public sealed class MazeController
    {
        private Maze maze;

        public MazeController(Maze maze)
        {
            this.maze = maze;
        }

        public void Generate()
        {
            MazeGenerator mazeGenerator = new MazeGenerator(maze);
            mazeGenerator.Generate();
        }

        private Vector3 GetWorldPosition(int x, int y)
        {
            return new Vector3((float)x * 3f, 0f, (float)y * 3f);
        }
        public void ShowMaze()
        {
            MazePrefabs mazePrefabs = new MazePrefabs();

            GameObject parent = new GameObject("Maze");

            for (int x = 0; x < maze.mapWidth; x++)
            {
                for (int y = 0; y < maze.mapHeight; y++)
                {
                    Vector3 position = GetWorldPosition(x, y);
                    GameObject element = null;
                    
                    if (maze.map[x, y] == Maze.ElementType.Cell)
                    {
                        element = GameObject.Instantiate(mazePrefabs.floor, position, Quaternion.identity);
                    }
                    if (maze.map[x, y] == Maze.ElementType.HorizontalWall)
                    {
                        element = GameObject.Instantiate(mazePrefabs.wall, position, Quaternion.identity);
                        element.transform.rotation = Quaternion.Euler(0, 90, 0);
                    }
                    if (maze.map[x, y] == Maze.ElementType.VerticalWall)
                    {
                        element = GameObject.Instantiate(mazePrefabs.wall, position, Quaternion.identity);
                    }
                    if (maze.map[x, y] == Maze.ElementType.WallCross)
                    {
                        element = GameObject.Instantiate(mazePrefabs.wallCross, position, Quaternion.identity);
                    }

                    element?.transform.SetParent(parent.transform);
                }
            }
        }
    }
}
