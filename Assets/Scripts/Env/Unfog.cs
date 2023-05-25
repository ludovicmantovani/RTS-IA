using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unfog : MonoBehaviour
{
    private FogOfWar _fogOfWar;
    // Start is called before the first frame update
    void Start()
    {
        _fogOfWar = FogOfWar.instance;
        _fogOfWar.UnhideUnit(transform, 1000);
    }

    // Update is called once per frame
    void Update()
    {
        _fogOfWar.UnhideUnit(transform, 1000);
    }
}
