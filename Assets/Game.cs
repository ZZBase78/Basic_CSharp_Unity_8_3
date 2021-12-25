using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZZBase.Maze
{
    public sealed class Game
    {
        private UpdateController updateController;

        public Game(UpdateController updateController)
        {
            this.updateController = updateController;
        }

        public void Start()
        {
            Maze maze = new Maze();
            MazeController mazeController = new MazeController(maze);
            mazeController.Generate();
            mazeController.ShowMaze();

            InputController inputController = new InputController();
            updateController.Add(inputController);

            Player player = new Player();
            PlayerController playerController = new PlayerController(player, inputController);
            playerController.ShowPlayer();
            updateController.Add(playerController);

            CameraData cameraData = new CameraData();
            CameraController cameraController = new CameraController(cameraData, playerController.GetPlayer());
            cameraController.ShowCamera();
            updateController.Add(cameraController);

            BonusObservers bonusObservers = new BonusObservers();
            bonusObservers.Add(inputController);
            bonusObservers.Add(playerController);
            bonusObservers.Add(cameraController);

            BonusController bonusController = new BonusController(bonusObservers);
            updateController.Add(bonusController);

            EndGameController endGameController = new EndGameController();
            endGameController.AddEventSource(playerController);

            MessageInformerController messageInformerController = new MessageInformerController();
            messageInformerController.AddMessageSource(bonusController);
            updateController.Add(messageInformerController);

        }
    }
}
