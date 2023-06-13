using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RessourcesManager : MonoBehaviour
{
    #region Variables
    private int _currentEnergy = 0;
    private int _currentMetal = 50;
    public static RessourcesManager instance;
    public static event Action OnRessourcesUpdate;

    public int CurrentEnergy
    {
        get => _currentEnergy;
        set
        {
            _currentEnergy = value;
            OnRessourcesUpdate?.Invoke();
        }
    }

    public int CurrentMetal {
        get => _currentMetal;
        set
        {
            _currentMetal = value;
            OnRessourcesUpdate?.Invoke();
        }
    }
    #endregion

    #region Built in Methods
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    #endregion

    #region Custom Methods
    #endregion
}
