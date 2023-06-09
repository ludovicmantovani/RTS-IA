using Gameplay.UI.Quests;
using Inventory.Inventory;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Quests
{
    public class QuestList : MonoBehaviour
    {
        [SerializeField] private InventorySystem inventory = null;
        [SerializeField] private QuestTooltipUI questTooltipUI = null;
        private List<QuestStatus> _statuses = new List<QuestStatus>();
        private RessourcesManager _ressourcesManager = null;

        public event Action onUpdate;


        private void Start()
        {
            _ressourcesManager = RessourcesManager.instance;
        }

        public void AddQuest(Quest quest)
        {
            if (HasQuest(quest)) return;
            QuestStatus newStatus = new QuestStatus(quest);
            _statuses.Add(newStatus);
            if (questTooltipUI != null)
                questTooltipUI.Setup(newStatus);
            if (onUpdate != null)
                onUpdate();
        }

        public void CompleteObjective(Quest quest, string objective)
        {
            QuestStatus status = GetQuestStatus(quest);
            status.CompleteObjective(objective);
            if (status.IsComplete())
            {
                GiveReward(quest);
                foreach (QuestStatus questStatus in _statuses)
                {
                    if (!questStatus.IsComplete())
                    {
                        status = questStatus;
                        break;
                    }
                }

            }

            if (questTooltipUI != null)
                questTooltipUI.Setup(status);

            if (onUpdate != null)
                onUpdate();
        }

        public bool HasQuest(Quest quest)
        {
            return GetQuestStatus(quest) != null;
        }

        public IEnumerable<QuestStatus> GetStatuses()
        {
            return _statuses;
        }

        private QuestStatus GetQuestStatus(Quest quest)
        {
            foreach (QuestStatus status in _statuses)
            {
                if (status.GetQuest() == quest) return status;
            }
            return null;
        }

        private void GiveReward(Quest quest)
        {
            print(quest.GetTitle());
            if (quest.CanGiveRewards == false) return;
            foreach (Quest.Reward reward in quest.GetRewards())
            {
                if (reward.unitTemplate != null)
                {
                    for (int i = 0; i < reward.number; i++)
                    {
                        inventory.AddUnit(reward.unitTemplate, reward.spawnPoint);
                    }
                }
                if (reward.energy)
                {
                    _ressourcesManager.CurrentEnergy += reward.number;
                }
                if (reward.metal)
                {
                    _ressourcesManager.CurrentMetal += reward.number;
                }
            }
        }
    }
}
