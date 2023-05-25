using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Data")]
    [SerializeField] private Color playerColor = Color.blue;

    public Color PlayerColor { get => playerColor;}

}
