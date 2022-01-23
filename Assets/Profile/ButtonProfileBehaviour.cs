using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ZZBase.Maze
{
    public sealed class ButtonProfileBehaviour : MonoBehaviour
    {
        public event Action<PlayerProfile> actionSelectProfileButtonPressed;
        public PlayerProfile playerProfile;

        private void Awake()
        {
            Button button = GetComponent<Button>();
            if (button == null)
            {
                throw new Exception("GameObject have no Button component");
            }
            button.onClick.AddListener(ButtonPressed);
        }

        public void SetProfile(PlayerProfile playerProfile)
        {
            this.playerProfile = playerProfile;

            Text text = GetComponentInChildren<Text>();
            if (text == null)
            {
                throw new Exception("GameObject have no Text component");
            }
            text.text = playerProfile.name;
        }

        public void ButtonPressed()
        {
            actionSelectProfileButtonPressed?.Invoke(playerProfile);
        }
    }
}
