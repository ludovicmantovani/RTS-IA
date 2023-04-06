using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestPositionTrigger : MonoBehaviour
{
    [SerializeField] private Vector3 targetPosition = Vector3.zero;
    [SerializeField] private float toleranceDistance = 10f;

    private bool _isFind = false;
    private float _distance = 0f;

    public delegate void OnChangeEvent(GameObject go);
    public event OnChangeEvent OnChange;


    private void Start()
    {
        targetPosition.y = transform.position.y;
    }

    void Update()
    {
        if (!_isFind)
        {
            _isFind = FindDistanceToTarget() <= toleranceDistance;
            if (_isFind && OnChange != null)
            {
                OnChange(gameObject);
            }
        }
    }

    private float FindDistanceToTarget()
    {
        _distance = Vector3.Distance(transform.position, targetPosition);
        return _distance;
    }
}
