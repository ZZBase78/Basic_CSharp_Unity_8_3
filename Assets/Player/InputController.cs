using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZZBase.Maze
{
    public class InputController : IUpdate, IBonusObserver
    {

        public Vector3 force { get; private set; }
        private Timer timerInverse;

        public InputController()
        {
            force = Vector3.zero;
            timerInverse = new Timer();
        }

        public void Update(float deltaTime)
        {
            timerInverse.Update(deltaTime);
            force = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            if (timerInverse.On) force *= -1f;
        }

        public void PlayerTakeBonus(IBonus bonus)
        {
            if (bonus.bonusType == BonusType.InputInverse)
            {
                timerInverse.Add(bonus.time);
            }
        }
    }
}
