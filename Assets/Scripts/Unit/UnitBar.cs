using UnityEngine;
using UnityEngine.UI;

public class UnitBar : MonoBehaviour
{
    [SerializeField] private GameObject pvContainer;
    [SerializeField] private RectTransform pvFill;
    [SerializeField] private GameObject shieldContainer;
    [SerializeField] private RectTransform shieldFill;

    private float _pvMaxSize;
    private float _shieldMaxSize;

    private void Awake()
    {
        _pvMaxSize = pvFill.sizeDelta.x;
        pvContainer.SetActive(false);
        _shieldMaxSize = shieldFill.sizeDelta.x;
        shieldContainer.SetActive(false);
    }

    public void UpdatePvBar(int curPv, int maxPv)
    {
        pvContainer.SetActive(true);
        float pvPercentage = (float)curPv / (float)maxPv;
        pvFill.sizeDelta = new Vector2(_pvMaxSize * pvPercentage, pvFill.sizeDelta.y);
    }

    public void UpdateShieldBar(int curShield, int maxShield)
    {
        shieldContainer.SetActive(true);
        float shieldPercentage = (float)curShield / (float)maxShield;
        shieldFill.sizeDelta = new Vector2(_shieldMaxSize * shieldPercentage, shieldFill.sizeDelta.y);
    }
}
