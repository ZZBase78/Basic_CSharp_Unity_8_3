using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZZBase.Maze
{
    public sealed class BonusController : IUpdate, IMessageEventSource
    {
        public event Action<IMessage> actionMessage;

        private const string playerTag = "Player";
        private const string bonusParentName = "Bonuses";
        private int maxBonusCount;
        private BonusPrefab bonusPrefab;
        private List<BonusMatch> bonusList;
        private IBonusObserver bonusObserver;
        private GameObject bonusParent;
        
        public BonusController(IBonusObserver bonusObserver)
        {
            maxBonusCount = 10;
            bonusPrefab = new BonusPrefab();
            bonusList = new List<BonusMatch>();
            this.bonusObserver = bonusObserver;
            actionMessage = delegate (IMessage message) { };
        }

        private GameObject GetBonusParent()
        {
            if (bonusParent != null) return bonusParent;

            bonusParent = new GameObject(bonusParentName);
            return bonusParent;
        }
        
        public void Update(float deltaTime)
        {
            if (bonusList.Count < maxBonusCount) SpawnNewBonus();
        }
        private BonusType GetRandomBonusType()
        {
            BonusType[] bonusTypes = (BonusType[])Enum.GetValues(typeof(BonusType));
            return bonusTypes[UnityEngine.Random.Range(0, bonusTypes.Length)];
        }
        private void SetRandomBonusProperties(IBonus bonus)
        {
            bonus.x = (float)(UnityEngine.Random.Range(0, 10) * 6 + 3) + UnityEngine.Random.Range(0f, 2f);
            bonus.y = (float)(UnityEngine.Random.Range(0, 10) * 6 + 3) + UnityEngine.Random.Range(0f, 2f);
            bonus.bonusType = GetRandomBonusType();
            bonus.score = UnityEngine.Random.Range(1, 101);
            bonus.time = UnityEngine.Random.Range(1f, 10f);
        }

        private void SpawnNewBonus()
        {
            BonusMatch bonusMatch = new BonusMatch(new Bonus(), null);
            bonusList.Add(bonusMatch);
            SetRandomBonusProperties(bonusMatch.bonus);
            ShowBonus(bonusMatch);
        }

        private string GetBonusInfo(IBonus bonus)
        {
            if (bonus.bonusType == BonusType.CameraField)
            {
                return $"Увеличение обзора {bonus.time:F0} сек.";
            }
            else if (bonus.bonusType == BonusType.DoubleSpeed)
            {
                return $"Увеличение скорости {bonus.time:F0} сек.";
            }
            else if (bonus.bonusType == BonusType.HalfSpeed)
            {
                return $"Уменьшение скорости {bonus.time:F0} сек.";
            }
            else if (bonus.bonusType == BonusType.InputInverse)
            {
                return $"Инверсия управления {bonus.time:F0} сек.";
            }
            else if (bonus.bonusType == BonusType.Score)
            {
                return $"Собрано {bonus.score:F0} очков.";
            }
            else
            {
                return "<Неизвестный бонус>";
            }
        }

        private void BonusMatchOnTriggerEnter(BonusMatch bonusMatch, Collider collider)
        {
            if (collider.CompareTag(playerTag))
            {
                actionMessage(new Message(GetBonusInfo(bonusMatch.bonus)));
                HideBonus(bonusMatch);
                bonusList.Remove(bonusMatch);
                bonusObserver.PlayerTakeBonus(bonusMatch.bonus);
            }
        }

        private static Color RandomColor()
        {
            float r = UnityEngine.Random.Range(0f, 1f);
            float g = UnityEngine.Random.Range(0f, 1f);
            float b = UnityEngine.Random.Range(0f, 1f);
            float a = 1f;
            return new Color(r, g, b, a);
        }

        private void SetRandomColor(GameObject gameObject)
        {
            Renderer[] renderers = gameObject.GetComponentsInChildren<Renderer>();
            foreach(Renderer renderer in renderers)
            {
                renderer.material.color = RandomColor();
            }
        }

        private void ShowBonus(BonusMatch bonusMatch)
        {
            if (!bonusMatch.visible)
            {
                Vector3 position = new Vector3(bonusMatch.bonus.x, 0.5f, bonusMatch.bonus.y);
                GameObject gameObject = GameObject.Instantiate(bonusPrefab.bonus, position, Quaternion.identity);
                SetRandomColor(gameObject);
                gameObject.transform.SetParent(GetBonusParent().transform);
                BonusBehaviour bonusBehaviour = gameObject.AddComponent<BonusBehaviour>();
                bonusBehaviour.bonusMatch = bonusMatch;
                bonusBehaviour.onTriggerEnter += BonusMatchOnTriggerEnter;
                bonusMatch.gameObject = gameObject;
                bonusMatch.visible = true;
            }
        }

        private void HideBonus(BonusMatch bonusMatch)
        {
            if (bonusMatch.visible)
            {
                BonusBehaviour bonusBehaviour = bonusMatch.gameObject.GetComponent<BonusBehaviour>();
                bonusBehaviour.onTriggerEnter -= BonusMatchOnTriggerEnter;
                GameObject.Destroy(bonusMatch.gameObject);
                bonusMatch.gameObject = null;
                bonusMatch.visible = false;
            }
        }
    }
}
