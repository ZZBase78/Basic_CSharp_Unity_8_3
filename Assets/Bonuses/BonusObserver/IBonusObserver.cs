using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZZBase.Maze
{
    public interface IBonusObserver
    {
        public void PlayerTakeBonus(IBonus bonus);
    }
}
