﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum HexState { inactive, active };

public class BattleHex : MonoBehaviour
{
    public int horizontalCoordinate;
    public int verticalCoordinate;
    public HexState battleHexState;
    public bool isSecondLevel = false;
    public Image landscape;
    [SerializeField] Image currentState;
    public bool isStartingHex = false;
    public bool isNeighbourgHex = false;
    public bool isIncluded = false;

    private void Awake()
    {

    }

    void Update()
    {

    }

    public void MakeActive()
    {
        battleHexState = HexState.active;
    }

    public void MakeInactive()
    {
        if (battleHexState != HexState.active)
        {
            landscape.color = new Color32(170, 170, 170, 255);
        }
    }

    public void MakeAvailable()
    {
        currentState.color = new Color32(255, 255, 255, 220);
    }
}
