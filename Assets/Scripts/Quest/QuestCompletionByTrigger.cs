using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Gameplay.Quests
{
    public class QuestCompletionByTrigger : QuestCompletion
    {
        [SerializeField] private bool onTriggerEnter = true;
        [SerializeField] private bool onTriggerExit = false;

        public UnityEvent CallBackFunctions = null;

        private void OnTriggerEnter(Collider other)
        {
            if (onTriggerEnter)
            {
                CompleteObjective();
                if (CallBackFunctions != null)
                    CallBackFunctions.Invoke();
                Destroy(gameObject);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (onTriggerExit)
            {
                CompleteObjective();
                if (CallBackFunctions != null)
                    CallBackFunctions.Invoke();
                Destroy(gameObject);
            }
        }
    }
}
