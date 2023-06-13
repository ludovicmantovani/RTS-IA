using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnFog : MonoBehaviour
{
    #region Variables
    [SerializeField] private int radius = 45;
    [SerializeField] private float freq = 0.5f;

    private float _lastTime = 0f;
    private FogOfWar _fogOfWar = null;
    #endregion

    #region Built in Methods
    void Start()
    {
        _lastTime = Time.time;
        _fogOfWar = FogOfWar.instance;
    }

    void Update()
    {
        if (Time.time > _lastTime + freq)
        {
            if (_fogOfWar) _fogOfWar.UnhideUnit(transform, radius);
            _lastTime = Time.time;
        }
    }
    #endregion

    #region Custom Methods
    #endregion
}
