using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZZBase.Maze
{
    public class BonusBehaviour : MonoBehaviour
    {
        public event Action<BonusMatch, Collider> onTriggerEnter = delegate (BonusMatch bonusMatch, Collider collider) { };

        public BonusMatch bonusMatch;

        private void OnTriggerEnter(Collider other)
        {
            onTriggerEnter(bonusMatch, other);
        }
    }
}
