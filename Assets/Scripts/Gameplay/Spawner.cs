using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private int defoggerRadius = 3000;
    private FogOfWar _fog;
    private bool _canUnhide = false;

    // Start is called before the first frame update
    void Start()
    {
        _fog = FogOfWar.instance;
    }

    void OnEnable(){
        FogOfWar.OnCompleteInitialize += CanUnhide;
    }

    void OnDisable(){
        FogOfWar.OnCompleteInitialize -= CanUnhide;
    }

    void CanUnhide(){
        _canUnhide = true;
    }

    public IEnumerator UnhideBase(){
        while(!_canUnhide){
            yield return new WaitForSeconds(0.1f);
        }

        _fog.UnhideUnit(transform, defoggerRadius);
    }
}
