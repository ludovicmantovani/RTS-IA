using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Quests
{
    public class QuestGiver : MonoBehaviour
    {
        [SerializeField] private List<Quest> quests = new List<Quest>();
        [SerializeField] private bool giveAtStart = false;

        private void Start()
        {
            if (quests != null && giveAtStart)
            {
                foreach (Quest quest in quests)
                {
                    if (quest != null)
                        GiveQuest(quest);
                }
            }
        }

        public void GiveQuest(Quest quest)
        {
            QuestList questList = GameObject.FindGameObjectWithTag("Player").GetComponent<QuestList>();
            questList.AddQuest(quest);
        }
    }
}
