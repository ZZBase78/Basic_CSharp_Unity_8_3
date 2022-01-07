using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZZBase.Maze
{
    public sealed class Game
    {
        private UpdateController updateController;
        private InputData inputData;
        private InputController inputController;
        private Player player;
        private PlayerController playerController;
        private CameraController cameraController;
        private BonusController bonusController;
        private MessageInformerController messageInformerController;

        public Game(UpdateController updateController)
        {
            this.updateController = updateController;
        }

        public void Start()
        {
            InitMaze();
            InitInputData();
            InitInputController();
            InitPlayer();
            InitPlayerController();
            InitCameraController();
            InitBonusController();
            InitEndGameController();
            InitMessageInformerController();
            UpdateControllerRelation();
        }

        private void InitInputData()
        {
            inputData = new InputData();
        }

        private void InitMaze()
        {
            MazeController mazeController = new MazeController(new Maze());
            mazeController.Generate();
            mazeController.ShowMaze();
        }

        private void UpdateControllerRelation()
        {
            updateController.Add(inputController);
            updateController.Add(playerController);
            updateController.Add(cameraController);
            updateController.Add(bonusController);
            updateController.Add(messageInformerController);
        }

        private void InitInputController()
        {
            inputController = new InputController(inputData);
        }

        private void InitPlayer()
        {
            player = new Player();
        }

        private void InitPlayerController()
        {
            playerController = new PlayerController(player, inputData);
            playerController.ShowPlayer();
        }

        private void InitCameraController()
        {
            cameraController = new CameraController(new CameraData(), playerController.GetPlayer());
            cameraController.ShowCamera();
        }

        private void InitBonusController()
        {
            BonusObservers bonusObservers = new BonusObservers();
            bonusObservers.Add(inputController);
            bonusObservers.Add(playerController);
            bonusObservers.Add(cameraController);

            bonusController = new BonusController(bonusObservers);
        }

        private void InitEndGameController()
        {
            EndGameController endGameController = new EndGameController();
            endGameController.AddEventSource(playerController);
        }

        private void InitMessageInformerController()
        {
            messageInformerController = new MessageInformerController();
            messageInformerController.AddMessageSource(bonusController);
        }
    }
}
