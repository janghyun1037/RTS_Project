using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitState : MonoBehaviour
{
    private UnitSpawner unitSpawner;

    public enum unitState
    {
        Attack,
        Idle,
        Move,
        Death
    }

    [SerializeField]
    private int unitNumber;

    private void Awake()
    {
        unitSpawner = GetComponent<UnitSpawner>();
    }
}
