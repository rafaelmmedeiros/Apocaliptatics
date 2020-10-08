using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickOnMe : MonoBehaviour, 
    IPointerClickHandler
{
    BattleHex hex;
    public bool isTargetToMove = false;
    public FieldManager fieldManager;

    void Awake()
    {
        hex = GetComponent<BattleHex>();
        fieldManager = FindObjectOfType<FieldManager>();
    }

    void Update()
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!isTargetToMove)
        {
            SelectTargetToMove();
        }
        else
        {
            BattleController.currentAtacker.GetComponent<Move>().StartsMoving();
        }
    }

    private void SelectTargetToMove()
    {
        ClearPreviousSelectionOfTargetHex();
        if (hex.isNeighbourgHex)
        {
            hex.MakeTargetToMove();
            BattleController.currentAtacker.GetComponent<OptimalPath>().MatchPath();
        }
    }

    public void ClearPreviousSelectionOfTargetHex()
    {
        foreach (BattleHex hex in FieldManager.activeHexList)
        {
            if (hex.clickOnMe.isTargetToMove == true)
            {
                hex.GetComponent<ClickOnMe>().isTargetToMove = false;
                hex.MakeAvailable();
            }

        }
    }
}
