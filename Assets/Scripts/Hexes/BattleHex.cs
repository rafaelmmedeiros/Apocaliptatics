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
    public ClickOnMe clickOnMe;
    public Image landscape;
    public Distance distanceText;
    public DeploymentPosition DeploymentPosition;
    [SerializeField] protected Image currentState;
    public bool isStartingHex = false;
    public bool isNeighbourgHex = false;
    public bool isIncluded = false;

    private void Awake()
    {
        clickOnMe = GetComponent<ClickOnMe>();
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

    public virtual void MakeAvailable()
    {
        currentState.sprite = clickOnMe.fieldManager.availableToMove;
        currentState.color = new Color32(255, 255, 255, 220);
    }

    public virtual void MakeTargetToMove()
    {
        clickOnMe.isTargetToMove = true;
        BattleController.targetToMove = this;
        currentState.sprite = clickOnMe.fieldManager.availableAsTarget;
    }

    public void DefineAsStartingHex()
    {
        distanceText.distanceFromStartingPosition = 0;
        isStartingHex = true;
        distanceText.stepsToGo = 1;
    }

    public virtual bool AvailableToGround()
    {
        return true;
    }
}
