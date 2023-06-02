using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unfog : MonoBehaviour
{
    [SerializeField] private bool onStart = true;
    [SerializeField] private bool onUpdate = false;
    [SerializeField] private int radius = 1000;
    [SerializeField] private float _timeLaps = 1f;

    private FogOfWar _fogOfWar;
    private float _lastTime = 0f;

    void Start()
    {
        _fogOfWar = FogOfWar.instance;
        _lastTime = Time.time;
        if (onStart)
        {
            _fogOfWar.UnhideUnit(transform, radius);
        }
    }

    void Update()
    {
        if (onUpdate && Time.time >= _lastTime + _timeLaps)
        {
            _fogOfWar.UnhideUnit(transform, radius);
            _lastTime = Time.time;
        }
    }
}
