using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private QuestPositionTrigger questPositionTrigger = null;

    private void Start()
    {
        if (questPositionTrigger != null)
        {
            questPositionTrigger.OnChange += ValidState;
        }
    }

    private void ValidState(GameObject go)
    {
        print("Youpi !!! " + go.name);
    }
}
