using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZZBase.Maze
{
    [Serializable]
    public sealed class ProfileList
    {
        public List<PlayerProfile> list;
        public PlayerProfile lastProfile;
        public int counter;

        public ProfileList()
        {
            list = new List<PlayerProfile>();
            lastProfile = null;
            counter = 0;
        }

        public int GetNextCounter()
        {
            counter++;
            return counter;
        }
    }
}
